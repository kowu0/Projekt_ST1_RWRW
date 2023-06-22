using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndOnBoss : MonoBehaviour
{
    public GameObject testobject1;
    public Boss boss;

    private void Update()
    {
        Debug.Log(boss.health);

    }

    public IEnumerator coroutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        //Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && boss.health == 0)
        {
            Debug.Log("????");
            testobject1.SetActive(true); // Włączanie obiektu
            StartCoroutine(coroutine());
        }
    }
}
