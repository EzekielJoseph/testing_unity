using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMahasiswaDosen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Mahasiswa()
    {
        SceneManager.LoadSceneAsync("DataMahasiswa");
    }

    // Update is called once per frame
    public void Dosen()
    {
        SceneManager.LoadSceneAsync("DataDosen");
    }
}
