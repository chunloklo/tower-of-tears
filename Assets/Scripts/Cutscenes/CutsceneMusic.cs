using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CutsceneMusic : MonoBehaviour {

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public CutsceneTimer ct;
    bool played;
    bool played2;

    // Use this for initialization
    void Start () {
        played = false;
        played2 = false;
        ct = ct.GetComponent<CutsceneTimer>();
    }
	
	// Update is called once per frame
	void Update () {
		if (ct.GetTime() > 14 && !played)
        {
            audioSource.Play(0);
            played = true;
        }
        if (ct.GetTime() > 16 && !played2)
        {
            audioSource2.Play(0);
            played2 = true;
        }
    }
}
