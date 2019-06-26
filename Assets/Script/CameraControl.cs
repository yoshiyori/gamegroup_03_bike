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
    private Vector3 otherDistant;
    private int otherRotation;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = player.transform.position;
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += player.transform.position - targetPos;
        otherDistant += player.transform.position - targetPos;
        targetPos = player.transform.position;
        //transform.position = player.transform.position + offset;
        if (Box.CurveFlag == 1)
        {
            transform.RotateAround(player.transform.position, Vector3.up, 1);
            //otherRotation += 1;
            //OtherCamera.transform.RotateAround(player.transform.position, Vector3.up, 1);
        }
        else if (Box.CurveFlag == 2)
        {
            transform.RotateAround(player.transform.position, Vector3.up, -1);
            //OtherCamera.transform.RotateAround(player.transform.position, Vector3.up, -1);
            //otherRotation -= 1;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //MainCamera.SetActive(!MainCamera.activeSelf);
            //OtherCamera.SetActive(!OtherCamera.activeSelf);

            camera.enabled = !camera.enabled;

            //OtherCamera.transform.position += otherDistant;
            //OtherCamera.transform.RotateAround(player.transform.position,Vector3.up,otherRotation);
        }

    }
}

