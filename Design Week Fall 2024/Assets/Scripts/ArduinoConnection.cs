using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoConnection : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM7", 19200);
    public string recievedString;
    public GameObject test_data;
    public float sensitivity = 0.01f;

    public string[] datas;


    void Start()
    {
        data_stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        recievedString = data_stream.ReadLine();

        string[] strings = recievedString.Split(',');
    }
}
