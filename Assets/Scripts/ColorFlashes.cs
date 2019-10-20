using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlashes : MonoBehaviour
{
    // Start is called before the first frame update
    float t = 0f;
    Color[] lights = { new Color(255f/255f, 0f, 139f / 255f), new Color(0f, 175f / 255f, 255f / 255f), new Color(129f / 255f, 0f, 255f / 255f), new Color(0f, 255f / 255f, 27f / 255f) };
    int index = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 60f / 130f)
        {
            //gameObject.GetComponent<Light>().color = Color.HSVToRGB(Random.Range(0f, 1f), 0.5f, 0.5f);
            gameObject.GetComponent<Light>().color = lights[index++];
            index %= lights.Length;
            t = 0f;
        }
    }
}
