using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text rimerText;
    [SerializeField] private float roundTime;
    [SerializeField] private string timerPrefix;

    private int secondsLeft;
    private float roundTimeCount;
    private bool roundStarted;
    public void ResetRoundTime()
    {
        roundTimeCount = roundTime;
        roundStarted = true;
    }

	private void Awake()
	{
        ResetRoundTime();
    }

	private void Update()
    {
        if (!roundStarted) return;

        if (roundTimeCount > 0)
        {
            roundTimeCount -= Time.deltaTime;
        }
        else
        {
            roundStarted = false;
            roundTimeCount = 0;
            GameManager.Instance.PlayerDeath();
        }

        int secondsLeftNew = (int)Mathf.Floor(roundTimeCount);
        if (secondsLeft != secondsLeftNew)
        {
            secondsLeft = secondsLeftNew;
            rimerText.text = timerPrefix + secondsLeft;
        }
    }
}
