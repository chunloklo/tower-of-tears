using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CutsceneMusic : MonoBehaviour {

    public AudioSource audioSource;
    public CutsceneTimer ct;
    bool played;

    // Use this for initialization
    void Start () {
        played = false;
        ct = ct.GetComponent<CutsceneTimer>();
        audioSource = GetComponent<AudioSource>();
        Debug.Log("working");
        //audioSource.Play(0);
    }
	
	// Update is called once per frame
	void Update () {
		if (ct.GetTime() > 14 && !played)
        {
            audioSource.Play(0);
            played = true;
        }
	}
}
