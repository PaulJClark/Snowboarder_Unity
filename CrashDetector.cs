using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    
    bool isCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Ground") && !isCrashed)
        {
            isCrashed = true;
            FindObjectOfType<PlayerController>().DisableMovement();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Debug.Log("You crashed!");
            Invoke("ReloadScene", crashDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
