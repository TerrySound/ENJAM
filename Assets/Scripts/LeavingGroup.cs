using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingGroup : PeopleGroup
{

    bool leaving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leaving)
        {
            this.transform.position -= new Vector3(0.03f, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.OnInteract += UnlockPath;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= UnlockPath;
    }

    public void UnlockPath()
    {
        Debug.Log("To " + Mathf.Infinity + " and beyond");
        this.leaving = true;
    }
}
