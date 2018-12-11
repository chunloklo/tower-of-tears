using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitToEndXmas : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("FadeOut");
            StartCoroutine(waitThenTransition());
        }
    }

    IEnumerator waitThenTransition()
    {
        yield return new WaitForSeconds(0.7F);
        CrossSceneInformation.GameOverTitle = "Happy Holidays! ";
        CrossSceneInformation.GameOverSubtitle = "You get to wear a santa hat from now on.";
        CrossSceneInformation.santaHat = true;
        SceneManager.LoadScene("SnowLevelGameOver");

    }
}
