using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeControl : MonoBehaviour
{
    Rigidbody rig;
    public float MOVE_SPEED;
    public float BOOST_SPEED;
    public float CURVE_SPEED;
    public float MAX_SPEED;
    public float MAX_BOOST;

    public float HP;
    public float MAX_HP;

    public Drink drink;
    private int sumDrink = 2;

    private bool RCflag = false;
    private bool LCflag = false;

    private float vel;
    private bool StopFlag = false;
    private Vector3 ppos;

    [Range(-1.0f, 1.0f)] public float Steering = 0.0f;
    [Range(-1.0f, 1.0f)] public float EngineTorqu = 0.0f;
    public float BreakTorqu = 0.0f;
    public float MaxAngle = 30.0f;
    public float MaxTorqu = 300.0f;
    public float MaxBreakTorqu = 200.0f;

    public WheelCollider FrontWheel_1;
    public WheelCollider FrontWheel_2;
    public WheelCollider RearWheel;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        this.HP = MAX_HP;
        vel = MOVE_SPEED;
        ppos = new Vector3(0, 0, 0);
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Steering > -1.0f)
        {
            Steering -= 0.01f; 
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Steering < 1.0f)
        {
            Steering += 0.01f;
        }
        float angleWheel = MaxAngle * Steering;
        FrontWheel_1.steerAngle = angleWheel;
        var rotate = FrontWheel_1.transform.localRotation;
        rotate = Quaternion.AngleAxis(angleWheel, Vector3.up);
        FrontWheel_1.transform.localRotation = rotate;

        FrontWheel_2.steerAngle = angleWheel;
        var rotate_2 = FrontWheel_2.transform.localRotation;

        rotate_2 = Quaternion.AngleAxis(angleWheel, Vector3.up);
        FrontWheel_2.transform.localRotation = rotate_2;
        
        float torqu = MaxTorqu * EngineTorqu;
        if (Input.GetKey(KeyCode.Z) && EngineTorqu < 1.0f)
        {
            EngineTorqu += 0.1f;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            StopFlag = true;
        }

        if (StopFlag == true)
        {
            if (EngineTorqu > 0) EngineTorqu -= 0.1f;
            else if (EngineTorqu < 0)
            {
                EngineTorqu = 0;
                StopFlag = false;
            }
        }

        float breakTorqu = MaxBreakTorqu * BreakTorqu;
        if (Input.GetKey(KeyCode.A))
        {
            FrontWheel_1.brakeTorque = breakTorqu;
        }
        if (Input.GetKey(KeyCode.S))
        {
            RearWheel.brakeTorque = breakTorqu;
        }
        FrontWheel_1.motorTorque = torqu;
        FrontWheel_2.motorTorque = torqu;
    }
    

    /*
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.leftWheel != null)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                }
                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            }

            if (axleInfo.rightWheel != null)
            {
                if (axleInfo.steering)
                {
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    axleInfo.rightWheel.motorTorque = motor;
                }
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }
        }
    }
    */
}

