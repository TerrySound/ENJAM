using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

    public delegate void Interaction();
    public static event Interaction OnInteract;
    public delegate void PhoneInteraction();
    public static event PhoneInteraction OnPhone;
    public delegate void TeleportInteraction();
    public static event TeleportInteraction OnTP;
    public static event Interaction OnEnd;
    public static bool canDance = true;
    public static bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerMovement.phoneOut)
            {
                if (EventManager.OnPhone != null)
                {
                    OnPhone();
                }
            }
            else
            {
                if (OnInteract != null && PlayerMovement.actualSpeed == 0)
                {
                    OnInteract();
                }
            }            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (end)
            {
                if(OnEnd != null)
                {
                    OnEnd();
                }
            }
        }
    }

    
}
