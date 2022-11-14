using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayAmount;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool alreadyCrashed = false;
   
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground" && !alreadyCrashed)
        {
            alreadyCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delayAmount);   
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);//Loads the first Zero
    }
}
