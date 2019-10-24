using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class EndScript : MonoBehaviour
{
    public GameObject fade;
    public float timer = 2f;
    private bool once=false;
    public Canvas credits;
    public TextMeshPro phoneHour;
    private bool end = false;
    private float creditsTimer = 2f;
    bool DoOnce = true;
    

    // Start is called before the first frame update
    void Start()
    {
        credits.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {

                if (!once)
                {
                    once = true;
                    fade.SetActive(true);

                    Debug.Log("bla");
                }
                creditsTimer -= Time.deltaTime;
                if(creditsTimer < 0)
                {
                    credits.enabled = true;
                }
            }
            int hour = Mathf.RoundToInt(Random.Range(0f, 23f));
            int min = Mathf.RoundToInt(Random.Range(0f, 59f));
            this.phoneHour.text = hour + ":" + min;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.OnEnd += End;
        EventManager.end = true;
    }

    void End()
    {
        end = true;
        if (DoOnce == true){
            AkSoundEngine.PostEvent("End_Game", this.gameObject);
            DoOnce = false;
        }
    }
}
