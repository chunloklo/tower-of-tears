using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitter : MonoBehaviour
{

    public void QuitGame()
    {
        Debug.Log("clicked end");
        Application.Quit();
    }
}
