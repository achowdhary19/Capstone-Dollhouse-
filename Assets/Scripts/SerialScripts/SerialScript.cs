using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
// using UnityEngine.UI;
using System.Threading;

public class SerialScript : MonoBehaviour
{
    public static SerialScript Instance;
    public string id;
    public string PlayerName; 
    public bool HasScannedValid;
    

    private string[] VALID_TAGS = {"60007825C9F4", "6000781F5156", "04005726592C",  "040057269EEB"}; //RFID TAGS HERE, HEX VALUE 
    private Dictionary<string, string> PlayerMap; 
    SerialPort serialPort;
    private Thread t;
    
    // string serialData;
   // public GameObject Player; 
    

    void Awake()
    {
        PlayerMap = new Dictionary<string, string>(){
            {"60007825C9F4", "Mom"}, 
            {"6000781F5156", "Brother"}
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
        serialPort = new SerialPort("/dev/tty.usbmodem14201", 9600);

        if (!serialPort.IsOpen)
        {
            print("Opening /dev/tty.usbmodem14101 baud 9600"); 
            serialPort.Open();
            //stream.ReadTimeout = 1000;
            //stream.Handshake = Handshake.None;
            serialPort.NewLine = "\r\n";
            if (serialPort.IsOpen) { print("Opened port!!!!"); }
        }
        
        //holding a string data  
        t = new Thread(new ThreadStart(ParseData));
        t.Start();
        // StartCoroutine(ReadSerial());
    }

    void ParseData() {
       
        while(true) {
            string serialData = serialPort.ReadLine();
            //Debug.Log("Something" + serialPort.ReadChar()); //testing, 
            id = serialData;
            Debug.Log("Read From Arduino: " + serialData);

            string result = "";
            if (PlayerMap.TryGetValue(id, out result))
            {
                PlayerName = result; 
            } 
            //now i can access instance.playername if player name = this, do this, 
            
            Debug.Log(PlayerName); 
            foreach (string testTag in VALID_TAGS)
            {
                HasScannedValid = testTag == id;
                if (HasScannedValid) break;
            }
        }
    }

    ~SerialScript()
    {
        serialPort.Close(); 
        Debug.Log("Closed port");
    }
}
