using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepEmitter : MonoBehaviour {



    public void ExecuteFootstep() {

        EventManager.TriggerEvent<FootstepEvent, Vector3>(transform.position);
    }
}
