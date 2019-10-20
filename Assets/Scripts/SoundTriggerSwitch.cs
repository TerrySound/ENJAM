using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerSwitch : MonoBehaviour
{
    public string SwitchGroup;
    public string EnterSwitchState;
    public string ExitSwitchState;

    private void OnTriggerEnter2D (Collider2D other)
    {
        AkSoundEngine.SetSwitch(SwitchGroup, EnterSwitchState, gameObject);
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        AkSoundEngine.SetSwitch(SwitchGroup, ExitSwitchState, gameObject);
    }
}
