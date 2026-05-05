using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("PrototypeScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
