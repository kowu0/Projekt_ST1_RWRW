using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLoading : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        float testowa = Random.Range(3f, 6f);
        yield return new WaitForSeconds(testowa);
        this.gameObject.SetActive(false);
        Debug.Log(testowa);
    }
}
