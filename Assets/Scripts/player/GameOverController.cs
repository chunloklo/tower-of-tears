using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    int lampCount;

    void Awake() {
        lampCount = 0;
    }

    public void AddLamp()
    {
        lampCount++;

        if (lampCount == 1) {
            CrossSceneInformation.GameOverTitle = "You won! ";
            CrossSceneInformation.GameOverSubtitle = "You are the new tower master now.";
            SceneManager.LoadScene("AlphaDemoBossGameOver");
        }
    }
}
