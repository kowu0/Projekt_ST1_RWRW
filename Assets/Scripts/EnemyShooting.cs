using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Enemy enemy;
    public PlayerHealth playerHealth;
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float timeBtwShots;

    public List<Transform> waypoints;
    public float minTimeBetweenWaypoints;
    public float maxTimeBetweenWaypoints;
    private float timeBtwWaypoints;

    public float detectionRadius;

    public GameObject shot;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        timeBtwWaypoints = Random.Range(minTimeBetweenWaypoints, maxTimeBetweenWaypoints);

    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < detectionRadius)
        {
            if (Vector2.Distance(transform.position, player.position) < nearDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance)
            {
                transform.position = this.transform.position;
            }

            if (timeBtwShots <= 0)
            {
               if (playerHealth.health > 0) {
               Instantiate(shot, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots; }
                
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

        if (timeBtwWaypoints <= 0)
        {
            // Wylosuj losowy punkt docelowy
            Transform randomWaypoint = waypoints[Random.Range(0, waypoints.Count)];

            // Przenie� obiekt do wybranego punktu docelowego
            transform.position = randomWaypoint.position;

            timeBtwWaypoints = Random.Range(minTimeBetweenWaypoints, maxTimeBetweenWaypoints);
        }
        else
        {
            timeBtwWaypoints -= Time.deltaTime;
        }

        if(enemy.currentHealth <= 0)
        {
            GetComponent<EnemyShooting>().enabled = false;
        }
    }

    
}

