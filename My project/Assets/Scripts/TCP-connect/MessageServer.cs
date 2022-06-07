using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;//需要引用socket命名空间
using System.Net;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine.UI;

public class MessageServer : MonoBehaviour
{
    public Text ftext;
    public Text btext;
    string msg;
    int i;
    static List<string> msgList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        openServer();
    }

    // Update is called once per frame
    void Update()
    {
        if (msgList.Count <= 0)
        {
            return;
        }
        ftext.text = msgList[0];
        msgList.RemoveAt(0);
        btext.text = msgList[0];
        msgList.RemoveAt(0);
    }

    void openServer()
    {
        try
        {
            IPAddress pAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint pEndPoint = new IPEndPoint(pAddress, 8080);
            Socket socket_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket_server.Bind(pEndPoint);
            socket_server.Listen(5);//设置最大连接数
            Debug.Log("监听成功");
            //创建新线程执行监听，否则会阻塞UI，导致unity无响应
            Thread thread = new Thread(listen);
            thread.IsBackground = true;
            thread.Start(socket_server);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    Socket socketSend;
    void listen(object o)
    {
        try
        {
            Socket socketWatch = o as Socket;
            while (true)
            {
                socketSend = socketWatch.Accept();
                Debug.Log(socketSend.RemoteEndPoint.ToString() + ":" + "连接成功");

                Thread r_thread = new Thread(Received);
                r_thread.IsBackground = true;
                r_thread.Start(socketSend);
            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void Received(object o)
    {
        try
        {
            Socket socketSend = o as Socket;
            while (true)
            {
                byte[] buffer = new byte[1024];
                int len = socketSend.Receive(buffer);
                if (len == 0) break;
                string str = Encoding.UTF8.GetString(buffer, 0, len);
                Debug.Log("服务器打印客户端返回消息：" + socketSend.RemoteEndPoint + ":" + str);
                msgList.Add(str);
                //if (i == 1)
                //{
                //    ftext.text = str;
                //    i = 0;
                //}
                //else if (i == 0)
                //{
                //    btext.text = str;
                //    i = 1;
                //}
            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void Send(string msg)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(msg);
        socketSend.Send(buffer);
    }
}