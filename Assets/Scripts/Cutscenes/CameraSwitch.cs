using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public CutsceneTimer ct;

    bool switched;

    CinemachineVirtualCamera c1;
    CinemachineVirtualCamera c2;

    int activeCam;

    // Use this for initialization
    void Start()
    {
        c1 = cameraOne.GetComponent<CinemachineVirtualCamera>();
        c2 = cameraTwo.GetComponent<CinemachineVirtualCamera>();

        //Start at cam 1
        cameraPositionChange(1);

        ct = ct.GetComponent<CutsceneTimer>();
        switched = false;
    }
    
    void Update()
    {
        switchCamera();
    }
    
    void switchCamera()
    {
        if (ct.GetTime() > 20 && !switched)
        {
            changeToCam2();
        }
    }
    
    void changeToCam2()
    {
        switched = true;
        cameraPositionChange(2);
    }
    
    void cameraPositionChange(int camPosition)
    {
        if (camPosition == 1)
        {
            cameraOne.SetActive(true);
            c1.enabled = true;

            c2.enabled = false;
            cameraTwo.SetActive(false);
        }
        
        if (camPosition == 2)
        {
            cameraTwo.SetActive(true);
            c2.enabled = true;

            c1.enabled = false;
            cameraOne.SetActive(false);
        }

    }
}
