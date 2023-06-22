using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnLevelFall : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("????");
            playerHealth.health = 0;
        }
    }
}
