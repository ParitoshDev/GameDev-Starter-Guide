using System.Runtime.InteropServices;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPathEditor : MonoBehaviour
{
    [SerializeField] Transform[] targets;
    [SerializeField] float moveSpeed;
    [SerializeField] int currentTarget = 0;

    private void Awake()
    {
        currentTarget = 0;
    }

    private void Update()
    {  
        if (transform.position == targets[currentTarget].position) {
           currentTarget =  SwitchTarget(currentTarget);
            Flip();
        }

        transform.position = Vector3.MoveTowards(transform.position, targets[currentTarget].position, moveSpeed * Time.deltaTime);    
    }

    private int SwitchTarget(int currentTarget) {
        if (currentTarget == targets.Length - 1)
        {
            currentTarget = 0;
        }
        else {
            currentTarget++;
        }
        return currentTarget;
    }

    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnDrawGizmos()
    {
        foreach (Transform t in targets) {
            Gizmos.DrawWireSphere(t.position, 0.5f);
        }
        Gizmos.DrawLine(targets[0].position, targets[1].position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Time.timeScale = 0; 
        }
    }
}
