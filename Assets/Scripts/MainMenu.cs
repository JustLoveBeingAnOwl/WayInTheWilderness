using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PrototypeScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
