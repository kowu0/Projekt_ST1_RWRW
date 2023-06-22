using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedNextLevel : MonoBehaviour
{

    void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void NextLevel()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackMenu()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
