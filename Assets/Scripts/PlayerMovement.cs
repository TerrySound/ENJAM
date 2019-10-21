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

        this.transform.position += new Vector3(dir, 0, 0)*Time.unscaledDeltaTime*this.speed;
        return dir* Time.unscaledDeltaTime * this.speed;
    }

    void switchPhone()
    {
        phoneOut = !phoneOut;
        this.GetComponent<Animator>().SetBool("hasPhone", phoneOut);
        if (phoneOut)
        {
            EventManager.OnPhone += Ring;
        }
        else
        {
            EventManager.OnPhone -= Ring;
        }
        
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
