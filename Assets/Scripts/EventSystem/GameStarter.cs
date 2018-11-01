using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public Animator animator;

    public void StartGame()
    {
        Debug.Log("clicked start");
        if (animator != null)
        {
            animator.SetTrigger("FadeOut");
        }

        Time.timeScale = 1;
        StartCoroutine(waitThenTransition());

    }

    IEnumerator waitThenTransition()
    {
        yield return new WaitForSeconds(0.7F);
        SceneManager.LoadScene("AlphaDemoLevel");
        Debug.Log("waitning for transition");

    }
}
