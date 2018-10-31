using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffController : MonoBehaviour {

    Light wallLight;
    private ParticleSystem.EmissionModule flame;

    public GameObject[] traps;

    private GameOverController gameOverController;
    private void Awake()
    {
        wallLight = this.gameObject.transform.GetChild(0).GetComponent<Light>();
        flame = this.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().emission;
        gameOverController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameOverController>();
    }

    void OnTriggerEnter(Collider c) {
        // turn on point light and flame particles
        if (!wallLight.enabled) {
            wallLight.enabled = true;
            flame.enabled = true;
            EventManager.TriggerEvent<TorchLightEvent, Vector3>(gameObject.transform.position);

            if (gameOverController != null)
            {
                gameOverController.GetComponent<GameOverController>().AddLamp();
            }


            for (int i = 0; i < traps.Length; i++)
            {
                print(traps[i]);
                traps[i].GetComponent<TrapController>().TrapDisable();
            }
        } 
    }

    //void OnTriggerExit(Collider c)
    //{   
    //    print(c);
    //    if (wallLight.enabled)
    //    {
    //        wallLight.enabled = false;
    //        flame.enabled = false;
    //    }
    //}
}
