using System;
using System.Collections;
using System.Net.Sockets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool possessed = false;
    public bool Possessed { get { return possessed; } set {  possessed = value; } }

    void Start()
    {

    }

    void Update()
    {
        if(true == possessed)
        {
            if(true == Input.GetKey(KeyCode.W))
                transform.Translate(transform.forward *  Time.deltaTime * 10f);

            SendToServer();
        }



    }

    void SendToServer()
    {
        while(true)
        {
            int offset = 0;
            byte[] message = new byte[4096];

            byte[] buffer0 = BitConverter.GetBytes(NetworkManager.Instance.ID);
            byte[] buffer1 = BitConverter.GetBytes(transform.position.x);
            byte[] buffer2 = BitConverter.GetBytes(transform.position.y);
            byte[] buffer3 = BitConverter.GetBytes(transform.position.z);

            Array.Copy(buffer0, 0, message, offset, buffer0.Length);
            offset += buffer0.Length;
            Array.Copy(buffer1, 0, message, offset, buffer1.Length);
            offset += buffer1.Length;
            Array.Copy(buffer2, 0, message, offset, buffer2.Length);
            offset += buffer2.Length;
            Array.Copy(buffer3, 0, message, offset, buffer3.Length);
            offset += buffer3.Length;

            Debug.Log($"<<--Send-->> {message.ToString()}");
            NetworkManager.Instance.SendAsync(message);
        }
    }
}
