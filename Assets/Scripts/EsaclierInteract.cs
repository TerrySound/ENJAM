﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsaclierInteract : PeopleGroup
{
    public GameObject player;
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
        player.transform.position = new Vector3(8.3f, player.transform.position.y, player.transform.position.z);
       
    }
}
