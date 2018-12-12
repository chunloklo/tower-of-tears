using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepGirl : MonoBehaviour {

    public void PlayFootstep()
    {
        EventManager.TriggerEvent<FootstepEvent, Vector3>(this.transform.position);
    }

    public void PlayJump()
    {
        EventManager.TriggerEvent<JumpEvent, Vector3>(this.transform.position);
    }

}
