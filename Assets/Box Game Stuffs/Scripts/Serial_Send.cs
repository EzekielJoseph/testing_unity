using System.IO.Ports;
using UnityEngine;

public class test : MonoBehaviour
{
    SerialPort Stream;
    public int score = 0; // You can set this in Inspector or from another script

    void Start()
    {
        string portName = "COM11"; // Set your ESP32's COM port
        int baudRate = 115200;

        Stream = new SerialPort(portName, baudRate);
        Stream.Open();
        Stream.DtrEnable = true; // Helps with ESP32 serial stability

        Debug.Log("Serial port opened.");
    }

    public void SendFinalScore(int score)
    {
        if (Stream.IsOpen)
        {
            try
            {
                Stream.WriteLine(score.ToString()); // Convert int to string before writing  
                Debug.Log("Final score sent to ESP32: " + score);
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
