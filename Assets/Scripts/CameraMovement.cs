﻿using System.Collections;
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

    private GameObject entrance = null;
    private GameObject exit = null;
    private bool isStickingEntrance = false;
    private bool isStickingExit = false;
    private float halfScreenWidth = 0f;
    private Vector3 stickingPosition = Vector3.zero;
    private float stickingSpeed = 5f;

    void Start()
    {
        entrance = GameObject.Find("entrance");
        exit = GameObject.Find("exit");
        if (entrance == null)
        {
            throw new System.ArgumentNullException("No entrance point");
        }
        if (exit == null)
        {
            throw new System.ArgumentNullException("No exit point");
        }
        if (exit.transform.position.x - entrance.transform.position.x < Camera.main.orthographicSize * Camera.main.aspect)
        {
            throw new System.ArgumentNullException("Entrance and exit points are too close to each other");
        }
        if (character == null)
        {
            throw new System.ArgumentNullException("No character to follow");
        }
        halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        // ensure the camera starts at the right place
        transform.position = new Vector3(-2.5f, 0.31f, -500f);
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.Return)) // Simulate trigger
            {
                originPosition = transform.position;
                isSwitchingMode = true;
                t = 0f;
            }

            if (isSwitchingMode)
            {
                t = Mathf.Min(t + Time.deltaTime * speed, 1f); // t in [0,1]
                float smoothstep = t * t * (3 - 2 * t);
                float targetX = Mathf.Max(character.transform.position.x, entrance.transform.position.x + halfScreenWidth);
                targetX = Mathf.Min(targetX, exit.transform.position.x - halfScreenWidth);
                Vector3 targetPosition = new Vector3(targetX, originPosition.y, originPosition.z);
                transform.position = Vector3.Lerp(originPosition, targetPosition, smoothstep);

                if (t == 1f)
                {
                    isSwitchingMode = false;
                    isScrolling = true;

                    /* Initial sticking */

                    if (character.transform.position.x - entrance.transform.position.x < halfScreenWidth)
                    {
                        isStickingEntrance = true;
                    }
                    else if (exit.transform.position.x - character.transform.position.x < halfScreenWidth)
                    {
                        isStickingExit = true;
                    }
                }
            }

            if (isScrolling)
            {
                if (stickingPosition != Vector3.zero)
                {
                Debug.Log("on se colle");
                    transform.position = stickingPosition;
                    t = Mathf.Min(t + Time.deltaTime * stickingSpeed, 1f); // t in [0,1]
                    transform.position = Vector3.Lerp(originPosition, stickingPosition, t);

                    if (t == 1f)
                    {
                        stickingPosition = Vector3.zero;
                    }
                }

                if (!isStickingExit && !isStickingEntrance)    /* Slack of the camera */
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

                    /* Stick to the borders of the world */

                    if (!isStickingEntrance && character.transform.position.x - entrance.transform.position.x <= halfScreenWidth)
                    {
                        transform.parent = null;
                        isStickingEntrance = true;
                        originPosition = transform.position;
                        t = 0f;
                        stickingPosition = new Vector3(entrance.transform.position.x + halfScreenWidth, transform.position.y, transform.position.z);
                    }
                    else if (!isStickingExit && exit.transform.position.x - character.transform.position.x <= halfScreenWidth)
                    {
                        transform.parent = null;
                        isStickingExit = true;
                        originPosition = transform.position;
                        t = 0f;
                        stickingPosition = new Vector3(exit.transform.position.x - halfScreenWidth, transform.position.y, transform.position.z); // will be updated the next update
                    }
                }
                else
                {
                    if (isStickingEntrance && character.transform.position.x - entrance.transform.position.x > halfScreenWidth)
                    {
                        transform.parent = character.transform;
                        isStickingEntrance = false;
                    }
                    else if (isStickingExit && exit.transform.position.x - character.transform.position.x > halfScreenWidth)
                    {
                        transform.parent = character.transform;
                        isStickingExit = false;
                    }
                }
            
        }
        lastPosition = transform.position;
    }

    void Warp()
    {
        transform.position = new Vector3(character.transform.position.x, transform.position.y, transform.position.z);

        /* Reload sticking */

        isStickingEntrance = false;
        isStickingExit = false;

        if (character.transform.position.x - entrance.transform.position.x < halfScreenWidth)
        {
            isStickingEntrance = true;
        }
        else if (exit.transform.position.x - character.transform.position.x < halfScreenWidth)
        {
            isStickingExit = true;
        }
    }
}