using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTimerSnow : MonoBehaviour
{
    private Animator anim;
    public float timer;
    // Update is called once per frame
    private void Awake()
    {
    }
    void FixedUpdate()
    {
        timer += 0.1f;
    }

    public float GetTime()
    {
        return timer;
    }
}
