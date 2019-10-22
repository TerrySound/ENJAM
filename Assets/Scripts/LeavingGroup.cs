using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingGroup : PeopleGroup
{

    bool leaving = false;
    public Collider2D blockingCollider;
    public GameObject otherDancer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leaving)
        {
            this.transform.position -= new Vector3(0.005f, 0, 0);
            otherDancer.transform.position -= new Vector3(0.005f, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.OnInteract += Leave;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Interact").GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= Leave;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Interact").GetComponent<MeshRenderer>().enabled = false;
    }

    public void Leave()
    {
        Debug.Log("To " + Mathf.Infinity + " and beyond");
        Destroy(blockingCollider);
        playerAnimator.SetTrigger("isDancing");
        this.leaving = true;
    }
}
