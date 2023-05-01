using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using Fungus;

public class SerialScript : MonoBehaviour
{
    public static SerialScript Instance;
    public string id;
    public string PlayerName; 
    public bool HasScannedValid;
    
    private string[] VALID_TAGS = {"60007825C9F4", "6000781F5156", "600079122A21",  "600078ECA551"}; //RFID TAGS HERE, HEX VALUE 
    private Dictionary<string, string> PlayerMap; 
    SerialPort serialPort;
    private Thread t;

    void Awake()
    {
        PlayerMap = new Dictionary<string, string>(){
            {"60007825C9F4", "Mom"}, 
            {"6000781F5156", "Brother"},
            {"600079122A21", "Dad"},
            {"600078ECA551", "Sister"}
        }; 
        
        HasScannedValid = false;
        id = "";
        
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    void Start()
    {
        //sometimes this port name needs to be changed /dev/tty.usbmodem14101
        serialPort = new SerialPort("/dev/tty.usbmodem14201", 9600);

        if (!serialPort.IsOpen)
        {
            serialPort.Open();
            
            serialPort.NewLine = "\r\n";
            if (serialPort.IsOpen) { print("Opened port!"); }
        }
        
        //holding a string data  
        t = new Thread(new ThreadStart(ParseData));
        t.Start();
    }

    void ParseData() {
       
        while(true) {
            string serialData = serialPort.ReadLine();
            
            id = serialData;
          //  Debug.Log("Read From Arduino: " + serialData);

            string result = "";
            if (PlayerMap.TryGetValue(id, out result))
            {
                PlayerName = result; 
            } 
            
            //now i can access instance.playername. if instance.playername == this, do this. 
            Debug.Log(PlayerName); 
            foreach (string testTag in VALID_TAGS)
            {
                HasScannedValid = testTag == id;
                if (HasScannedValid) break;
            }
        }
    }
    
    //destructor 
    ~SerialScript() 
    {
        serialPort.Close(); 
        Debug.Log("Closed port");
    }

    void OnApplicationQuit()
    {
        StopThread();
    }

    public void StopThread()
    {
        Debug.Log("Stop");
        serialPort.Close();
        t.Abort();
    }
}
