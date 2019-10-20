using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 100f)]
    [Tooltip("The speed of the character")]
    private float speed = 5;

    void Awake()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.movePlayer(Input.GetAxis("Horizontal"));
        AkSoundEngine.SetRTPCValue("RTPC_MC_Position", this.transform.position.x);
    }

    void movePlayer(float dir)
    {
        this.transform.position += new Vector3(dir, 0, 0)*Time.unscaledDeltaTime*this.speed;
    }
}
