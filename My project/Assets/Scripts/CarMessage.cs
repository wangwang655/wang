using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMessage : MonoBehaviour
{
    private string msg;
    public int type;
    public string order = "NULL";
    public GameObject carcam;
    public MessageClient mc;
    int Speed_move = 1;
    int Speed_rot = 45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        msg = mc.msgStr;
        turnRightOrLeft(msg);
        MoveUpOrBack(msg);
        CameraRotation(msg);
    }

    public void turnRightOrLeft(string msg)
    {
        if (msg == "TurnLeft")
        {
            this.transform.Rotate(Vector3.down * Time.deltaTime * Speed_rot);
        }
        else if (msg == "TurnRight")
        {
            this.transform.Rotate(Vector3.up * Time.deltaTime * Speed_rot);
        }
    }

    public void MoveUpOrBack(string msg)
    {
        if (msg == "Moveup")
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * Speed_move);
            Debug.Log("Ç°½ø");
        }
        else if (msg == "Moveback")
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * Speed_move);
        }
        else return;
    }

    public void CameraRotation(string msg)
    {
        if(msg == "OpenCamera")
        {
            carcam.SetActive(true);
        }
        if (msg == "rotateleft")
        {
            carcam.transform.Rotate(Vector3.down * Speed_rot);
        }
        else if (msg == "rotateright")
        {
            carcam.transform.Rotate(Vector3.up * Speed_rot);
        }
        else return;
    }

    public void valueReturn(string str)
    {
        msg = str;
    }

    public void chooseOrder(int a)
    {
        switch (a)
        {
            case 1:
                order = "Moveup";
                break;
            case 2:
                order = "Moveback";
                break;
            case 3:
                order = "TurnLeft";
                break;
            case 4:
                order = "TurnRight";
                break;
            case 5:
                order = "rotateleft";
                break;
            case 6:
                order = "rotateright";
                break;
            default:
                break;
        }
    }
}
