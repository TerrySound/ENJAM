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
        Debug.Log("enter");
    }
    private void OnTriggerExit2D (Collider2D other)
    {
        Debug.Log("Exit");
        AkSoundEngine.PostEvent(EventNameExit, gameObject);
    }
}