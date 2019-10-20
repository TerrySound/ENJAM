using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerEvent : MonoBehaviour
{
    public string EventNameEnter;
    public string EventNameExit;

    private void OnTriggerEnter2D (Collider2D Collider)
    { 
        AkSoundEngine.PostEvent(EventNameEnter, gameObject);
    }
    private void OnTriggerExit2D (Collider2D other)
    {
        AkSoundEngine.PostEvent(EventNameExit, gameObject);
    }
}