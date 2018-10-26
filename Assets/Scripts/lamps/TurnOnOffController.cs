using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffController : MonoBehaviour {

    Light wallLight;
    private ParticleSystem.EmissionModule flame;

    GameObject trap;
    private void Awake()
    {
        wallLight = this.gameObject.transform.GetChild(0).GetComponent<Light>();
        flame = this.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().emission;


        trap = GameObject.FindWithTag("Trap");
    }

    void OnTriggerEnter(Collider c) {
        print(c);
        // turn on point light and flame particles
        if (!wallLight.enabled) {
            wallLight.enabled = true;
            flame.enabled = true;

            trap.GetComponent<Animation>().Play("Anim_SawTrap01_Play");
        } 
    }

    void OnTriggerExit(Collider c)
    {   
        print(c);
        if (wallLight.enabled)
        {
            wallLight.enabled = false;
            flame.enabled = false;
        }
    }
}
