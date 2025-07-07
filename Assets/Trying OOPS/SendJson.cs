using System.IO.Ports;
using UnityEngine;
using TMPro;

public class SendJson : MonoBehaviour
{
    SerialPort sendingJson;
    public TMP_InputField jsonInputField;

    void Start()
    {
        string portName = "COM11"; // Set your ESP32's COM port
        int baudRate = 115200;

        sendingJson = new SerialPort(portName, baudRate);
        sendingJson.Open();
        sendingJson.DtrEnable = true; // Helps with ESP32 serial stability

        Debug.Log("Serial port opened.");
    }

    public void SendToESP()
    {
        if (!sendingJson.IsOpen)
        {
            Debug.LogWarning("Serial Port Not Open");
            return;
        }

        string rawInput = jsonInputField.text;
        string cleanedJson = rawInput.Replace("\r", "").Replace("\n", "");

        string json = cleanedJson + "\n"; // Tambahkan newline tunggal

        sendingJson.WriteLine(json);
        Debug.Log("Pesan Dikirim:\n" + json);
    }

    // Update is called once per frame
    public void OnApplicationQuit()
    {
        if (sendingJson != null)
        {
            sendingJson.Close();
            Debug.Log("Serial Closed");
        }
    }
}
