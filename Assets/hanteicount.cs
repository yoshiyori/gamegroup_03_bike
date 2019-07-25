using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hanteicount : MonoBehaviour
{
    // Start is called before the first frame update
    private Hantei_kaisuu kaisuu;

    // Start is called before the first frame update
    void Start()
    {
        kaisuu = GameObject.Find("checkhantei").GetComponent<Hantei_kaisuu>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider shoutotu)
    {
        if (shoutotu.gameObject.name == "Bike_body")
        {
            kaisuu.Hanteikaisuu++;

        }
    }
}


