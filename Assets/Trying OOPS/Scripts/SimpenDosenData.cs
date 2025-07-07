// Dosen.cs
using UnityEngine;

public class Dosen
{
    //Fields
    public string nama;
    public int umur;
    public string kerjaan;
    public string hobi;
    public string domisili;
    public string email;
    public string nik;
    public int tahunajar;
    public string statusnikah;

    // Constructor
    public Dosen(string nama, int umur, string kerjaan, string hobi, string domisili, string email, string nik, int tahunajar, string statusnikah)
    {
        this.nama = nama;
        this.umur = umur;
        this.kerjaan = kerjaan;
        this.hobi = hobi;
        this.domisili = domisili;
        this.email = email;
        this.nik = nik;
        this.tahunajar = tahunajar;
        this.statusnikah = statusnikah;
    }

    // Method khusus untuk menampilkan data
    public void TampilkanData()
    {
        Debug.Log("===== DATA MAHASISWA =====");
        Debug.Log("Nama       : " + nama);
        Debug.Log("Umur       : " + umur);
        Debug.Log("Kerjaan    : " + kerjaan);
        Debug.Log("Hobi       : " + hobi);
        Debug.Log("Domisili   : " + domisili);
        Debug.Log("Email      : " + email);
        Debug.Log("NIK        : " + nik);
        Debug.Log("Tahun Ajar   : " + tahunajar);
        Debug.Log("Status Nikah: " +  statusnikah);
    }
}
