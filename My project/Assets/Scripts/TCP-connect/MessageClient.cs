using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;//引入socket命名空间
using System.Threading;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MessageClient : MonoBehaviour
{
    //输入文本
    public string frontMsg;
    public string backMsg;
    public Text ftext;
    public Text btext;
    public string msgStr;
    public GameObject rb;
    //消息列表
    static List<string> msgList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frontMsg = ftext.text;
        backMsg = btext.text;
        Send(frontMsg);
        Send(backMsg);
        if (msgList.Count <= 0)
        {
            return;
        }
        msgStr = msgList[0];
        msgList.RemoveAt(0);
    }

    Socket socket_client;
    public void ConnectServer()
    {
        try
        {
            IPAddress pAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint pEndPoint = new IPEndPoint(pAddress, 8080);
            socket_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket_client.Connect(pEndPoint);
            Debug.Log("连接成功");
            //创建线程，执行读取服务器消息
            Thread c_thread = new Thread(Received);
            c_thread.IsBackground = true;
            c_thread.Start();
        }
        catch (System.Exception)
        {

            Debug.Log("IP端口号错误或者服务器未开启");
        }
    }

    public void Received()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int len = socket_client.Receive(buffer);
                if (len == 0) break;
                string str = Encoding.UTF8.GetString(buffer, 0, len);
                Debug.Log("客户端打印服务器返回消息：" + socket_client.RemoteEndPoint + ":" + str);
                msgList.Add(str);
                //rb.GetComponent<CarMessage>().SendMessage("turnRightOrLeft", str);
                //rb.GetComponent<CarMessage>().SendMessage("MoveUpOrBack", str);
                //rb.GetComponent<CarMessage>().SendMessage("CameraRotation", str);
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }

    public void Send(string msg)
    {
        try
        {
            byte[] buffer = new byte[1024];
            buffer = Encoding.UTF8.GetBytes(msg);
            socket_client.Send(buffer);
        }
        catch (System.Exception)
        {

            Debug.Log("未连接");
        }
    }

    public void close()
    {
        try
        {
            socket_client.Close();
            Debug.Log("关闭客户端连接");
        }
        catch (System.Exception)
        {
            Debug.Log("未连接");
        }
    }

    
}