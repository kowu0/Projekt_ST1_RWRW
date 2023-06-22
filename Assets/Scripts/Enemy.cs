using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;


    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }

    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            //GetComponent<MonsterDamage>().enabled = false;
            GetComponent<Patrol>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("IsDead", true);

        //wylacza oponenta
        
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        StartCoroutine(waiter());
        
    }
}

   
