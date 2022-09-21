using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    //重力加速度
    const float Gravity = 9.81f;

    //重力の適用具合
    public float gravityScale = 1.0f;

    void Update()
    {
        //重力ベクトルの初期化
        Vector3 vector = new Vector3();

        //モバイル端末時の操作
        if (Application.isMobilePlatform)
        {
            //傾きを加速度センサより取得
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
            vector.y = Input.acceleration.z;
            
            //高さはタッチでも有効
            if (Input.GetButton("Fire1"))
            {
                vector.y = 1.0f;
            }
        }
        else
        {
            //デバッグ：キーの入力を検知しベクトルを設定
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            //デバッグ：高さ方向の判定はキーのｚとする
            if (Input.GetButton("Fire1"))
            {
                vector.y = 1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }

        }

        //シーンの重力を入力ベクトルの方向に合わせて変化させる
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
