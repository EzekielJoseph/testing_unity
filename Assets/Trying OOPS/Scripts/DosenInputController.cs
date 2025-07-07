using TMPro;
using UnityEngine;
using System.IO.Ports;

public class DosenInputController : MonoBehaviour
{
    SerialPort dosenJsontoESP;

    public TMP_InputField namaInput;
    public TMP_InputField umurInput;
    public TMP_InputField kerjaanInput;
    public TMP_InputField hobiInput;
    public TMP_InputField domisiliInput;
    public TMP_InputField emailInput;
    public TMP_InputField nikInput;
    public TMP_InputField tahunmulaiajarInput;
    public TMP_InputField statusperkawinanInput;

    private void Start()
    {
        string portName = "COM11";
        int baudRate = 115200;

        dosenJsontoESP = new SerialPort(portName,baudRate);
        dosenJsontoESP.Open();
        dosenJsontoESP.DtrEnable = true;
        Debug.Log("Serial Open");

    }

    public void OnClickRegisterDSN()
    {
        string nama = namaInput.text;
        int umur = int.Parse(umurInput.text);
        string kerjaan = kerjaanInput.text;
        string hobi = hobiInput.text;
        string domisili = domisiliInput.text;
        string email = emailInput.text;
        string nik = nikInput.text;
        int tahunajar = int.Parse(tahunmulaiajarInput.text);
        string statusnikah = statusperkawinanInput.text;

        Dosen dsn = new Dosen(nama, umur, kerjaan, hobi, domisili, email, nik, tahunajar, statusnikah);

        string rawJsonDSN = JsonUtility.ToJson(dsn,true);

        if (dosenJsontoESP.IsOpen)
        {
            string cleanedJson = rawJsonDSN.Replace("\r", "").Replace("\n", "");
            string finalJson = cleanedJson;

            dosenJsontoESP.WriteLine(finalJson); // Kirim JSON ke ESP (ditutup dengan newline)
            Debug.Log("Pesan Dikirim: \n" + finalJson);
        }
        else
        {
            Debug.LogError("Serial port tidak terbuka!");
        }
    }

    private void OnApplicationQuit()
    {
        if (dosenJsontoESP != null)
        {
            dosenJsontoESP.Close();
            Debug.Log("Serial Port Closed");
        }
    }
}
