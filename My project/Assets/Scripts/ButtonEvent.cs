using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public GameObject robot1;
    public GameObject startpoint;
    public GameObject TextInfo;
    public static int typeNum;
    GameObject controlRobot;
    Vector3 position;
    Quaternion rotation;
    bool isOpened = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void jumpStart()
    {
        SceneManager.LoadScene(2);
        SceneManager.LoadScene(3, new LoadSceneParameters(LoadSceneMode.Additive));
    }

    public void jumpConnect()
    {
        SceneManager.LoadScene(1);
    }

    public void createConnect()
    {
        GameObject server = GameObject.Find("Server");
        server.SetActive(true);
    }

    public void jumpQuit()
    {
        Application.Quit();
    }

    void Start()
    {
        position = robot1.transform.position;
        rotation = robot1.transform.rotation;
        controlRobot = robot1;
        typeNum = 1;
    }

    public void ResetPosition()
    {
        robot1.transform.position = startpoint.transform.position;
        robot1.transform.rotation = startpoint.transform.rotation;
        
        Debug.Log("reset");
    }

    public static int returnType()
    {
        if (typeNum == 1)
        {
            return 1;
        }
        else return 0;
    }

    public void ShowInfo()
    {
        if (isOpened)
        {
            TextInfo.SetActive(false);
            isOpened = false;
        }
        else
        {
            TextInfo.SetActive(true);
            isOpened = true;
        }
    }

    public void OpenNavigation()
    {
        robot1.GetComponent<NavMeshAgent>().enabled = true;
        robot1.GetComponent<NavigationScript>().enabled = true;
    }
}
