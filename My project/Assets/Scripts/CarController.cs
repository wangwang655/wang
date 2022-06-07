using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float y;
    //车辆控制速度参数
    private float speedOne = 0f;    //车辆实时速度
    private float speedMax = 120f;  //车辆最大速度
    private float speedMin = -20f;  //车辆最小速度(倒车最大速度）
    private float speedUpA = 2f;    //车辆加速加速度（A键控制）
    private float speedDownS = 4f;  //车辆减速加速度（S键控制）
    private float speedTend = 0.5f; //无操作实时速度趋于0时加速度
    private float speedBack = 1f;   //车辆倒车加速度

    // Update is called once per frame
    void Update()
    {
        //按下W键并且速度没达到最大，则速度增加
        if (Input.GetKey(KeyCode.W) && speedOne < speedMax)
        {
            speedOne = speedOne + Time.deltaTime * speedUpA;
        }
        //按下S键并且速度没达到零，则速度减小
        if (Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedDownS;
        }
        //没有执行速度操作并且速度大于最小速度，则缓慢操作
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedTend;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne < 0f)
        {
            speedOne = speedOne + Time.deltaTime * speedTend;
        }

        
        if (Input.GetKey(KeyCode.S) && speedOne > speedMax && speedOne <= 0)
        {
            speedOne = speedOne - Time.deltaTime * speedBack;
        }

        transform.Translate(Vector3.forward * speedOne * Time.deltaTime);
        //使用A和D来控制物体左右旋转
        if (speedOne > 1f)
        {
            y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
            transform.Rotate(0, y, 0);
        }
    }
}


