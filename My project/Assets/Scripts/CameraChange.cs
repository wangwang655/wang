using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject scene;
    bool camera2IsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        camera2.SetActive(false);
    }

    public void changeViewSensor()
    {
        if (!camera2IsOpen)
        {
            camera2.SetActive(true);
            camera2IsOpen = true;
            scene.SetActive(true);
        }
        else
        {
            camera2.SetActive(false);
            camera2IsOpen = false;
            scene.SetActive(false);
        }
    }
}
