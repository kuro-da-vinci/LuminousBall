using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    //�{�[���̃^�O����p
    const string RedTag = "BallRed";
    const string BlueTag = "BallBlue";
    const string GreenTag = "BallGreen";
    const string LessTag = "Colorless";

    //���C�gON/OFF�p
    public GameObject RedLight;
    public GameObject BlueLight;
    public GameObject GreenLight;

    //�J���[�`�F���W�p
    public Material[] ColorMaterial;
    public int OffNum;
    string ChangeTag;
    Material ChangeColor;


    void OnTriggerEnter(Collider other)
    {
        //�z�[���ɓ������{�[���̃^�O�Ŕ���
        switch (other.gameObject.tag)
        {
            case RedTag:
                //���C�g�����݂���ꍇ
                if (RedLight != null)
                {
                    //�_�����̃��C�g��1�̏ꍇ
                    if (OffNum == 1)
                    {
                        //�{�[���𖳐F�ɕύX
                        other.GetComponent<Renderer>().material = ColorMaterial[0];
                        other.tag = LessTag;
                    }
                    else
                    {
                        //���C�g��ON/OFF�����s
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
                //�_�����̃��C�g��1�݂̂̏ꍇ
                if (OffNum == 1 || OffNum == 10 || OffNum == 100)
                {
                    //�{�[�����c�����C�g�̐F�ɕύX
                    other.GetComponent<Renderer>().material = ChangeColor;
                    other.tag = ChangeTag;
                }
                break;
        }
    }

    void LightSwitch(GameObject ColorLight, int Num)
    {
        //���C�g���A�N�e�B�u�Ȃ�ON�A����ȊO��OFF
        if (ColorLight.activeSelf)
        {
            //���C�g��OFF
            ColorLight.SetActive(false);
            //�c�����C�g����p
            OffNum -= Num;

            //�c�����C�g��1�̏ꍇ�A�ύX�p�̃}�e���A���A�^�O���擾
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
            //���C�g��ON
            ColorLight.SetActive(true);
            OffNum += Num;
        }
    }
}
