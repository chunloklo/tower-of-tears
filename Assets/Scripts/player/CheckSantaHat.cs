using UnityEngine;
using System.Collections;

public class CheckSantaHat : MonoBehaviour
{
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
           GameObject hat = GameObject.FindGameObjectsWithTag("Santa-Hat")[0];
            if (hat != null)
            {
                if (CrossSceneInformation.santaHat == true)
                {
                    hat.GetComponentInChildren<Renderer>().enabled = true;
                } else {
                    hat.GetComponentInChildren<Renderer>().enabled = false;
                }
            }
            else
            {
                Debug.Log("couldn't find hat reference");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
