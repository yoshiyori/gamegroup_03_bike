using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderChange : MonoBehaviour
{
    public GameObject[] bikes;
    private int[] order = new int[3];
    public int changeFlag = 0;

    private int i = 0;
    MeshFilter[] mes = new MeshFilter[3];

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            order[i] = i;
        }

        mes[0] = bikes[0].GetComponent<MeshFilter>();
        
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) changeFlag = 1;

        if (Input.GetKeyDown(KeyCode.S)) changeFlag = 2;

        var pos = bikes[order[changeFlag]].transform.position;
        Vector3 vecSide = new Vector3(bikes[order[0]].transform.forward.normalized.x, bikes[order[0]].transform.forward.normalized.y, bikes[order[0]].transform.forward.normalized.z);

        if (changeFlag == 1)//真ん中が先頭に行く
        {
            if (i < 15) i += 2;
            bikes[order[1]].transform.LookAt(bikes[order[2]].transform);
            bikes[order[1]].transform.rotation = Quaternion.AngleAxis(-i, Vector3.up);

            pos += 5 * vecSide * Time.deltaTime;

        }
        if (changeFlag != 0) bikes[order[changeFlag]].transform.position = pos;

    }
}
