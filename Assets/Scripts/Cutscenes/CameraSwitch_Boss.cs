using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch_Boss : MonoBehaviour {

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject cameraThree;
    public GameObject cameraFour;
    public CutsceneTimer ct;

    bool switchedToTwo;
    bool switchedToThree;
    bool switchedToFour;

    CinemachineVirtualCamera c1;
    CinemachineVirtualCamera c2;
    CinemachineVirtualCamera c3;

    int activeCam;

    // Use this for initialization
    void Start()
    {
        c1 = cameraOne.GetComponent<CinemachineVirtualCamera>();
        c2 = cameraTwo.GetComponent<CinemachineVirtualCamera>();
        c3 = cameraThree.GetComponent<CinemachineVirtualCamera>();

        //Start at cam 1
        cameraPositionChange(1);

        ct = ct.GetComponent<CutsceneTimer>();

        switchedToTwo = false;
        switchedToThree = false;
    }
    
    void Update()
    {
        switchCamera();
    }
    
    void switchCamera()
    {
        if (ct.GetTime() > 10 && !switchedToTwo)
        {
            changeToCam2();
        }
        if (ct.GetTime() > 20 && !switchedToThree)
        {
            changeToCam3();
        }
    }
    
    void changeToCam2()
    {
        switchedToTwo = true;
        cameraPositionChange(2);
    }

    void changeToCam3()
    {
        switchedToThree = true;
        cameraPositionChange(3);
    }

    void cameraPositionChange(int camPosition)
    {
        if (camPosition == 1)
        {
            cameraOne.SetActive(true);
            c1.enabled = true;

            c2.enabled = false;
            cameraTwo.SetActive(false);

            c3.enabled = false;
            cameraThree.SetActive(false);
        }
        
        if (camPosition == 2)
        {
            cameraTwo.SetActive(true);
            c2.enabled = true;

            c1.enabled = false;
            cameraOne.SetActive(false);

            c3.enabled = false;
            cameraThree.SetActive(false);
        }

        if (camPosition == 3)
        {
            cameraThree.SetActive(true);
            c3.enabled = true;

            c1.enabled = false;
            cameraOne.SetActive(false);

            c2.enabled = false;
            cameraTwo.SetActive(false);
        }
    }
}
