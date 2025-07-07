using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Linq.Expressions;

public class SensorTest : MonoBehaviour
{
    SensorReading sensor;
    SerialPort SerialPort;

    // Start is called before the first frame update
    void Start()
    {
        string portName = "COM11"; // Set your ESP32's COM port
        int baudRate = 115200;

        SerialPort = new SerialPort(portName, baudRate);
        SerialPort.Open();
        SerialPort.DtrEnable = true; // Helps with ESP32 serial stability

        Debug.Log("Serial port opened.");
    }

    // Update is called once per frame
    void Update()
    {
        if (SerialPort != null && SerialPort.IsOpen)
        {
            try
            {
                int hall = int.Parse(SerialPort.ReadLine());
                bool touch = SerialPort.ReadLine() == "1";
                bool ir = SerialPort.ReadLine() == "0";

                sensor = new SensorReading(hall, touch, ir);
                sensor.TampilkanData();
            }
            catch(System.Exception)
            {
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (SerialPort != null && SerialPort.IsOpen)
        {
            SerialPort.Close();
        }
    }
}
