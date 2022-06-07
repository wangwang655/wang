using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;//����socket�����ռ�
using System.Threading;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MessageClient : MonoBehaviour
{
    //�����ı�
    public string frontMsg;
    public string backMsg;
    public Text ftext;
    public Text btext;
    public string msgStr;
    public GameObject rb;
    //��Ϣ�б�
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
            Debug.Log("���ӳɹ�");
            //�����̣߳�ִ�ж�ȡ��������Ϣ
            Thread c_thread = new Thread(Received);
            c_thread.IsBackground = true;
            c_thread.Start();
        }
        catch (System.Exception)
        {

            Debug.Log("IP�˿ںŴ�����߷�����δ����");
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
                Debug.Log("�ͻ��˴�ӡ������������Ϣ��" + socket_client.RemoteEndPoint + ":" + str);
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

            Debug.Log("δ����");
        }
    }

    public void close()
    {
        try
        {
            socket_client.Close();
            Debug.Log("�رտͻ�������");
        }
        catch (System.Exception)
        {
            Debug.Log("δ����");
        }
    }

    
}