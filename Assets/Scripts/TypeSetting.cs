using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSetting : MonoBehaviour
{
    //ボールとホールのサイズ設定
    public enum ObjectSize
    {
        SMALL,
        MEDIUM,
        LARGE,
    }

    public ObjectSize objectSize;
}
