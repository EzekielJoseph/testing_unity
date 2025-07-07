using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterMahasiswaDosen : MonoBehaviour
{
    public void RegistMahasiswa()
    {
        SceneManager.LoadSceneAsync("DisplayMahasiswa");
    }

    public void RegistDosen()
    {
        SceneManager.LoadSceneAsync("DisplayDosen");
    }
}
