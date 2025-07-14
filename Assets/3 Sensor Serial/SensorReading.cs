using UnityEngine;

public class SensorReading
{

    public int hall; // Hall-Effect
    public bool touch; // Touch
    public bool ir; // IR

    public SensorReading(int adcValue, bool isTouched, bool objectDetected)
    {
        this.hall = adcValue;
        this.touch = isTouched;
        this.ir = objectDetected;
    }

    public void TampilkanData()
    {
        Debug.Log("==== Data Sensor ====");
        Debug.Log("Hall Effect: " + hall);
        Debug.Log("Touch Sensor Pressed: " + (touch ? "Touched" : "No"));
        Debug.Log("IR Object Detected: " + (ir ? "Detect" : "Not Detected"));
        Debug.Log("============================================");
    }
}
