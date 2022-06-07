using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    int speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCameraByInput();
    }

    public void RotateCameraByInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.down * speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * speed);
        }
    }

    public void RotateCameraInSpecialAngle()
    {
        
    }
}
