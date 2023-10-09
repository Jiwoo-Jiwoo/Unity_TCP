using System.Net;
using UnityEngine;

using ServerCore;
using Protocol;

public class NetworkManager
{
    #region Singleton
    static private NetworkManager instance;
    static public NetworkManager Instance
    {
        get
        {
            if (instance is null)
                instance = new NetworkManager();

            return instance;
        }
    }
    #endregion

    ClientSocket socket;
    public int ID => socket.ID;
    public bool IsConnected => socket.IsConnected;

    NetworkManager()
    {
        string host = Dns.GetHostName();
        IPHostEntry ipHostEntry = Dns.GetHostEntry(host);
        IPAddress ipAddress = ipHostEntry.AddressList[0];
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8000);

        socket = new ClientSocket(ipEndPoint);
        socket.OnReceived += Parse;
    }

    public void ConnectAsync(IPEndPoint ipEndPoint)
    {
        Debug.Log("<<--| ConnectAsync |-->>");

        socket.ConnectAsync(ipEndPoint);
    }

    public void SendAsync(byte[] buffer)
    {
        Debug.Log("<<--| SendAsync |-->>");

        socket.SendAsync(buffer);
    }

    public void Close()
    {
        Debug.Log("<<--| Close |-->>");

        socket.Close();
    }

    void Parse(byte[] buffer)
    {
        ParsedData parsedData = PacketManager.Parse(buffer);
        switch(parsedData.cmd)
        {
            case CommandType.SocketID:
                SocketID socketId = parsedData.data as SocketID;
                socket.ID = socketId.id;
                break;
        }

    }
}

