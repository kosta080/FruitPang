using UnityEngine;


public class TimerLogic : MonoBehaviour
{
    
    [SerializeField] private float roundTime;
    [SerializeField] private TimerDisplay timerDisplay;

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
            GameManager.Instance.TimeIsUp();
        }

        int secondsLeftNew = (int)Mathf.Floor(roundTimeCount);
        if (secondsLeft != secondsLeftNew)
        {
            secondsLeft = secondsLeftNew;
            timerDisplay.UpdateTime(secondsLeft);
        }
    }
}
