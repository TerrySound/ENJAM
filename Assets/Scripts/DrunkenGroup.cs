using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkenGroup : PeopleGroup
{
    // Start is called before the first frame update
    public Collider2D blockingCollider;

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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.OnInteract += UnlockPathDrunk;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Interact").GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= UnlockPathDrunk;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Interact").GetComponent<MeshRenderer>().enabled = false;
    }

    public void UnlockPathDrunk()
    {
        blockingCollider.enabled = true;
        Destroy(blockingCollider);
        Destroy(this.GetComponent<BoxCollider2D>());
        this.transform.position += new Vector3(0, 0.05f, 0.1f);
        AkSoundEngine.PostEvent("FX_Rot", this.gameObject);

        if (!used)
        {
            desaturator.desaturateScreen();
            this.used = true;
        }
    }
}
