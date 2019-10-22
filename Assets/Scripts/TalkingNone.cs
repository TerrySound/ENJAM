using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingNone : PeopleGroup
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
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("NoInteract").GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("NoInteract").GetComponent<MeshRenderer>().enabled = false;
    }


}
