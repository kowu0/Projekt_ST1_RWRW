using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public int health;
    public int maxHealth = 50;
    public float damage;
    private float timeBtwDamage = 3f;
    public PlayerController playerContrl;
    public PlayerHealth playerHealth;
    public GameObject healthBar123;
    public Slider healthBar;
    private Animator anim;
    public Animator animChar;
    private CapsuleCollider2D colid;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colid = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        
    }


    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2);
        sprite.enabled = false;
    }



    private void Update()
    {

        // odczekuje pomiedzy kolejnym zadaniem obrazen
        if (timeBtwDamage > 0) {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            colid.enabled = false;
            GetComponent<Boss>().enabled = false;
            healthBar123.SetActive(false);
            anim.SetTrigger("death");
            StartCoroutine(waiter());
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerContrl.KBCounter = playerContrl.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerContrl.KnockFromRight = true;
            }
            else
            {
                playerContrl.KnockFromRight = false;
            }
            playerHealth.health -= damage;
            animChar.SetTrigger("Damaged");
        }
    }
}
