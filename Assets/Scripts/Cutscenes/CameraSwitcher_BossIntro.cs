using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher_BossIntro : MonoBehaviour
{

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject cameraThree;
    public GameObject cameraFour;
    public GameObject cameraFive;
    public GameObject cameraSix;
    public CutsceneTimerSnow ct;

    bool switchedToTwo;
    bool switchedToThree;
    bool switchedToFour;
    bool switchedToFive;
    bool switchedToSix;

    CinemachineVirtualCamera c1;
    CinemachineVirtualCamera c2;
    CinemachineVirtualCamera c3;
    CinemachineVirtualCamera c4;
    CinemachineVirtualCamera c5;
    CinemachineVirtualCamera c6;

    int activeCam;

    // Use this for initialization
    void Start()
    {
        c1 = cameraOne.GetComponent<CinemachineVirtualCamera>();
        c2 = cameraTwo.GetComponent<CinemachineVirtualCamera>();
        c3 = cameraThree.GetComponent<CinemachineVirtualCamera>();
        c4 = cameraFour.GetComponent<CinemachineVirtualCamera>();
        c5 = cameraFive.GetComponent<CinemachineVirtualCamera>();
        c6 = cameraSix.GetComponent<CinemachineVirtualCamera>();

        //Start at cam 1
        cameraPositionChange(1);

        ct = ct.GetComponent<CutsceneTimerSnow>();

        switchedToTwo = false;
        switchedToThree = false;
        switchedToFour = false;
        switchedToFive = false;
        switchedToSix = false;
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
        if (ct.GetTime() > 30 && !switchedToThree)
        {
            changeToCam3();
        }
        if (ct.GetTime() > 50 && !switchedToFour)
        {
            changeToCam4();
        }
        if (ct.GetTime() > 60 && !switchedToFive)
        {
            changeToCam5();
        }
        if (ct.GetTime() > 75 && !switchedToSix)
        {
            changeToCam6();
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

    void changeToCam4()
    {
        switchedToFour = true;
        cameraPositionChange(4);
    }

    void changeToCam5()
    {
        switchedToFive = true;
        cameraPositionChange(5);
    }

    void changeToCam6()
    {
        switchedToSix = true;
        cameraPositionChange(6);
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

            c4.enabled = false;
            cameraFour.SetActive(false);

            c5.enabled = false;
            cameraFive.SetActive(false);

            c6.enabled = false;
            cameraSix.SetActive(false);
        }

        if (camPosition == 2)
        {
            cameraTwo.SetActive(true);
            c2.enabled = true;

            c1.enabled = false;
            cameraOne.SetActive(false);

            c3.enabled = false;
            cameraThree.SetActive(false);

            c4.enabled = false;
            cameraFour.SetActive(false);

            c5.enabled = false;
            cameraFive.SetActive(false);

            c6.enabled = false;
            cameraSix.SetActive(false);
        }

        if (camPosition == 3)
        {
            cameraThree.SetActive(true);
            c3.enabled = true;

            c1.enabled = false;
            cameraOne.SetActive(false);

            c2.enabled = false;
            cameraTwo.SetActive(false);

            c4.enabled = false;
            cameraFour.SetActive(false);

            c5.enabled = false;
            cameraFive.SetActive(false);

            c6.enabled = false;
            cameraSix.SetActive(false);
        }

        if (camPosition == 4)
        {
            cameraFour.SetActive(true);
            c4.enabled = true;

            c1.enabled = false;
            cameraOne.SetActive(false);

            c2.enabled = false;
            cameraTwo.SetActive(false);

            c3.enabled = false;
            cameraThree.SetActive(false);

            c5.enabled = false;
            cameraFive.SetActive(false);

            c6.enabled = false;
            cameraSix.SetActive(false);
        }

        if (camPosition == 5)
        {
            cameraFive.SetActive(true);
            c5.enabled = true;

            c1.enabled = false;
            cameraOne.SetActive(false);

            c2.enabled = false;
            cameraTwo.SetActive(false);

            c4.enabled = false;
            cameraFour.SetActive(false);

            c3.enabled = false;
            cameraThree.SetActive(false);

            c6.enabled = false;
            cameraSix.SetActive(false);
        }

        if (camPosition == 6)
        {
            cameraSix.SetActive(true);
            c6.enabled = true;

            c1.enabled = false;
            cameraOne.SetActive(false);

            c2.enabled = false;
            cameraTwo.SetActive(false);

            c4.enabled = false;
            cameraFour.SetActive(false);

            c5.enabled = false;
            cameraFive.SetActive(false);

            c3.enabled = false;
            cameraThree.SetActive(false);
        }
    }
}
