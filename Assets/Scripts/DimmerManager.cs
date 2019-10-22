using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float maxOpacity = 200f / 255f;
        SpriteRenderer spriteR;
        spriteR = GameObject.Find("ShutterRoom1").GetComponent<SpriteRenderer>();
        spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b, 0);
        spriteR = GameObject.Find("ShutterRoom2").GetComponent<SpriteRenderer>();
        spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b, maxOpacity);
        spriteR = GameObject.Find("ShutterRoom3").GetComponent<SpriteRenderer>();
        spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b, maxOpacity);
        spriteR = GameObject.Find("ShutterRoom4").GetComponent<SpriteRenderer>();
        spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b, 0);
        spriteR = GameObject.Find("ShutterRoom5").GetComponent<SpriteRenderer>();
        spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b, maxOpacity);
        spriteR = GameObject.Find("ShutterRoom6").GetComponent<SpriteRenderer>();
        spriteR.color = new Color(spriteR.color.r, spriteR.color.g, spriteR.color.b, maxOpacity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
