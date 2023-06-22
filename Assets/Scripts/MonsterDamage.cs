using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    public float damage;
    public PlayerHealth playerHealth;
    public PlayerController playerContrl;
    public Animator animator;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerContrl.KBCounter = playerContrl.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playerContrl.KnockFromRight = true;
            }
            else
            {
                playerContrl.KnockFromRight = false;
            }
            playerHealth.health -= damage;
            animator.SetTrigger("Damaged");
        }
    }
}
