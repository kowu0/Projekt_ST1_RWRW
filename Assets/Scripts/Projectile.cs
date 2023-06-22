using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float damage;
    public Animator animator;


    public float speed;
    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ProjectileDamage();
            DestroyProjectile();
            Debug.Log("niszczy");
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void ProjectileDamage()
    {
        playerHealth.health -= damage;
        animator.SetTrigger("Damaged");
    }
}
