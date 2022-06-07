using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MyServer : MonoBehaviour
{

    Socket socket = null;
    Thread thread = null;
    byte[] buffer = null;
    bool receState = true;

    int readTimes = 0;

    public RawImage rawImage;

    private Queue<byte[]> datas;

    void Start()
    {
        buffer = new byte[1024 * 1024 * 10];

        // ����������, ��Tcp�ķ�ʽ
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(IPAddress.Parse("127.0.0.1"), 10002);

        // ����һ���߳�, ���ڽ�������
        thread = new Thread(new ThreadStart(Receive));
        thread.Start();

        datas = new Queue<byte[]>();
    }

    private void Receive()
    {
        while (thread.ThreadState == ThreadState.Running && socket.Connected)
        {
            // ��������Buffer count�����ݵĳ���
            int count = socket.Receive(buffer);
            if (receState && count > 0)
            {
                receState = false;
                BytesToImage(count, buffer);
            }
        }
    }

    MemoryStream ms = null;
    public void BytesToImage(int count, byte[] bytes)
    {
        try
        {
            ms = new MemoryStream(bytes, 0, count);
            datas.Enqueue(ms.ToArray());    // �����ݴ洢��һ�������У������߳��н������ݡ�����һ�����̵߳Ĵ���

            readTimes++;

            if (readTimes > 5000)
            {
                readTimes = 0;
                GC.Collect(2);  // �ﵽһ��������ʱ�򣬿���GC���ͷ��ڴ�
            }
        }
        catch
        {

        }
        receState = true;
    }

    void Update()
    {
        if (datas.Count > 0)
        {
            // �����������ݣ�����ʾ
            Texture2D texture2D = new Texture2D(Screen.width, Screen.height);
            texture2D.LoadImage(datas.Dequeue());
            rawImage.texture = texture2D;
        }
    }

    void OnDestroy()
    {
        try
        {
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
            }
        }
        catch { }

        try
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }
        catch { }

        datas.Clear();
    }
}
