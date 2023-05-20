using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerData playerData;

    [SerializeField] private Transform targetContainer;
    [SerializeField] private Transform arrowContainer;
    [SerializeField] private Transform bonusesContainer;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private SplashTextManager splashTextManager;
    [Header("Scoring")]
    [SerializeField] private int timeLeftRate;
    [Header("Debug Mode")]
    [SerializeField] private bool godMode;
    [SerializeField] private bool infenateTimeMode;

	public void PlayerDeath()
    {
        if (godMode) return;
        splashTextManager.ShowYouDied();
        Time.timeScale = 0;
        StartCoroutine(restartLevel());
    }
    public void TimeIsUp()
    {
        if(infenateTimeMode) return;
        splashTextManager.ShowTimeIsUp();
        Time.timeScale = 0;
        StartCoroutine(restartLevel());
    }
    public void TargetHit(int scoreValue)
    {
        playerData.AddScore(scoreValue);

        if (winCheck()) 
        {
            Time.timeScale = 0;
            StartCoroutine(winLevel());
        }
    }
    public void BonusCollected(int bonus)
    {
        playerData.AddScore(bonus);
    }
    private void Start()
	{
        Time.timeScale = 0;
        StartCoroutine(startLevel());
        SoundManager.Instance.PlayMusic();
    }
    private IEnumerator startLevel()
    {
        TimerLogic.Instance.ResetRoundTime();
        TargetSpawner.Instance.SpawnTarget();
        playerData.ResetScore();
        splashTextManager.ShowGetReady();
        yield return new WaitForSecondsRealtime(2.0f);
        splashTextManager.HideText();
        Time.timeScale = 1;
    }
    private IEnumerator restartLevel()
    {
        playerController.StartDeathAnim();

        yield return new WaitForSecondsRealtime(2.0f);

        foreach (Transform child in targetContainer)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in arrowContainer)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in bonusesContainer)
        {
            Destroy(child.gameObject);
        }

        playerController.ResetPlayer();
        splashTextManager.HideText();
        yield return new WaitForSecondsRealtime(0.5f);
        StartCoroutine(startLevel());
    }
    private IEnumerator winLevel()
    {
        splashTextManager.ShowWin();
        playerData.StoreTimeLift(TimerLogic.Instance.SecondsLeft, timeLeftRate);
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene("Summary", LoadSceneMode.Single);
    }
    private bool winCheck()
    {
        return targetContainer.childCount <= 1;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        Application.targetFrameRate = 60;
    }
}
