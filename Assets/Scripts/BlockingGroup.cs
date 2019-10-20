using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingGroup : PeopleGroup
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
        EventManager.OnInteract += Action;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= Action;
    }

    public void Action()
    {
        Debug.Log("What do you want?");
    }
}
