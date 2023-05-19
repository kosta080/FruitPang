using UnityEngine;
using UnityEngine.UI;

public class SplashTextManager : MonoBehaviour
{
    [SerializeField] private string textBeforeGameStarted;
    [SerializeField] private string textAfterPlayerDied;
    [SerializeField] private string textAfterTimeIsUp;
    [SerializeField] private string textAfterPlayerWon;

    private Text splashText;

    public void ShowGetReady()
    {
        showText(textBeforeGameStarted);
    }
    public void ShowYouDied()
    {
        showText(textAfterPlayerDied);
    }
    public void ShowTimeIsUp()
    {
        showText(textAfterTimeIsUp);
    }
    public void ShowWin()
    {
        showText(textAfterPlayerWon);
    }


    private void showText(string text)
    {
        gameObject.SetActive(true);
        splashText.text = text;
    }
    public void HideText()
    {
        splashText.text = "";
        gameObject.SetActive(false);
    }
	private void Awake()
	{
        splashText = GetComponent<Text>();

    }
}
