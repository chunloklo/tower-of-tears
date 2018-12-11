using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SnowSceneSwitcher : MonoBehaviour
{
    public Animator animator;
    public CutsceneTimerSnow ct;

    public void Start()
    {
        ct = ct.GetComponent<CutsceneTimerSnow>();
    }

    public void Update()
    {
        if (ct.GetTime() > 100)
        {
            MoveToSnow();
        }
    }

    public void MoveToSnow()
    {
        animator.SetTrigger("FadeOut");
        StartCoroutine(waitThenTransition());
    }

    IEnumerator waitThenTransition()
    {
        yield return new WaitForSeconds(0.7F);
        SceneManager.LoadScene("SnowLevel");

    }
}
