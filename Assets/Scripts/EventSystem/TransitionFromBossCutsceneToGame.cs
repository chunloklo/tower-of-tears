using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionFromBossCutsceneToGame : MonoBehaviour
{
    public Animator animator;
    public CutsceneTimerSnow ct;

    public void Start()
    {
        ct = ct.GetComponent<CutsceneTimerSnow>();
    }

    public void Update()
    {
        if (ct != null && ct.GetTime() > 90)
        {
            Transition();
        }
    }

    public void Transition()
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
        SceneManager.LoadScene("AlphaDemoBoss");
        Debug.Log("waitning for transition");

    }
}
