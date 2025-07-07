using UnityEngine;
using System.IO.Ports;

public class Button_Control : MonoBehaviour
{
    SerialPort serialPort;
    private PlayerMovement playerMovement;

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
        playerMovement = FindObjectOfType<PlayerMovement>();
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
                        Debug.Log("Blue button pressed - Move Left");
                        playerMovement?.MoveLeft();
                        // Add your logic for blue button press here
                    }
                    else if (data.Contains("YELLOW_BUTTON_PRESSED"))
                    {
                        Debug.Log("Yellow button pressed - Move Right");
                        playerMovement?.MoveRight();
                        // Add your logic for yellow button press here
                    }
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

