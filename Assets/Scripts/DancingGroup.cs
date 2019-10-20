using System.Collections;
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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= Dance;
    }

    public void Dance()
    {
        Debug.Log("You got moves");
    }
}
