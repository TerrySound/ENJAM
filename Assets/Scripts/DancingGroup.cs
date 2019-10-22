﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingGroup : PeopleGroup
{
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
        EventManager.OnInteract += Dance;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Interact").GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= Dance;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Interact").GetComponent<MeshRenderer>().enabled = false;
    }

    public void Dance()
    {
        Debug.Log("You got moves");
        playerAnimator.SetTrigger("isDancing");
        playerAnimator.gameObject.GetComponent<PlayerMovement>().dancing = true;
    }
}
