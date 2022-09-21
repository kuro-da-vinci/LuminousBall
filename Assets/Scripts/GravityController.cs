using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    //�d�͉����x
    const float Gravity = 9.81f;

    //�d�͂̓K�p�
    public float gravityScale = 1.0f;

    void Update()
    {
        //�d�̓x�N�g���̏�����
        Vector3 vector = new Vector3();

        //���o�C���[�����̑���
        if (Application.isMobilePlatform)
        {
            //�X���������x�Z���T���擾
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
            vector.y = Input.acceleration.z;
            
            //�����̓^�b�`�ł��L��
            if (Input.GetButton("Fire1"))
            {
                vector.y = 1.0f;
            }
        }
        else
        {
            //�f�o�b�O�F�L�[�̓��͂����m���x�N�g����ݒ�
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            //�f�o�b�O�F���������̔���̓L�[�̂��Ƃ���
            if (Input.GetButton("Fire1"))
            {
                vector.y = 1.0f;
            }
            else
            {
                vector.y = -1.0f;
            }

        }

        //�V�[���̏d�͂���̓x�N�g���̕����ɍ��킹�ĕω�������
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
