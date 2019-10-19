using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerAmbience : MonoBehaviour
{
    public string EventNameEnter;
    public string EventNameExit;
    private void OnTriggerEnter(Collider Collider)
    { 
        AkSoundEngine.PostEvent(EventNameEnter, gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        AkSoundEngine.PostEvent(EventNameExit, gameObject);
    }
}