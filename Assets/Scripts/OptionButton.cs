using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionButton : MonoBehaviour
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
    public void BackButton()
    {

        StartCoroutine(waiter(1, 0));

    }
    public void OptionsButton()
    {

        StartCoroutine(waiter(1, 5));

    }

    public void CreditButton()
    {
        StartCoroutine(waiter(1, 6));
    }

}

