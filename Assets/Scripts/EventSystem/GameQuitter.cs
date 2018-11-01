using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Debug.Log("clicked end");
        Application.Quit();
    }
}
