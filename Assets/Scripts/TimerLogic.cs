using UnityEngine;


public class TimerLogic : MonoBehaviour
{
    public static TimerLogic Instance { get; private set; }

    [SerializeField] private float roundTime;
    [SerializeField] private TimerDisplay timerDisplay;

    public int SecondsLeft { get; private set; }
    private float roundTimeCount;
    private bool roundStarted;
    public void ResetRoundTime()
    {
        roundTimeCount = roundTime;
        roundStarted = true;
    }

	private void Start()
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
        if (SecondsLeft != secondsLeftNew)
        {
            SecondsLeft = secondsLeftNew;
            timerDisplay.UpdateTime(SecondsLeft);
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
}
