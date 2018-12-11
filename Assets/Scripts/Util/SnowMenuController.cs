using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMenuController : MonoBehaviour {

    public ParticleSystem snow;

    // Use this for initialization
    void Start () {
        snow = GetComponent<ParticleSystem>();
        if (snow != null) {
            var emission = snow.emission;
            if (CrossSceneInformation.santaHat == true)
            {
                emission.enabled = true;
            }
            else
            {
                emission.enabled = false;
            }
        }

    }
}
