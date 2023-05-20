using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public void StartGame() => StartCoroutine(startGame());
    public void ExitGame() => StartCoroutine(exitGame());
    public void GoToMainMenu() => StartCoroutine(goToMainMenu());

    private const float ACTIONDELAY = 0.35f; //to give time for the click sound before switching scene

    private IEnumerator startGame()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.buttonSound);
        yield return new WaitForSeconds(ACTIONDELAY);
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
    private IEnumerator exitGame()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.buttonSound);
        yield return new WaitForSeconds(ACTIONDELAY);
        Application.Quit();
    }
    private IEnumerator goToMainMenu()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.buttonSound);
        yield return new WaitForSeconds(ACTIONDELAY);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
