using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class test : MonoBehaviour
{
    SerialPort Stream;

    // Start is called before the first frame update  
    void Start()
    {
        string portName = "COM11"; // Specify the port name  
        int baudRate = 115200; // Specify the baud rate  
        Stream = new SerialPort(portName, baudRate); // Initialize the SerialPort  
        Stream.Open();
        Stream.DtrEnable = true; // Enable DTR (Data Terminal Ready)
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed");
            SendDataToMicon("Test");
        }
    }

    void SendDataToMicon(string message)
    {
        if (Stream.IsOpen)
        {
            try
            {
                Stream.WriteLine(message);
                Debug.Log("Data sent to Micon: " + message);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error writing to serial port: " + e.Message);
            }
        }
        else 
        {
            Debug.LogWarning("Serial port is not open.");
        }
    }
    void OnApplicationQuit()
    {
        if (Stream != null && Stream.IsOpen)
        {
            Stream.Close();
            Debug.Log("Serial port closed.");
        }
    }

}
