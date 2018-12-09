using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverControllerCutscene : MonoBehaviour
{
    int lampCount;
    public Animator animator;
    public CutsceneTimer ct;

    public void Start()
    {
        ct = ct.GetComponent<CutsceneTimer>();
    }

    public void Update()
    {
        if (ct.GetTime() > 45)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        CrossSceneInformation.GameOverTitle = "You won! ";
        CrossSceneInformation.GameOverSubtitle = "You are the new tower master now.";

        animator.SetTrigger("FadeOut");
        StartCoroutine(waitThenTransition());
    }

    IEnumerator waitThenTransition()
    {
        yield return new WaitForSeconds(0.7F);
        SceneManager.LoadScene("AlphaDemoBossGameOver");

    }
}
