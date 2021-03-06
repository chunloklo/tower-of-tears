﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitToMenu : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        //Cursor.visible = true;
    }

    public void ShowMenu()
    {
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
        SceneManager.LoadScene("AlphaDemoStartMenu");
        Debug.Log("waiting for transition");

    }
}
