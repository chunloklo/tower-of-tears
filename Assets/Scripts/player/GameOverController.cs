using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    int lampCount;
    public Animator animator;

    void Awake() {
        lampCount = 0;
    }

    public void AddLamp()
    {
        lampCount++;

        if (lampCount == 4) {
            CrossSceneInformation.GameOverTitle = "You won! ";
            CrossSceneInformation.GameOverSubtitle = "You are the new tower master now.";

            animator.SetTrigger("FadeOut");
            StartCoroutine(waitThenTransition());
        }
    }

    IEnumerator waitThenTransition()
    {
        yield return new WaitForSeconds(0.7F);
        SceneManager.LoadScene("AlphaDemoBossGameOver");

    }
}
