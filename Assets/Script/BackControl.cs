using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class BackControl : MonoBehaviour
{

    public GameObject Flt;//前の奴
    Vector3 FrontTarget;
    public BoxControl Box;


    public float HP;

    void Start()
    {
        FrontTarget = Flt.transform.position;
        this.HP = 100.0f;
    }



    void Update()
    {
        transform.position += Flt.transform.position - FrontTarget;
        FrontTarget = Flt.transform.position;
        if (Box.CurveFlag == 1)
        {
            transform.RotateAround(Flt.transform.position, Vector3.up, 1);
        }
        else if (Box.CurveFlag == 2)
        {
            transform.RotateAround(Flt.transform.position, Vector3.up, -1);
        }

        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
        { 
            this.HP -= 0.05f;

        }
        else if (Input.GetKey(KeyCode.Z))
        {
            this.HP -= 0.01f;
        }

    }


}