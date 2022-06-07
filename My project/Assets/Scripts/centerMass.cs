using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerMass : MonoBehaviour
{
    public Transform tf;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().centerOfMass = tf.localPosition;
    }
}
