using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject gameObject123;
    public Enemy enemy;
    public Transform startPoint; // Punkt startowy (pusty GameObject)
    public Transform endPoint; // Punkt końcowy (pusty GameObject)
    public float speed = 2f; // Prędkość poruszania platformy

    private bool movingToEnd = true; // Czy platforma porusza się w kierunku punktu końcowego?
 
    private void Start()
    {
    }

    void Update()
    {
        
        platformMoving();
    }
    void platformMoving(){
 // Poruszanie platformą
        if(enemy.currentHealth<=0){
        if (movingToEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

            // Sprawdzanie, czy osiągnięto punkt końcowy
            if (Vector2.Distance(transform.position, endPoint.position) < 0.1f)
            {
                movingToEnd = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);

            // Sprawdzanie, czy osiągnięto punkt startowy
            if (Vector2.Distance(transform.position, startPoint.position) < 0.1f)
            {
                movingToEnd = true;
            }
        }}
    }
}

