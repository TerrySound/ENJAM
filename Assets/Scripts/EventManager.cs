using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void Interaction();
    public static event Interaction OnInteract;
    public delegate void PhoneInteraction();
    public static event PhoneInteraction OnPhone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
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
                if (OnInteract != null)
                {
                    OnInteract();
                }
            }            
        }
    }

    
}
