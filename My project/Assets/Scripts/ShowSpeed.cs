using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ShowSpeed : MonoBehaviour
{
    public GameObject robot;
    Text text;

    void Start()
    {
        text = GameObject.Find("CameraChange/Canvas/Canvas/TextSpeed").GetComponent<Text>();
    }

    void Update()
    {
        string data = robot.GetComponent<Rigidbody>().velocity.magnitude.ToString();
        text.text = data;
    }
}