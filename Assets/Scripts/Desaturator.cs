using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Desaturator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Saturation on the last screen")]
    [Range(-100, 0)]
    public float minSaturation;

    [SerializeField]
    [Tooltip("Number of trigger events")]
    [Range(0, 10)]
    public int nbTriggers;

    [SerializeField]
    [Tooltip("Speed of the desaturation")]
    [Range(1,10)]
    public float speed;

    private float stepSaturation;
    private float t = 1;
    private float previousValue = 0;

    private ColorGrading colorGrading;

    // Start is called before the first frame update

    void Start()
    {
        stepSaturation = minSaturation / nbTriggers;
        GameObject.Find("PostProcessing").GetComponent<PostProcessVolume>().profile.TryGetSettings(out colorGrading);
    }

    // Update is called once per frame
    void Update()
    {
        if (t < 1f)
        {
            t += Time.deltaTime * speed;
            colorGrading.saturation.value = Mathf.Lerp(previousValue, Mathf.Max(previousValue + stepSaturation, -100), t);
            if (t >= 1f)
            {
                colorGrading.saturation.value = previousValue + stepSaturation;
                previousValue = colorGrading.saturation.value;
                Debug.Log("Désaturé");
            }
        }
    }

    public void desaturateScreen()
    {
        t = 0;
    }
}
