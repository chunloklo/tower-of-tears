using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneStarter : MonoBehaviour
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
        Debug.Log("hello");
        StartCoroutine(waitThenTransition());

    }

    IEnumerator waitThenTransition()
    {
        yield return new WaitForSeconds(0.7F);
        SceneManager.LoadScene("AlphaIntroCutscene");
        Debug.Log("waitning for transition");

    }
}
