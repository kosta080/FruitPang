using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
