using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTimerIntro : MonoBehaviour {
    private Animator anim;
    public float timer;
    // Update is called once per frame
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate () {
        timer += 0.1f;
        anim.SetFloat("timer", timer);
	}

    public float GetTime()
    {
        return timer;
    }
}
