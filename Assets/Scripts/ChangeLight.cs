using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    //ボールのタグ判定用
    const string RedTag = "BallRed";
    const string BlueTag = "BallBlue";
    const string GreenTag = "BallGreen";
    const string LessTag = "Colorless";

    //ライトON/OFF用
    public GameObject RedLight;
    public GameObject BlueLight;
    public GameObject GreenLight;

    //カラーチェンジ用
    public Material[] ColorMaterial;
    public int OffNum;
    string ChangeTag;
    Material ChangeColor;


    void OnTriggerEnter(Collider other)
    {
        //ホールに入ったボールのタグで判定
        switch (other.gameObject.tag)
        {
            case RedTag:
                //ライトが存在する場合
                if (RedLight != null)
                {
                    //点灯中のライトが1つの場合
                    if (OffNum == 1)
                    {
                        //ボールを無色に変更
                        other.GetComponent<Renderer>().material = ColorMaterial[0];
                        other.tag = LessTag;
                    }
                    else
                    {
                        //ライトのON/OFFを実行
                        LightSwitch(RedLight, 1);
                    }
                }
                break;

            case BlueTag:
                if (BlueLight != null)
                {
                    if (OffNum == 10)
                    {
                        other.GetComponent<Renderer>().material = ColorMaterial[0];
                        other.tag = LessTag;
                    }
                    else
                    {
                        LightSwitch(BlueLight, 10);
                    }
                }
                break;

            case GreenTag:
                if (GreenLight != null)
                {
                    if (OffNum == 100)
                    {
                        other.GetComponent<Renderer>().material = ColorMaterial[0];
                        other.tag = LessTag;
                    }
                    else
                    {
                        LightSwitch(GreenLight, 100);
                    }
                }
                break;

            case LessTag:
                //点灯中のライトが1つのみの場合
                if (OffNum == 1 || OffNum == 10 || OffNum == 100)
                {
                    //ボールを残存ライトの色に変更
                    other.GetComponent<Renderer>().material = ChangeColor;
                    other.tag = ChangeTag;
                }
                break;
        }
    }

    void LightSwitch(GameObject ColorLight, int Num)
    {
        //ライトがアクティブならON、それ以外はOFF
        if (ColorLight.activeSelf)
        {
            //ライトをOFF
            ColorLight.SetActive(false);
            //残存ライト判定用
            OffNum -= Num;

            //残存ライトが1つの場合、変更用のマテリアル、タグを取得
            if (OffNum == 1)
            {
                ChangeColor = ColorMaterial[1];
                ChangeTag = RedTag;
            }
            else if (OffNum == 10)
            {
                ChangeColor = ColorMaterial[2];
                ChangeTag = BlueTag;
            }
            else if (OffNum == 100)
            {
                ChangeColor = ColorMaterial[3];
                ChangeTag = GreenTag;
            }
        }
        else
        {
            //ライトをON
            ColorLight.SetActive(true);
            OffNum += Num;
        }
    }
}
