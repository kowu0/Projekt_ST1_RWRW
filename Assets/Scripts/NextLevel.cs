using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject GameObject;
    
    private void Start()
    {
        StartCoroutine(PlatformChange());
    }

    private IEnumerator PlatformChange()
    {
        for(int i = 100; i >= 0; i--)
        {
            yield return new WaitForSecondsRealtime(5f);
            float zmienna = Random.Range(10f, 70f);
            gameObject.transform.localScale = new Vector3(zmienna, 6.571978f);
            Debug.Log(zmienna);
        }
    }
}
