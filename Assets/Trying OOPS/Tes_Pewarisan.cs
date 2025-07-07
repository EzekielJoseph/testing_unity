using UnityEngine;

public class Tes_Pewarisan : MonoBehaviour
{
    // Start is called before the first frame update  
    void Start()
    {
        // Corrected constructor call to match the expected parameters  
        DataMahasiswa mhs = new DataMahasiswa(
        
            "Ezekiel Joseph",
            20,
            "Mahasiswa",
            "Tidur",
            "Jakarta Selatan",
            "ejmee1234@gmail.com",
            "2602113123",
            2026
        );

        DataDosen dsn = new DataDosen(
            "Alexander",
            43,
            "Dosen Calculus",
            "Membaca",
            "Karang Tengah",
            "Alexander.Wijaya@gmail.com",
            "1234567890",
            2019,
            "Married"
         );

        Debug.Log("--- Data Mahasiswa ---");
        mhs.TampilkanData();


        Debug.Log("--- Data Dosen ---");
        dsn.TampilkanData();
    }
}
