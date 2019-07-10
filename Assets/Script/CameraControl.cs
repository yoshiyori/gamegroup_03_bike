using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    Vector3 targetPos;
    public BoxControl Box;
    public GameObject MainCamera;
    public GameObject OtherCamera;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += player.transform.position - targetPos;
        //OtherCamera.transform.position += player.transform.position - targetPos;
        targetPos = player.transform.position;
        //transform.position = player.transform.position + offset;
        if (Box.CurveFlag == 1)
        {
            transform.RotateAround(player.transform.position, Vector3.up, 1);
            //OtherCamera.transform.RotateAround(player.transform.position, Vector3.up, 1);
        }
        else if (Box.CurveFlag == 2)
        {
            transform.RotateAround(player.transform.position, Vector3.up, -1);
            //OtherCamera.transform.RotateAround(player.transform.position, Vector3.up, -1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            MainCamera.SetActive(!MainCamera.activeSelf);
            OtherCamera.SetActive(!OtherCamera.activeSelf);
        }
    }
}

