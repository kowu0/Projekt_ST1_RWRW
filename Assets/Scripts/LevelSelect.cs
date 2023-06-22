using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Animator animator;
    IEnumerator waiter(int time, int sceneIndex)
    {
        FadeToLevel();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneIndex);
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");

    }

    public void LoadLevel1()
    {    
        StartCoroutine(waiter(1,2));  
    }
    public void LoadLevel2()
    {
        StartCoroutine(waiter(1, 3));
    }

    public void LoadLevel3()
    {
        StartCoroutine(waiter(1, 4));
    }

    public void LoadMenu()
    {
        StartCoroutine(waiter(1, 0));
    }
   
}
