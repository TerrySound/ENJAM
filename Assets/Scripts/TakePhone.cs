using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhone : MonoBehaviour
{

    void Awake()
    {
        EventManager.OnPhone += Take;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Take()
    {
        Debug.Log("What time is it?");
    }
}
