using UnityEngine;
using UnityEngine.UI;

public class SplashTextManager : MonoBehaviour
{
    [SerializeField] private string textBeforeGameStarted;
    [SerializeField] private string textAfterPlayerDied;
    [SerializeField] private string textAfterTimeIsUp;
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
