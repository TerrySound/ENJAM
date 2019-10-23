using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingGroup : PeopleGroup
{

    bool leaving = false;
    public Collider2D blockingCollider;
    public GameObject otherDancer;

    private Desaturator desaturator;
    private bool used = false;

    // Start is called before the first frame update
    void Start()
    {
        desaturator = GameObject.Find("PostPross").GetComponent<Desaturator>();
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
        EventManager.canDance = false;
        this.phoneHour.text = "20h17";
        Debug.Log("To " + Mathf.Infinity + " and beyond");
        Destroy(blockingCollider);
        Destroy(this.GetComponent<BoxCollider2D>());
        playerAnimator.SetTrigger("isDancing");
        playerAnimator.gameObject.GetComponent<PlayerMovement>().dancing = true;
        this.leaving = true;

        if (!used)
        {
            desaturator.desaturateScreen();
            used = true;
        }
    }
}
