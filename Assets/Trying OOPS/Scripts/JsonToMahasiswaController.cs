using UnityEngine;
using TMPro;

public class JsonToMahasiswaController : MonoBehaviour
{
    public TMP_InputField jsonInputField;

    public void OnConvertButtonClicked()
    {
        string json = jsonInputField.text;

        try
        {
            Mahasiswa mhs = JsonUtility.FromJson<Mahasiswa>(json);
            if (mhs != null)
            {
                mhs.TampilkanData();
            }
            else
            {
                Debug.LogWarning("Gagal mengubah JSON Ke Mahasiswa (null)");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Gagal Parsing JSON: " + e.Message);
        }
    }
}
