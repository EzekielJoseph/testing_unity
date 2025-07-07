using UnityEngine;

public class TesDataPemain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataPemain pemain1 = new DataPemain(
            "Ezekiel Joseph",
            20,
            "Mahasiswa",
            "Tidur",
            "Jakarta Selatan",
            "ejmee1234@gmail.com"
            );
        pemain1.TampilkanData();
    }
}
