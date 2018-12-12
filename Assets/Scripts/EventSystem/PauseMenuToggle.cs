using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CanvasGroup))]

public class PauseMenuToggle : MonoBehaviour {


    public FollowCameraController camController;
    private CanvasGroup canvasGroup;
        
	void Start () {

        camController = Camera.main.GetComponent<FollowCameraController>();

        if (GetComponent<CanvasGroup>() == null)
        {
            Debug.LogError("Cannot find component");
        }
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        Time.timeScale = 1f;
        Cursor.visible = false;
        if (camController != null)
        {
            camController.disabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (canvasGroup.interactable)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            
            if (canvasGroup.interactable)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;
                Time.timeScale = 1f;
                Cursor.visible = false;
                if (camController != null)
                {
                    camController.disabled = false;
                }


            }
            else
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
                Time.timeScale = 0f;
                Cursor.visible = true;
                if (camController != null)
                {
                    camController.disabled = true;
                }
            }
        }
    }
}
