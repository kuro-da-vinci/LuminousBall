using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    //どのボールを吸い寄せるかをタグで判定
    public string targetTag;
    bool isHolding;

    //ボールが入っているかを返す
    public bool IsHolding()
    {
        return isHolding;
    }

    void OnTriggerEnter(Collider other)
    {
        //ホールに入ったボールのタグとサイズが一致した場合true
        if (other.gameObject.tag == targetTag 
            && other.gameObject.GetComponent<TypeSetting>().objectSize == this.GetComponent<TypeSetting>().objectSize)
        {
            isHolding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //ホールからボールが出た場合false
        if (other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }


    void OnTriggerStay(Collider other)
    {
        //コライダに触れているオブジェクトのRigidbodyコンポーネントを取得   
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        //タグに応じてボールに力を加える
        if (other.gameObject.tag == targetTag)
        {
            //中心地点でボールを止める為速度を減速させる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }
}
