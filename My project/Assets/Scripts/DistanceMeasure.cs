using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DistanceMeasure : MonoBehaviour
{
    public float length = 0.0f;
    public Transform sposition;
    public Text input;
    Ray ray;
    RaycastHit hit;
    Vector3 v3 = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);
    Vector3 hitpoint = Vector3.zero;
    Text text;

    void Start()
    {
        text = GameObject.Find("CameraChange/Canvas/Canvas/Text").GetComponent<Text>();
    }
    
    void Update()
    {
        
        v3.x = v3.x >= Screen.width ? 0.0f : v3.x + 1.0f;

        ray = GetComponent<Camera>().ScreenPointToRay(v3);
        if (Physics.Raycast(ray, out hit, length))
        {
            Debug.Log("Hit" + hit.transform.name);
            string data = Vector3.Distance(hit.point, sposition.position).ToString();
            text.text = data;
        }
        else
        {
            text.text = "ÎÞÎïÌå";
        }
    }

    public void changeLen()
    {
        length = float.Parse(input.text);
    }
}
