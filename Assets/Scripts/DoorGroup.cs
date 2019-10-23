using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroup : PeopleGroup
{
    bool DoOnce;
    public Collider2D blockingCollider;
    public GameObject porte;

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
        EventManager.OnPhone += OpenDoor;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("NoInteract").GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnPhone -= OpenDoor;
        GameObject.Find("E Button Interact").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("NoInteract").GetComponent<MeshRenderer>().enabled = false;
    }

    public void OpenDoor()
    {if (DoOnce == false) {
            Destroy(blockingCollider);
            //this.transform.position += new Vector3(0, 0.05f, 0.1f);
            AkSoundEngine.PostEvent("FX_Couple_Stop", this.gameObject);
            porte.GetComponent<Animator>().SetTrigger("porteOpen");
            DoOnce = true;

            if (!used)
            {
                desaturator.desaturateScreen();
                used = true;
            }
        }
    }
}
