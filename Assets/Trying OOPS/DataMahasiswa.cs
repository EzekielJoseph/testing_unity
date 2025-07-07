using UnityEngine;

public class DataMahasiswa : DataPemain
{
    public string NomorIndukMahasiswa;
    public int TahunAngkatan;

    public DataMahasiswa(
        string nama, 
        int umur, 
        string pekerjaan, 
        string hobi, 
        string domisili, 
        string alamat_Email,
        string nomorIndukMahasiswa, 
        int tahunAngkatan) 
        : base(nama, umur, pekerjaan, hobi, domisili, alamat_Email)
    {
        this.NomorIndukMahasiswa = nomorIndukMahasiswa;
        this.TahunAngkatan = tahunAngkatan;
    }

    public override void TampilkanData()
    { 
        base.TampilkanData();
        Debug.Log("NIK: " + NomorIndukMahasiswa);
        Debug.Log("Tahun Angkatan: " + TahunAngkatan);

    }
}
