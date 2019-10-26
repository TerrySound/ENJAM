using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingGroup : PeopleGroup
{
    
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
        this.phoneHour.text = "20:12";
        this.GetComponent<Animator>().SetTrigger("talkToGeraldine");

        AkSoundEngine.PostEvent("VO_Hey", this.gameObject);

        if (!used)
        {
            desaturator.desaturateScreen();
            used = true;
        }
    }
}
