using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public EventSound3D eventSound3DPrefab;
    
    public AudioClip bombBounceAudio;

    private UnityAction<Vector3> bombBounceEventListener;

    void Awake()
    {
        bombBounceEventListener = new UnityAction<Vector3>(bombBounceEventHandler);
    }


    // Use this for initialization
    void Start()
    {


        			
    }


    void OnEnable()
    {
        
        EventManager.StartListening<BombBounceEvent, Vector3>(bombBounceEventListener);

    }

    void OnDisable()
    {
        EventManager.StopListening<BombBounceEvent, Vector3>(bombBounceEventListener);
    }

    
    void bombBounceEventHandler(Vector3 worldPos)
    {
        //AudioSource.PlayClipAtPoint(this.explosionAudio, worldPos, 1f);

        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.bombBounceAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }
}
