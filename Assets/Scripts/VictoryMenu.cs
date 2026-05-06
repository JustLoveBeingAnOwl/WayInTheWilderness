using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
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
