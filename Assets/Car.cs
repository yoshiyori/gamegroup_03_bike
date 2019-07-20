using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [Range(-1.0f, +1.0f)]
    public float Steering = 0.0f;

    [Range(-1.0f, 1.0f)]
    public float EngineTorqu = 0.0f;

    public float BreakTorqu = 0.0f;
    public float MaxAngle = 30.0f;
    public float MaxTorqu = 100.0f;
    public float MaxBreakTorqu = 200.0f;

    /// <summary>
    /// 駆動タイプ
    /// </summary>
    
    public enum eDriveType
    {
        [Tooltip ("前輪駆動")]
        Front,
        [Tooltip ("後輪駆動")]
        Rear,
        [Tooltip ("四輪駆動")]
        FrontRear,
    };

    public eDriveType DriveType;

    public WheelCollider[] FrontWheel;
    public WheelCollider[] RearWheel;

    void Start()
    {
        
    }

    void Update()
    {
        if (FrontWheel == null || FrontWheel.Length < 2
            || RearWheel == null || RearWheel.Length < 2)
        {
            return;
        }

        float angleWheel = MaxAngle * Steering;
        foreach (var wheel in FrontWheel) 
        {
            wheel.steerAngle = angleWheel;
            var rotate = wheel.transform.localRotation;
            rotate = Quaternion.AngleAxis(angleWheel, Vector3.up);
            wheel.transform.localRotation = rotate;
        }

        float torqu = MaxTorqu * EngineTorqu;
        switch (DriveType)
        {
            case eDriveType.Front:
                foreach (var wheel in FrontWheel)
                {
                    wheel.motorTorque = torqu;//モーターにトルク渡して回転
                }
                break;
            case eDriveType.Rear:
                foreach (var wheel in RearWheel)
                {
                    wheel.motorTorque = torqu;
                }
                break;
            case eDriveType.FrontRear:
                foreach (var wheel in FrontWheel)
                {
                    wheel.motorTorque = torqu;//モーターにトルク渡して回転
                }
                foreach (var wheel in RearWheel)
                {
                    wheel.motorTorque = torqu;//モーターにトルク渡して回転
                }
                break;
        }

        float breakTorqu = MaxBreakTorqu * BreakTorqu;

        foreach (var wheel in FrontWheel)
        {
            wheel.brakeTorque = breakTorqu;
        }
        foreach (var wheel in RearWheel)
        {
            wheel.brakeTorque = breakTorqu;
        }

        if (Input.GetKey(KeyCode.Z) && EngineTorqu < 0.9f)
        {
            EngineTorqu += 0.01f;
        }
        if (Input.GetKey(KeyCode.X))
        {
            EngineTorqu = 0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Steering > -1.0f)
        {
            Steering -= 0.05f;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Steering < 1.0f)
        {
            Steering += 0.05f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Steering = 0f;
        }
    }
}
