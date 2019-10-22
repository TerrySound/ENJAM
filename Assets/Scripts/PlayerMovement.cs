using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    [Tooltip("The speed of the character")]
    private float speed = 5;
    public float actualSpeed;
    public static bool phoneOut = false;

    private GameObject entrance;
    private GameObject exit;
    private float halfWidth;

    void Awake()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        halfWidth = GetComponent<SpriteRenderer>().sprite.rect.width * 0.5f / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        halfWidth /= 2.2f; // without alpha
        entrance = GameObject.Find("entrance"); ;
        exit = GameObject.Find("exit");
        EsaclierInteract.OnTP += switchFloor;
    }

    // Update is called once per frame
    void Update()
    {
        /* To remove in the final version */
        if (Input.GetKeyDown(KeyCode.B))
        {
            foreach (GameObject o in FindObjectsOfType(typeof(GameObject)))
            {
                if (o.layer == LayerMask.NameToLayer("Barrier"))
                {
                    o.GetComponent<BoxCollider2D>().enabled =! o.GetComponent<BoxCollider2D>().enabled;
                }
            }
        }
        /*----------------------------------*/

        if (phoneOut && Input.GetKeyDown(KeyCode.E))    //Phone Ring Sound
        {
                Ring();
        }

        if (!phoneOut)
        {
            actualSpeed = this.movePlayer(Input.GetAxis("Horizontal")) * 100;
            AkSoundEngine.SetRTPCValue("RTPC_MC_Position", this.transform.position.x);
            this.GetComponent<Animator>().SetFloat("actualSpeed", actualSpeed);

            if (Input.GetKeyDown(KeyCode.R) && actualSpeed == 0f)
            {
                this.switchPhone();
                AkSoundEngine.PostEvent("FX_PhoneClock", this.gameObject);
            }
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                this.switchPhone();
                AkSoundEngine.PostEvent("FX_Feedback", this.gameObject);
            }
        }
    }

    float movePlayer(float dir)
    {
        if (transform.position.x - halfWidth <= entrance.transform.position.x && dir < 0) { return 0; }
        if (transform.position.x + halfWidth >= exit.transform.position.x && dir > 0) { return 0; }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * dir, Camera.main.orthographicSize * Camera.main.aspect, LayerMask.GetMask("Barrier"));
        if (hit.transform != null)
        {
            if (transform.position.x - halfWidth <= hit.transform.position.x + hit.collider.bounds.size.x && dir < 0) { return 0; }
            if (transform.position.x + halfWidth >= hit.transform.position.x && dir > 0) { return 0; }
        }

        this.transform.position += new Vector3(dir, 0, 0)*Time.unscaledDeltaTime*this.speed;
        return dir* Time.unscaledDeltaTime * this.speed;
    }
    void switchPhone()
    {
        if (phoneOut)
        {
            this.GetComponent<Animator>().SetBool("hasPhone", false);
            EventManager.OnPhone += Ring;
            GameObject.Find("E Button Ring").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Ring").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Turn off").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Time").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Phone").GetComponent<MeshRenderer>().enabled = true;
            // set phoneOut to false at the end of the animation, to forbid movement
            
        }
        else
        {
            this.GetComponent<Animator>().SetBool("hasPhone", true);
            EventManager.OnPhone -= Ring;
            GameObject.Find("E Button Ring").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Ring").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Turn off").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Time").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Phone").GetComponent<MeshRenderer>().enabled = false;
            phoneOut = true;
        }
    }
    void stowPhone()
    {
        Debug.Log("Téléphone rangé");
        phoneOut = false;
    }

    public void Ring()
    {
        AkSoundEngine.PostEvent("FX_Phone_Ring", this.gameObject);
    }

    void switchFloor()
    {
        entrance = GameObject.Find("entrance 1st floor");
        exit = GameObject.Find("exit 1st floor");
    }
}
