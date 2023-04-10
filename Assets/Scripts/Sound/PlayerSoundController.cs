using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioClip runSound;  
    public AudioSource audioSource;  

    private void Start()
    {
        audioSource.clip = runSound;
        audioSource.loop = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            
            audioSource.Stop();
        }
    }
}
