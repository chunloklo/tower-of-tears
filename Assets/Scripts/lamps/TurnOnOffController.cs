using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffController : MonoBehaviour {

    Light wallLight;
    private ParticleSystem.EmissionModule flame;

    private void Awake()
    {
        wallLight = this.gameObject.transform.GetChild(0).GetComponent<Light>();
        flame = this.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().emission;
    }

    void OnTriggerEnter(Collider c) {
        // turn on point light and flame particles
        if (!wallLight.enabled) {
            wallLight.enabled = true;
            flame.enabled = true;
        } 
    }

    void OnTriggerExit(Collider c) {
        if (wallLight.enabled)
        {
            wallLight.enabled = false;
            flame.enabled = false;
        }
    }
}
