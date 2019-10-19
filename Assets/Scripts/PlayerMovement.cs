using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 100f)]
    [Tooltip("The speed of the character")]
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.movePlayer(Input.GetAxis("Horizontal"));
    }

    void movePlayer(float dir)
    {
        this.transform.position += new Vector3(dir, 0, 0)*Time.unscaledDeltaTime*this.speed;
    }
}
