using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    [Tooltip("The game object to follow")]
    public GameObject character;

    private Vector3 originPosition = Vector3.zero;
    private bool isSwitchingMode = false;
    private float t = 0f;
    private float speed = 0.8f;

    private bool isScrolling = false;
    private Vector3 lastPosition = Vector3.zero;
    private bool isLeftLimit = false;
    private bool isRightLimit = false;

    [SerializeField]
    [Tooltip("The slack of the camera")]
    [Range(0,10)]
    public float slack = 0.5f;

    void Start()
    {
        if (character == null)
        {
            throw new System.ArgumentNullException("No character to follow");
        }
        // ensure the camera starts at the same height as the player
        transform.position = new Vector3(transform.position.x, character.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)) // Simulate trigger
        {
            originPosition = transform.position;
            isSwitchingMode = true;
        }

        if (isSwitchingMode)
        {
            t = Mathf.Min(t + Time.deltaTime * speed, 1f); // t in [0,1]
            float smoothstep = t * t * (3 - 2 * t);
            transform.position = Vector3.Lerp(originPosition, character.transform.position + Vector3.forward * originPosition.z, smoothstep);

            if (t == 1f)
            {
                isSwitchingMode = false;
                isScrolling = true;
            }
        }

        /* Slack of the camera */

        if (isScrolling)
        {
            float distanceToCharacter = character.transform.position.x - transform.position.x;
            float translationX = transform.position.x - lastPosition.x;
            if (!isRightLimit && distanceToCharacter >= slack)
            {
                transform.parent = character.transform;
                isRightLimit = true;
            }
            else if (!isLeftLimit && distanceToCharacter <= -slack)
            {
                transform.parent = character.transform;
                isLeftLimit = true;
            }
            else if (isRightLimit && translationX < 0)
            {
                transform.parent = null;
                isRightLimit = false;
            }
            else if (isLeftLimit && translationX > 0)
            {
                transform.parent = null;
                isLeftLimit = false;
            }
        }

        lastPosition = transform.position;
    }
}