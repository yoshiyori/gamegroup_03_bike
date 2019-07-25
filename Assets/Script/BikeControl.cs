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

    public Drink Drink2;
    private int speedDrink =  2;

    private bool RCflag = false;
    private bool LCflag = false;

    private float vel;
    private bool StopFlag = false;
    private Vector3 ppos;

    [Range(-1.0f, 1.0f)] public float Steering = 0.0f;
    [Range(-1.0f, 1.0f)] public float EngineTorqu = 0.0f;
    public float BreakTorqu = 0.0f;
    public float MaxAngle = 30.0f;
    public float MaxTorqu = 100.0f;
    public float MaxBreakTorqu = 200.0f;

    public WheelCollider FrontWheel;
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
        FrontWheel.steerAngle = angleWheel;
        var rotate = FrontWheel.transform.localRotation;
        rotate = Quaternion.AngleAxis(angleWheel, Vector3.up);
        FrontWheel.transform.localRotation = rotate;
        
        float torqu = MaxTorqu * EngineTorqu;
        if (Input.GetKey(KeyCode.Z))
        {
            EngineTorqu += 0.01f;
        }
       
        float breakTorqu = MaxBreakTorqu * BreakTorqu;
        if (Input.GetKey(KeyCode.A))
        {
            FrontWheel.brakeTorque = breakTorqu;
        }
        if (Input.GetKey(KeyCode.S))
        {
            RearWheel.brakeTorque = breakTorqu;
        }
        RearWheel.motorTorque = torqu;
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

