using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }


    IEnumerator waiter(int time, int sceneIndex)
    {
        FadeToLevel();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneIndex);
    }

    public void PlayGame()
    {

        StartCoroutine(waiter(1, 1));

    }

    public void QuitGame()
    {
        
        Application.Quit();
        Debug.Log("Quit game - works");
    }
}
