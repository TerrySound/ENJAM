using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsaclierInteract : PeopleGroup
{
    public GameObject player;
    public delegate void TeleportInteraction();
    public static event TeleportInteraction OnTP;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.OnInteract += SquallalaNousSommesPartis;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= SquallalaNousSommesPartis;
    }

    public void SquallalaNousSommesPartis()
    {
        //player.transform.position += new Vector3(0, 10,0);
        //player.transform.position += new Vector3(4.3f, player.transform.position.y, player.transform.position.z);
        player.transform.position += new Vector3(4.3f, 0f, 0f);
        if (EsaclierInteract.OnTP != null)
        {
            OnTP();
        }
        //player.transform.position -= new Vector3(0, 10, 0);

    }
}
