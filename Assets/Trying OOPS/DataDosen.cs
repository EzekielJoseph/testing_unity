using UnityEngine;

public class DataDosen : DataPemain 
{
    public string NomorIndukDosen;
    public int TahunMulaiPengajaran;
    public string StatusPerkawinan;

    public DataDosen(
        string nama, 
        int umur, 
        string pekerjaan, 
        string hobi, 
        string domisili, 
        string alamat_Email,
        string nomorIndukDosen, 
        int TahunMulaiPengajaran, 
        string StatusPerkawinan) 
        : base(nama, umur, pekerjaan, hobi, domisili, alamat_Email)
    {
        this.NomorIndukDosen = nomorIndukDosen;
        this.TahunMulaiPengajaran = TahunMulaiPengajaran;
        this.StatusPerkawinan = StatusPerkawinan;
    }


    public override void TampilkanData()
    {
        base.TampilkanData();
        Debug.Log("NIK: " + NomorIndukDosen);
        Debug.Log("Tahun Mulai Pengajaran: " + TahunMulaiPengajaran);
        Debug.Log("Status Perkawinan: " +  StatusPerkawinan);
    }
}
