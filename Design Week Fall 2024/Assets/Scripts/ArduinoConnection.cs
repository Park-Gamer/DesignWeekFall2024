using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoConnection : MonoBehaviour
{
    private SerialPort dataStream = new SerialPort("COM4", 115200); // Change to your COM port
    public float receivedFloat; // This variable will store the float data

    private void Awake()
    {
        // Open the serial port
        dataStream.Open();
        dataStream.ReadTimeout = 50; // Set a timeout to avoid freezing
    }

    private void Update()
    {
        // Check if the serial port is open and if there's data available
        if (dataStream.IsOpen && dataStream.BytesToRead > 0)
        {
            try
            {
                string receivedString = dataStream.ReadLine(); // Read a line from the serial port
                receivedFloat = float.Parse(receivedString); // Parse the string to a float
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading from serial port: " + e.Message); // Log any errors
            }
        }
    }

    private void OnApplicationQuit()
    {
        // Close the serial port when the application quits
        if (dataStream.IsOpen)
        {
            dataStream.Close();
        }
    }
}
