using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    Rigidbody rig;
    public float MOVE_SPEED;
    public float BOOST_SPEED;
    public float CURVE_SPEED;
    public float MAX_SPEED;
    public float MAX_BOOST;
    Vector3 moveVector = new Vector3(0, 0, 2.0f);                  // 移動速度の入力
    

    private Hantei_kaisuu Play;

    public float HP;
    public float MAX_HP;

    public Drink drink;
    private int sumDrink = 1;

    public Drink drink2;
    private int speedDrink = 1;

    private bool RCflag = false;
    private bool LCflag = false;

    private float vel;
    public bool StopFlag = false;
    private Vector3 ppos;

    private float Seconds;
    public float r;
    public int CurveFlag = 0;

    float time = 0f;
    private bool speedup;

    // Start is called before the first frame update
    void Start()
    {
        speedup = false;    
        rig = GetComponent<Rigidbody>();
        this.HP = MAX_HP;
        vel = MOVE_SPEED;
        ppos = new Vector3(0, 0, 0);
        Seconds = 0.0f;

        Play = GameObject.Find("checkhantei").GetComponent<Hantei_kaisuu>();
    }

    // Update is called once per frame
    void Update()
    {     
        var pos = transform.position;
        var rot = transform.rotation;
        Seconds = Time.deltaTime;
        //transform.rotation = Quaternion.Euler(0, 30, 0);
        /*
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
        {
            if (rig.velocity.magnitude < MAX_BOOST) rig.AddForce(BOOST_SPEED * moveVector);
            this.HP -= 0.1f;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            if (rig.velocity.magnitude < MAX_SPEED) rig.AddForce(MOVE_SPEED * (new Vector3(0, 0, 1)));
            this.HP -= 0.05f;
        }
        */
        if (Play.Hanteikaisuu == 1)
        {
            MOVE_SPEED = 30;
            this.HP -= 0.2f;
        }

        Vector3 vecFront = transform.forward.normalized;
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift) && vel < MOVE_SPEED)
        {
            pos.x += (BOOST_SPEED - vel) * vecFront.x * Time.deltaTime;
            pos.y += (BOOST_SPEED - vel) * vecFront.y * Time.deltaTime;
            pos.z += (BOOST_SPEED - vel) * vecFront.z * Time.deltaTime;

            //pos += (BOOST_SPEED - vel) * vecFront * Time.deltaTime;
            this.HP -= 0.1f;
            
        }
        else if (Input.GetKey(KeyCode.Z))
        {
           
            pos.x += (MOVE_SPEED - vel) * vecFront.x * Time.deltaTime;
            pos.y += (MOVE_SPEED - vel) * vecFront.y * Time.deltaTime;
            pos.z += (MOVE_SPEED - vel) * vecFront.z * Time.deltaTime;
            //pos += (MOVE_SPEED - vel) * vecFront * Time.deltaTime;
            if (vel > 0)
            {
                vel -= 0.05f;
            }
            else if (vel < 0)
            {
                vel = 0.0f;
            }
        }            
        else if (Input.GetKeyUp(KeyCode.Z) && vel < MAX_SPEED)
        {
            StopFlag = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            vel += 0.05f;
        }

        if (StopFlag == true)
        {
            pos.x += (MOVE_SPEED - vel) * vecFront.x * Time.deltaTime;
            pos.y += (MOVE_SPEED - vel) * vecFront.y * Time.deltaTime;
            pos.z += (MOVE_SPEED - vel) * vecFront.z * Time.deltaTime;
            vel += 0.05f;
            if (vel > MOVE_SPEED)
            {
                vel = MOVE_SPEED;
                StopFlag = false;
            }
        }
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Rotate(new Vector3(0, 10 * Time.deltaTime, 0));
            //rot.y += CURVE_SPEED * Time.deltaTime;
            //moveVector = new Vector3(0.5f, 0, Mathf.Sqrt(3) / 2);
            //Debug.Log(rot.w);
            r += 1;
            CurveFlag = 1;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //rot.y = 0.0f;
            //moveVector = new Vector3(0, 0, 1.0f);
            CurveFlag = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Rotate(new Vector3(0, -10 * Time.deltaTime, 0));
            //rot.y -= CURVE_SPEED * Time.deltaTime;
            //moveVector = new Vector3(-0.5f, 0, Mathf.Sqrt(3) / 2);
            //Debug.Log(rot.w);
            r -= 1;
            CurveFlag = 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //rot.y = 0.0f;
            //moveVector = new Vector3(0, 0, 1.0f);
            CurveFlag = 0;
        }



        if (Input.GetKeyDown(KeyCode.X) && sumDrink > 0)
        {
            sumDrink--;
            drink.UpdateDrink(sumDrink);
            this.HP += MAX_HP / 6;
        }
        if (Input.GetKeyDown(KeyCode.S) && speedDrink > 0)
        {
            speedDrink--;
            drink2.UpdateDrink(speedDrink);
            speedup = true;
            time = 0;
        }
        if (speedup == true)
        {
            MOVE_SPEED = 25;
            time += Time.deltaTime;  
        }
        else if (speedup == false)
        {
            MOVE_SPEED = 15;
        }
        if (time>5f)
        {
            speedup = false;
        }
        Debug.Log(time);
//rot.w = 0.7f;
transform.position = pos;
        //transform.rotation = rot;
        transform.rotation = Quaternion.Euler(0, r, 0);

        ppos = pos;

    }
}
