using UnityEngine;
using System.IO.Ports;

public class esp_serial_recieve : MonoBehaviour
{
    SerialPort serialPort;

    // Start is called before the first frame update
    void Start()
    {
        serialPort = new SerialPort("COM11", 115200);
        serialPort.ReadTimeout = 100; // Set a read timeout to avoid blocking
        try
        {
            serialPort.Open();
            Debug.Log("Serial Port opened successfully.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Serial Port error: " + ex.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                if (!string.IsNullOrEmpty(data))
                {
                    Debug.Log("Received: " + data);

                    if (data.Contains("BLUE_BUTTON_PRESSED"))
                    {
                        Debug.Log("Blue button pressed");
                    }
                    else if (data.Contains("YELLOW_BUTTON_PRESSED"))
                    {
                        Debug.Log("Yellow button pressed");
                    }
                }
                else
                {
                    Debug.LogWarning("Data recieved but empty");
                }
            }
            catch (System.TimeoutException)
            {
            }
        }
    }

    private void OnDestroy()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
