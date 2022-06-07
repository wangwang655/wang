using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //代表串行化
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
