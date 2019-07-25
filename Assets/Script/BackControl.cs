using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class BackControl : MonoBehaviour
{

    public GameObject Flt;//前の奴
    Vector3 FrontTarget;
    public BoxControl Box;
    private float vel;

    public GameObject Bike_box;
    public GameObject Bike_box2;
    public GameObject Bike_box3;

    public float HP;

    void Start()
    {
        FrontTarget = Flt.transform.position;
        this.HP = Box.MAX_HP;
        vel = Box.MOVE_SPEED;
        Bike_box.transform.parent = Bike_box2.transform; // 変更
        Bike_box.transform.parent = Bike_box3.transform; // 変更


    }



    void Update()
    {
        var pos = transform.position;
        /*
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
        */
        this.transform.LookAt(Flt.transform);
        Vector3 vecFront = transform.forward.normalized;
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift) && vel < Box.MOVE_SPEED)
        {
            //pos.x += (BOOST_SPEED - vel) * vecFront.x * Time.deltaTime;
            //pos.y += (BOOST_SPEED - vel) * vecFront.y * Time.deltaTime;
            //pos.z += (BOOST_SPEED - vel) * vecFront.z * Time.deltaTime;

            pos += (Box.BOOST_SPEED - vel) * vecFront * Time.deltaTime;
            this.HP -= 0.05f;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            this.HP -= 0.01f;
            //pos.x += (Box.MOVE_SPEED - vel) * vecFront.x * Time.deltaTime;
            //pos.y += (Box.MOVE_SPEED - vel) * vecFront.y * Time.deltaTime;
            //pos.z += (Box.MOVE_SPEED - vel) * vecFront.z * Time.deltaTime;
            pos += (Box.MOVE_SPEED - vel) * vecFront * Time.deltaTime;
            if (vel > 0)
            {
                vel -= 0.05f;
            }
            else if (vel < 0)
            {
                vel = 0.0f;
            }
        }

        if (Box.StopFlag == true)
        {
            pos.x += (Box.MOVE_SPEED - vel) * vecFront.x * Time.deltaTime;
            pos.y += (Box.MOVE_SPEED - vel) * vecFront.y * Time.deltaTime;
            pos.z += (Box.MOVE_SPEED - vel) * vecFront.z * Time.deltaTime;
            vel += 0.05f;
            if (vel > Box.MOVE_SPEED)
            {
                vel = Box.MOVE_SPEED;
            }
            if(this.HP <= 0)
                {
                vel += 0.05f;
            }
        

        }


        transform.position = pos;
    }


}