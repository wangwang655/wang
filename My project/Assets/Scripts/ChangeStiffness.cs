using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStiffness : MonoBehaviour
{
    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    public GameObject w4;
    public Text inputfield;
    public Text showfield;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        showfield.text = w1.GetComponent<WheelCollider>().wheelDampingRate.ToString();
    }

    public void ChangeWheelDampingRate()
    {
        w1.GetComponent<WheelCollider>().wheelDampingRate = float.Parse(inputfield.text);
        w2.GetComponent<WheelCollider>().wheelDampingRate = float.Parse(inputfield.text);
        w3.GetComponent<WheelCollider>().wheelDampingRate = float.Parse(inputfield.text);
        w4.GetComponent<WheelCollider>().wheelDampingRate = float.Parse(inputfield.text);
    }
}
