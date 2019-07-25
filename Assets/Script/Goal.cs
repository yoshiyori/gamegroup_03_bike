using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    GameObject objGoal;

    void Start()
    {
        this.objGoal = GameObject.Find("TextGoal");
        objGoal.GetComponent<Text>().enabled = true;

    }

   void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.tag == "Player")
            {
            objGoal.GetComponent<Text>().enabled = true;
        }
            
        }
    }
