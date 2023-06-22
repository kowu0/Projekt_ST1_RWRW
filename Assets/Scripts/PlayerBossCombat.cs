using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Attack()
    {
        //odpala animacje ataku
        animator.SetTrigger("Attack");

        //sprawdza czy przeciwnicy sa w zasiegu
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //zadaje dmg
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Boss>().TakeDamage(attackDamage);

        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
