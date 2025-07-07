using UnityEngine;

public class baru : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataMahasiswa mhsBaru = new DataMahasiswa(
            "jeje",
            18,
            "pro player",
            "maen emel",
            "jaktim",
            "jeje.jeje@gmail.com",
            "1231231231",
            2021
            );
        mhsBaru.TampilkanData();

        DataDosen dsnBaru = new DataDosen(
            "el dosen",
            999,
            "memberi nilai" ,
            "balapan" ,
            "kelapa gading" ,
            "dosen.biasa@gmail.com" ,
            "321321321",
            1987,
            "divorced"
            );
        dsnBaru.TampilkanData();
    }
}