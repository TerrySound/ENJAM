using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroup : PeopleGroup
{
    public Collider2D blockingCollider;
    public GameObject porte;

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
        EventManager.OnPhone += OpenDoor;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnPhone -= OpenDoor;
    }

    public void OpenDoor()
    {
        Destroy(blockingCollider);
        //this.transform.position += new Vector3(0, 0.05f, 0.1f);
        AkSoundEngine.PostEvent("FX_Couple_Stop", this.gameObject);
        porte.GetComponent<Animator>().SetTrigger("porteOpen");
    }
}
