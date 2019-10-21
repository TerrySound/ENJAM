using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumiliatingGroup : PeopleGroup
{
    public Collider2D blockingCollider;

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
        EventManager.OnInteract += Humiliate;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.OnInteract -= Humiliate;
    }

    public void Humiliate()
    {
        Destroy(blockingCollider);
        this.transform.position += new Vector3(0, 0.05f, 0.1f);
        AkSoundEngine.PostEvent("FX_Couple_Stop", this.gameObject);
        this.GetComponent<Animator>().SetTrigger("talkToGeraldine");
    }
}
