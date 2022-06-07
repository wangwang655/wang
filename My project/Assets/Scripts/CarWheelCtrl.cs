using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarWheelCtrl : MonoBehaviour
{
    //轮轴
    public List<AxleInfo> axleInfos;
    //马力和最大马力
    private float motor = 0;
    public float maxMotorTorque;
    //制动和最大制动
    private float brakeTorque = 0;
    public float maxBrakeTorque = 100;
    //转向角和最大转向角
    private float steering = 0;
    public float maxSteeringAngle;

    //开始时执行
    void Start()
    {

    }

    //每帧执行一次
    void Update()
    {

        //玩家控制操作
        PlayerCtrl();
        //遍历车轴
        foreach (AxleInfo axleInfo in axleInfos)
        {
            //转向
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            //马力
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            //制动
            if (true)
            {
                axleInfo.leftWheel.brakeTorque = brakeTorque;
                axleInfo.rightWheel.brakeTorque = brakeTorque;
            }
        }
    }

    public void PlayerCtrl()
    {
        //马力和转向角
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        //制动
        brakeTorque = 0;
        foreach (AxleInfo axlenInfo in axleInfos)
        {
            //前进时，按下“下”键
            if (axlenInfo.leftWheel.rpm > 5 && motor < 0)
                brakeTorque = maxBrakeTorque;
            //后退时，按下“上”键
            else if (axlenInfo.leftWheel.rpm < -5 && motor > 0)
                brakeTorque = maxBrakeTorque;
            continue;
        }
    }
}
