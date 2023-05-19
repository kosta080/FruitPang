using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public void StartGame()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.buttonSound);
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.buttonSound);
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.buttonSound);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
