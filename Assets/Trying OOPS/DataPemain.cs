using UnityEngine;

public class DataPemain
{
    public string Nama;
    public int Umur; // Change the type of 'Umur' from string to int
    public string Pekerjaan;
    public string Hobi;
    public string Domisili;
    public string Alamat_Email;

    public DataPemain(string nama, int umur, string pekerjaan, string hobi, string domisili, string alamat_Email)
    {
        this.Nama = nama;
        this.Umur = umur; 
        this.Pekerjaan = pekerjaan;
        this.Hobi = hobi;
        this.Domisili = domisili;
        this.Alamat_Email = alamat_Email;
    }

    public virtual void TampilkanData()
    {
        Debug.Log("Nama: " + Nama);
        Debug.Log("Umur: " + Umur); 
        Debug.Log("Pekerjaan: " + Pekerjaan);
        Debug.Log("Hobi: " + Hobi);
        Debug.Log("Domisili: " + Domisili);
        Debug.Log("Alamat Email: " + Alamat_Email);
    }
}