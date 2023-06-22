using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NextLevelPanelScriptOnEntry : MonoBehaviour
{
    public GameObject testobject1;

    public IEnumerator coroutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("????");
            testobject1.SetActive(true); // Włączanie obiektu
            StartCoroutine(coroutine());
        }
    }
}