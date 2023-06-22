using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public float maxHealth;
    public float health;
    public Image healthBar;
    // Start is called before the first frame update

    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(2f);
        //Time.timeScale = 0.0f;
    }
    void Start()
    {
        health = maxHealth;
        //animator.SetInteger("Health", health);
    }

    void Update()
    {
        if(health <= 0)
        {
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CharacterMovement>().enabled = false;
            animator.SetTrigger("IsDead");
            StartCoroutine(Waiter());
        }
        //animator.SetFloat("Health", health);
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 100);
    }
}
