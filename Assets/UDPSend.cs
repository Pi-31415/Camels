/*
    -----------------------
    UDP-Send
    -----------------------
    This code is attached to the camel manipulation event handler
    and sends a UDP command to the wristaband
*/
using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPSend : MonoBehaviour
{
    private static int localPort;
    private string IP;  // define in init
    public int port;  // define in init
    private string localIP = "";
    IPEndPoint remoteEndPoint;
    UdpClient client;
    string strMessage = "";

    string Debug_Message = "";

    private static void Main()
    {
        UDPSend sendObj = new UDPSend();
        sendObj.init();
    }

    // start from unity3d
    public void Start()
    {
        init();
    }

    // Initialize the UDP sender with all the scanned IPs from ping
    public void init()
    {
        
        //IP = "192.168.1.15"; // George's Router
        //IP = "192.168.211.213"; //Pi's Phone
        IP = "192.168.31.100"; //Xiaomi Router
        port = 4210;
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
       
    }

    // sendData
    public void sendString(string message)
    {
        try
        {
            //Code for scanning all IPs and sending
            /*
            Debug.Log("IP_Count at current time: " + PlayerPrefs.GetInt("IP_Count", 0));
            Debug_Message = "";
            for (int i = 0; i < PlayerPrefs.GetInt("IP_Count", 0); i++)
            {
                Debug_Message += "Sending UDP to IP #" + i.ToString() + " - " + PlayerPrefs.GetString("ip_" + i.ToString(), "") + "\n";
                Debug.Log("Sending UDP to IP #" + i.ToString() + " - " + PlayerPrefs.GetString("ip_" + i.ToString(), ""));
                //Send UDP to all scanned IPs in network except to self
                if(PlayerPrefs.GetString("ip_" + i.ToString(), "") != "")
                {
                    IP = PlayerPrefs.GetString("ip_" + i.ToString(), "");
                    port = 4210;
                    remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
                    client = new UdpClient();
                    byte[] data = Encoding.UTF8.GetBytes("40");
                    client.Send(data, data.Length, remoteEndPoint);
                }
            }

            PlayerPrefs.SetString("Debug", Debug_Message);
            */

            //Manual IP hardcode
            
            byte[] data = Encoding.UTF8.GetBytes("40");
            client.Send(data, data.Length, remoteEndPoint);

        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }
}