using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitToXmas : MonoBehaviour
{
    public Animator animator;
    //public CutsceneTimer ct;

    public void Start()
    {
        //ct = ct.GetComponent<CutsceneTimer>();
    }

    public void Update()
    {
        /*if (ct != null && ct.GetTime() > 78)
        {
            StartGame();
        }*/
    }

    public void StartGame()
    {
        Debug.Log("clicked xmas");
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
        SceneManager.LoadScene("SnowLevel");
        Debug.Log("waiting for transition");

    }
}
