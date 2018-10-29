using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 30;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
//    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
//    AudioSource playerAudio;
    PlayerMovement playerMovement;
//    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

    SkinnedMeshRenderer sk;
    Color originalColor;

    public float playerInvulTime = 1.0f;
    public float playerInvulRemaining;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
//        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
//        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;

        sk = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>()[0];
        originalColor = sk.material.color;
    }


    void Update ()
    {
        if (playerInvulRemaining > 0)
        {
            playerInvulRemaining -= Time.deltaTime;
            sk.material.color = flashColour;
        } else
        {
            sk.material.color = originalColor;//Color.Lerp(originalColor, sk.material.color, playerInvulRemaining);
        }
    }


    public void TakeDamage (int amount)
    {

        if (playerInvulRemaining > 0)
        {
            return;
        }
        EventManager.TriggerEvent<PlayerHurtEvent, Vector3>(gameObject.transform.position);

        damaged = true;

        currentHealth -= amount;

//        healthSlider.value = currentHealth;

//        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }

        playerInvulRemaining = playerInvulTime;
    }

    public void ReceiveHealth(int amount)
    {

        currentHealth += amount;

        if (currentHealth > 30)
        {
            damaged = false;
            currentHealth = 30;
        }

        //        healthSlider.value = currentHealth;

        //        playerAudio.Play ();
    }


    void Death ()
    {
        isDead = true;

//        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

//        playerAudio.clip = deathClip;
//        playerAudio.Play ();

        //playerMovement.enabled = false;
        //        playerShooting.enabled = false;

        Debug.Log("PLAYER HAS DIED");
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
