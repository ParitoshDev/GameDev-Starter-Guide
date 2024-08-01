using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    float moveInput;
    Rigidbody2D rb;
    [SerializeField] float jumpForce;

    Animator animator;
    [SerializeField] bool isGrounded = true;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] float groundCheckRadius;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer)) { 
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        Run();
        Jump();       
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
       
    }
    private void Run() {
        moveInput = Input.GetAxis("Horizontal");
        if (moveInput != 0f)
        {
            animator.SetBool("isRunning", true);
            rb.velocity = new Vector2(moveInput * moveSpeed * Time.deltaTime, rb.velocity.y);
        }
        else { 
            animator.SetBool("isRunning", false);
        }           
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheckPosition.position, groundCheckRadius);
    }

}
