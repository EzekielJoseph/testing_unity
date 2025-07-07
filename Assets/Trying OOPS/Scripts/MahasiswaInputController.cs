using TMPro;
using UnityEngine;
using System.IO.Ports;

public class MahasiswaInputController : MonoBehaviour
{
    SerialPort sendingJsontoESP;

    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_InputField kerjaanInput;
    public TMP_InputField hobiInput;
    public TMP_InputField domisiliInput;
    public TMP_InputField emailInput;
    public TMP_InputField nikInput;
    public TMP_InputField angkatanInput;

    void Start()
    {
        string portName = "COM11"; // Set your ESP32's COM port
        int baudRate = 115200;

        sendingJsontoESP = new SerialPort(portName, baudRate);
        sendingJsontoESP.Open();
        sendingJsontoESP.DtrEnable = true; // Helps with ESP32 serial stability

        Debug.Log("Serial port opened.");
    }

    public void RegisterClickedMHS()
    {
        string nama = nameInput.text;
        int umur = int.Parse(ageInput.text);
        string kerjaan = kerjaanInput.text;
        string hobi = hobiInput.text;
        string domisili = domisiliInput.text;
        string email = emailInput.text;
        string nik = nikInput.text;
        int angkatan = int.Parse(angkatanInput.text);

        // Buat objek Mahasiswa
        Mahasiswa mhs = new Mahasiswa(nama, umur, kerjaan, hobi, domisili, email, nik, angkatan);

        //mhs.TampilkanData();

        string rawJsonMHS = JsonUtility.ToJson(mhs, true);
        Debug.Log("=== JSON Data Mahasiswa ===");
            
        if (sendingJsontoESP.IsOpen)
        {
            string cleanedJson = rawJsonMHS.Replace("\r", "").Replace("\n", "");
            string finalJson = cleanedJson;

            sendingJsontoESP.WriteLine(finalJson); // Kirim JSON ke ESP (ditutup dengan newline)
            Debug.Log("Pesan Dikirim: \n" + finalJson);
        }
        else
        {
            Debug.LogError("Serial port tidak terbuka!");
        }

        //sendingJson.WriteLine(json);
        //Debug.Log("Pesan Dikirim:\n " + json);
    }

    public void OnApplicationQuit()
    {
        if (sendingJsontoESP != null)
        {
            sendingJsontoESP.Close();
            Debug.Log("Serial Closed");
        }
    }
}
