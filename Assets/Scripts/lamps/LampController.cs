using UnityEngine;
using System.Collections;

public class LampController : MonoBehaviour
{
    Light wallLight;

    private void Awake()
    {
        wallLight = this.gameObject.transform.GetChild(0).GetComponent<Light>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (!wallLight.enabled)
        {
            c.GetComponent<GameOverController>().AddLamp();
        }
    }
}
