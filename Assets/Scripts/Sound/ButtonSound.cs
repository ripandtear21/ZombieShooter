using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
