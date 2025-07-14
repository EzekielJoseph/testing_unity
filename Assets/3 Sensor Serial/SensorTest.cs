using System.Collections;
using System.IO.Ports;
using TMPro;
using UnityEngine;

public class SensorTest : MonoBehaviour
{
    SensorReading sensor;
    SerialPort serialPort;

    public TMP_Text hallEffectText;
    public TMP_Text touchSensorText;
    public TMP_Text irSensorText;

    float startDelay;
    int ignoreJson = 0;
    public int skipNumber = 15;

    //public string kalvin = "kalvin";
    //public string eze = "eze";


    // Start is called before the first frame update
    void Start()
    {
        string portName = "COM11";
        int baudRate = 115200;

        serialPort = new SerialPort(portName, baudRate);
        sensor = new SensorReading(0, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            return;
        }

        if (serialPort != null && serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            try
            {
                string json = serialPort.ReadLine();

                if (ignoreJson < skipNumber)
                {
                    ignoreJson++;
                    Debug.Log("Ignore Json ke: " + ignoreJson);
                    //Debug.Log(" Raw JSON: " + json);
                    return;
                }

                if (json.StartsWith("{") && json.EndsWith("}"))
                { 
                    sensor = JsonUtility.FromJson<SensorReading>(json);
                    TampilkanText(sensor);
                    Debug.Log("Raw JSON: " + json);
                }
                else
                {
                    //Debug.Log("Invalid JSON Skipped: " + json);
                    return;
                }
            }
            catch
            {
                //Debug.Log(e.Message);
                //Debug.Log(json);
                ////serialPort.Close();
                ////Debug.Log("Serial Closed");
            }
        }
    }

    public void ButtonSerialConnection()
    {
        if (serialPort != null && !serialPort.IsOpen)
        {
            try
            {
                serialPort.Open();
                serialPort.DtrEnable = true;
                Debug.Log("Serial Port Opened.");
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
            startDelay = 5;
            ignoreJson = 0;
        }
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }

    public void TampilkanText(SensorReading reading)
    {
        hallEffectText.text = "Hall Effect: " + reading.hall;
        touchSensorText.text = "Touch Sensor Touched: " + (reading.touch ? "Touched" : "No");
        irSensorText.text = "IR Object Detected: " + (reading.ir ? "Detected" : "Nothing");
    }

    //public void Something(string nama, string alamat, int umur)
    //{
    //Debug.Log("nama saya " + eze);
    //Debug.Log("nama saya " + kalvin);
    //Debug.Log("nama saya " + nama + " sya tinggal di " + alamat + " umur saya " + umur);
    //    hallEffectText.text = nama;
    //    touchSensorText.text = alamat;
    //    irSensorText.text = umur.ToString();
    //}

    //public void TampilkanData(int hall, bool touch, bool ir)
    //{
    //    hallEffectText.text = "Hall Effect: " + hall.ToString();
    //    touchSensorText.text = "Touch Sensor Touched: " + (touch ? "Touched" : "No"); 
    //    irSensorText.text = "IR Object Detected: " + (ir ? "Detected" : "Nothing");

    //}
}
