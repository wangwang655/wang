using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour {
    public GameObject rb1;
    public GameObject rb2;
    Transform target; 
    public float distance; 
    public float targetHeight; 
    public float PitchAngle; 
    private float x = 0.0f; 
    private float y = 0.0f; // Use this for initialization
    void Start () { 
        var angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }
    
    // Update is called once per frame
    void LateUpdate() {
        if (rb1.gameObject.activeSelf)
        {
            target = rb1.transform;
        }
        else if (rb2.gameObject.activeSelf)
        {
            target = rb2.transform;
        }
        if (!target) return; 
        y = target.eulerAngles.y; 
        // ROTATE CAMERA:
        Quaternion rotation = Quaternion.Euler(x - PitchAngle, y, 0); 
        transform.rotation = rotation; 
        // POSITION CAMERA:
        Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -targetHeight, 0)); 
        transform.position = position; 
    }
}