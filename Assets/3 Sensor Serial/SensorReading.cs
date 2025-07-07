using UnityEngine;

public class SensorReading
{

    public int adcValue; // Hall-Effect
    public bool isTouched; // Touch
    public bool objectDetected; // IR

    public SensorReading(int adcValue, bool isTouched, bool objectDetected)
    {
        this.adcValue = adcValue;
        this.isTouched = isTouched;
        this.objectDetected = objectDetected;
    }

    public void TampilkanData()
    {
        Debug.Log("==== Data Sensor ====");
        Debug.Log("Hall Effect ADC: " + adcValue);
        Debug.Log("Touch Sensor Pressed: " + (isTouched ? "YA" : "TIDAK"));
        Debug.Log("IR Object Detected: " + (objectDetected ? "YA" : "TIDAK"));
    }
}
