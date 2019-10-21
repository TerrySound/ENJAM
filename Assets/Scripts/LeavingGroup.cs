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
            this.transform.position -= new Vector3(0.015f, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.OnInteract += Leave;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= Leave;
    }

    public void Leave()
    {
        Debug.Log("To " + Mathf.Infinity + " and beyond");
        playerAnimator.SetTrigger("isDancing");
        this.leaving = true;
    }
}
