using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarWheelCtrl : MonoBehaviour
{
    //����
    public List<AxleInfo> axleInfos;
    //�������������
    private float motor = 0;
    public float maxMotorTorque;
    //�ƶ�������ƶ�
    private float brakeTorque = 0;
    public float maxBrakeTorque = 100;
    //ת��Ǻ����ת���
    private float steering = 0;
    public float maxSteeringAngle;

    //��ʼʱִ��
    void Start()
    {

    }

    //ÿִ֡��һ��
    void Update()
    {

        //��ҿ��Ʋ���
        PlayerCtrl();
        //��������
        foreach (AxleInfo axleInfo in axleInfos)
        {
            //ת��
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            //����
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            //�ƶ�
            if (true)
            {
                axleInfo.leftWheel.brakeTorque = brakeTorque;
                axleInfo.rightWheel.brakeTorque = brakeTorque;
            }
        }
    }

    public void PlayerCtrl()
    {
        //������ת���
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        //�ƶ�
        brakeTorque = 0;
        foreach (AxleInfo axlenInfo in axleInfos)
        {
            //ǰ��ʱ�����¡��¡���
            if (axlenInfo.leftWheel.rpm > 5 && motor < 0)
                brakeTorque = maxBrakeTorque;
            //����ʱ�����¡��ϡ���
            else if (axlenInfo.leftWheel.rpm < -5 && motor > 0)
                brakeTorque = maxBrakeTorque;
            continue;
        }
    }
}
