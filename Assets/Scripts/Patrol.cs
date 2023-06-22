using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;

    public PlayerHealth playerHealth;

    public Transform groundDetection;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    void Update()
    {
        if (playerHealth.health > 0) {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
                Debug.Log("true");
            }
            else
            {
                isChasing = false;
                Debug.Log("false");
            }

            if (isChasing)
            {
                if (transform.position.x > playerTransform.position.x)
                {
                    //transform.localScale = new Vector3(1, 1, 1);
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }

                if (transform.position.x < playerTransform.position.x)
                {
                    //transform.localScale = new Vector3(-1, 1, 1);
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }

            }
            else
            {
                Patrolling();
            }
        }

       void Patrolling()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
            if (groundInfo.collider == false)
            {
                Debug.Log("sprawdza krawedzie");
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }

        
     }
}
