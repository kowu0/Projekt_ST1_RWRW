using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathPanel : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject GameObject;

    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameObject.SetActive(true);
    }

    public void Restart()
    {
        //Time.timeScale = 1;
        //this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    void Start()
    {
      GameObject.SetActive(false);
    }

     void Update()
    {
        Debug.Log(playerHealth.health);
        if (playerHealth.health <= 0)
        {
            StartCoroutine(Waiter()); 
        }
    }


}
