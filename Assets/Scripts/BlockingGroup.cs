﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingGroup : PeopleGroup
{

    public Collider2D blockingCollider;

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
        EventManager.OnInteract += UnlockPath;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Interact").GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= UnlockPath;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Interact").GetComponent<MeshRenderer>().enabled = false;
    }

    public void UnlockPath()
    {
        Destroy(blockingCollider);
        //this.transform.position += new Vector3(0, 0.05f, 0.1f);
        Camera.main.GetComponent<CameraMovement>().followCharacter();
        //AkSoundEngine.PostEvent("FX_Couple_Stop", this.gameObject);
        this.GetComponent<Animator>().SetTrigger("talkToGeraldine");
    }
}
