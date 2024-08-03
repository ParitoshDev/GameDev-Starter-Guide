using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Khai : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            UIManager.Instance.EnableGameOver();
        }
    }
}
