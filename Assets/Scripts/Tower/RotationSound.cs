using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RotationSound : MonoBehaviour {


    private AudioSource audioSource;
    private Quaternion rotation;
    private Vector3 position;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rotation = transform.rotation;
        position = transform.position;
        audioSource.loop = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (rotation == transform.rotation && position == transform.position)
        {
            audioSource.mute = true;
        } else
        {
            audioSource.mute = false;
        }


        rotation = transform.rotation;
        position = transform.position;
    }
}
