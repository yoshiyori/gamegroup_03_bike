using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class speedhyouzi : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        // 対象の
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {

        // 1. 速度の取得の例
        // Aキーを推したら
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 速度ベクトルを表示
            Debug.Log("速度ベクトル: " + _rigidbody.velocity);

            // 速度を表示
            Debug.Log("速度: " + _rigidbody.velocity.magnitude);
        }
    }
    void OnGUI()
    {
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);

        GUIStyle style = new GUIStyle();
        style.fontSize = 10;
        style.fontStyle = FontStyle.Normal;
        style.normal.textColor = Color.white;
    }
}
