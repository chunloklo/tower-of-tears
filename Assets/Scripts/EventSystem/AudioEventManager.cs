using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public EventSound3D eventSound3DPrefab;
    
    public AudioClip bombBounceAudio;
    public AudioClip playerHurtAudio;
    public AudioClip checkpointActivateAudio;
    public AudioClip torchLightAudio;
    public AudioClip trapDisableAudio;

    private UnityAction<Vector3> bombBounceEventListener;
    private UnityAction<Vector3> playerHurtEventListener;
    private UnityAction<Vector3> checkpointActivateEventListener;
    private UnityAction<Vector3> torchLightEventListener;
    private UnityAction<Vector3> trapDisableEventListener;

    void Awake()
    {
        bombBounceEventListener = new UnityAction<Vector3>(bombBounceEventHandler);
        playerHurtEventListener = new UnityAction<Vector3>(playerHurtEventHandler);
        checkpointActivateEventListener = new UnityAction<Vector3>(checkpointActivateEventHandler);
        torchLightEventListener = new UnityAction<Vector3>(torchLightEventHandler);
        trapDisableEventListener = new UnityAction<Vector3>(trapDisableEventHandler);
    }


    // Use this for initialization
    void Start()
    {


        			
    }


    void OnEnable()
    {
        
        EventManager.StartListening<BombBounceEvent, Vector3>(bombBounceEventListener);
        EventManager.StartListening<PlayerHurtEvent, Vector3>(playerHurtEventListener);
        EventManager.StartListening<CheckpointActivateEvent, Vector3>(checkpointActivateEventListener);
        EventManager.StartListening<TorchLightEvent, Vector3>(torchLightEventListener);
        EventManager.StartListening<TorchLightEvent, Vector3>(trapDisableEventListener);

    }

    void OnDisable()
    {
        EventManager.StopListening<BombBounceEvent, Vector3>(bombBounceEventListener);
        EventManager.StopListening<PlayerHurtEvent, Vector3>(playerHurtEventListener);
        EventManager.StopListening<CheckpointActivateEvent, Vector3>(checkpointActivateEventListener);
        EventManager.StopListening<TorchLightEvent, Vector3>(torchLightEventListener);
        EventManager.StopListening<TorchLightEvent, Vector3>(trapDisableEventListener);
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

    void playerHurtEventHandler(Vector3 worldPos)
    {
        //AudioSource.PlayClipAtPoint(this.explosionAudio, worldPos, 1f);
        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.playerHurtAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }

    void checkpointActivateEventHandler(Vector3 worldPos)
    {
        //AudioSource.PlayClipAtPoint(this.explosionAudio, worldPos, 1f);
        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.checkpointActivateAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }

    void torchLightEventHandler(Vector3 worldPos)
    {
        //AudioSource.PlayClipAtPoint(this.explosionAudio, worldPos, 1f);
        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.torchLightAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }

    void trapDisableEventHandler(Vector3 worldPos)
    {
        //AudioSource.PlayClipAtPoint(this.explosionAudio, worldPos, 1f);
        if (eventSound3DPrefab)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, worldPos, Quaternion.identity, null);

            snd.audioSrc.clip = this.trapDisableAudio;

            snd.audioSrc.minDistance = 10f;
            snd.audioSrc.maxDistance = 500f;

            snd.audioSrc.Play();
        }
    }

}
