using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollector : MonoBehaviour
{

    public bool hasHeart;

    // Use this for initialization
    void Start()
    {
        hasHeart = false;
    }

    public void ReceiveHeart()
    {
        hasHeart = true;
    }
}