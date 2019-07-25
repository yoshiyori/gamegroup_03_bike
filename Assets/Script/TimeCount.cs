using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    float countTime = 0;
    // Use this for initializati   
    
        // Start is called before the first frame update
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //プレイヤーが当たり判定に入った時の処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Goal！");
        }
    }
}