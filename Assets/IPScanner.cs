using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not working on Hololens, don't scan and ping the IP

public class IPScanner : MonoBehaviour
{
    static int ip_counter = 0;
    string localIP = "";
    // Start is called before the first frame update
    void Start()
    {
        //Uncomment this to enable pin
        /*
        PlayerPrefs.SetInt("IP_Count", 0);
        string[] splitted_IP = GetIPAddress().Split('.');
        localIP = splitted_IP[0] + "." + splitted_IP[1] + "." + splitted_IP[2] + ".";
        Debug.Log(localIP);

        for(int i = 0; i <= 255; i++)
        {
            CheckPing(localIP + i.ToString());
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPing(string ip)
    {
        //StartCoroutine(StartPing(ip));
        //Debug.Log("Ping started for " + ip.ToString());
    }

    //Uncomment this to enable pin
    //But Ping is not working on hololens while it works on desktop
    /*

    IEnumerator StartPing(string ip)
    {

        WaitForSeconds f = new WaitForSeconds(0.05f);
        Ping p = new Ping(ip);
        while (p.isDone == false)
        {
            yield return f;
        }
        PingFinished(p,ip);
    
    }
    */


    public void PingFinished(Ping p, string ip)
    {
        if (ip != GetIPAddress())
        {
            //Debug.Log("Ping is done for " + ip + " in " + p.time);
            PlayerPrefs.SetString("ip_"+ip_counter.ToString(), ip);
            ip_counter++;
            PlayerPrefs.SetInt("IP_Count", ip_counter);
        }
    }

    public static string GetIPAddress()
    {
        string IPAddress = string.Empty;
        IPHostEntry Host = default(IPHostEntry);
        string Hostname = null;
        Hostname = System.Environment.MachineName;
        Host = Dns.GetHostEntry(Hostname);
        foreach (IPAddress IP in Host.AddressList)
        {
            if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                IPAddress = IP.ToString();
            }
        }
        return IPAddress;
    }
}
