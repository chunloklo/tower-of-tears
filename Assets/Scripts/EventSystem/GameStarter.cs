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
        animator.SetTrigger("FadeOut");
        StartCoroutine(waitThenTransition());

    }

    IEnumerator waitThenTransition()
    {
        yield return new WaitForSeconds(0.7F);
        SceneManager.LoadScene("AlphaDemoLevel");

    }
}
