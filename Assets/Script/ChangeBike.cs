using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBike : MonoBehaviour
{
    Rigidbody rig;
    public float MOVE_SPEED;
    public float BOOST_SPEED;
    public float CURVE_SPEED;
    public float MAX_SPEED;
    public float MAX_BOOST;
    Vector3 moveVector = new Vector3(0, 0, 2.0f);                  // 移動速度の入力


    public float HP;
    public float MAX_HP;

    public Drink drink;
    private int sumDrink = 2;

    private bool RCflag = false;
    private bool LCflag = false;

    private float vel;
    public bool StopFlag = false;
    private Vector3 ppos;

    private float r;
    public int CurveFlag = 0;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        this.HP = MAX_HP;
        vel = MOVE_SPEED;
        ppos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var rot = transform.rotation;
        // Start is called before the first frame update
        
    }
}