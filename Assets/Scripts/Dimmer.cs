using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimmer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject shutterLeft;
    public GameObject shutterRight;
    private SpriteRenderer spriteLeft;
    private SpriteRenderer spriteRight;
    private float width;

    [SerializeField]
    [Tooltip("Opacity when the room is dark")]
    [Range(0,255)]
    public float opacity;
    private float maxOpacity;

    [SerializeField]
    [Tooltip("If set to higher than 0, the light start to fade out before exiting the room")]
    [Range(0,0.5f)]
    public float extension;

    [SerializeField]
    [Tooltip("Curve of the light when entering the room")]
    public AnimationCurve curveIn = new AnimationCurve(new Keyframe(0,0), new Keyframe(1,1));


    [SerializeField]
    [Tooltip("Curve of the light when exiting the room")]
    public AnimationCurve curveOut = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

    void Start()
    {
        player = GameObject.Find("Perso");
        width = GetComponent<BoxCollider2D>().bounds.size.x;

        spriteLeft = shutterLeft.GetComponent<SpriteRenderer>();
        spriteRight = shutterRight.GetComponent<SpriteRenderer>();

        maxOpacity = opacity / 255f;
        spriteRight.color = new Color(1, 1, 1, maxOpacity);
    }

    // Update is called once per frame
    void Update()
    {
        float startX = transform.position.x - extension;
        float endX   = transform.position.x + width + extension;

        if (player.transform.position.x >= startX && player.transform.position.x <= endX)
        {
            float dimFactor = Mathf.Clamp((player.transform.position.x - startX) / (endX - startX), 0, 1);
            //float smoothstep = dimFactor * dimFactor * (3 - 2 * dimFactor);
            float smoothstep1 = Mathf.Pow(dimFactor, 1f/10f);
            float smoothstep2 = Mathf.Pow(dimFactor, -1f/10f);

            spriteLeft.color  = new Color(spriteLeft.color.r, spriteLeft.color.g, spriteLeft.color.b, curveIn.Evaluate(dimFactor) * maxOpacity);
            spriteRight.color = new Color(spriteLeft.color.r, spriteLeft.color.g, spriteLeft.color.b, curveOut.Evaluate(dimFactor) * maxOpacity);
        }
    }
}
