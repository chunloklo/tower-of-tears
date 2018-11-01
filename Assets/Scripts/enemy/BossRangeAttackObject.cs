using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRangeAttackObject : MonoBehaviour {
    public bool onPlayer;
    public float detonationTime;
    public float currTime;
    public int damage;
    public float pushBack;

    public GameObject player;
    public PlayerHealth ph;

    Transform warning;
    public float startAlpha;
    public float endAlpha;

    public float maxScale;

	// Use this for initialization
	void Start () {
        currTime = detonationTime;
        player = GameObject.FindGameObjectWithTag("Player");
        ph = player.GetComponent<PlayerHealth>();
        warning = gameObject.transform.GetChild(0);
        warning.localScale = new Vector3(maxScale, warning.localScale.y, maxScale);
    }
	
	// Update is called once per frame
	void Update () {
        currTime -= Time.deltaTime;
        if (currTime < 0)
        {
            Detonate();
        }

        float currScale = Mathf.Lerp(1, maxScale, currTime / detonationTime);
        warning.localScale = new Vector3(currScale, warning.localScale.y, currScale);
	}

    public void Detonate()
    {
        if (onPlayer)
        {
            ph.TakeDamage(damage);
            Vector3 offset = player.transform.position - gameObject.transform.position + new Vector3(0, 1, 0);
            player.GetComponent<Rigidbody>().velocity = offset.normalized * pushBack;
        }
        EventManager.TriggerEvent<BossRangeAttackEvent, Vector3>(gameObject.transform.position);
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onPlayer = false;
        }
    }


}
