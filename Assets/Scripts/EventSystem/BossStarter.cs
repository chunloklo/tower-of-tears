using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStarter : MonoBehaviour {

    private CanvasGroup canvasGroup;
    public FollowCameraController camController;
    // Use this for initialization
    void Start () {
        if (GetComponent<CanvasGroup>() == null)
        {
            Debug.LogError("Cannot find component");
        }
        canvasGroup = GetComponent<CanvasGroup>();
        if(camController != null)
        {
            camController.enabled = false;
        }

        StartCoroutine(waitThenTransition());
    }

    public void DisableCanvas()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        Time.timeScale = 1f;
        Cursor.visible = false;
        if (camController != null)
        {
            camController.enabled = true;
        }
    }

    IEnumerator waitThenTransition()
    {
        yield return new WaitForSeconds(0.7F);
        Time.timeScale = 0f;
        Debug.Log("waitning for transition");

    }
}
