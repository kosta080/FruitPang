using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private string timerPrefix;
	[SerializeField] private PlayerData playerData;

    private Text rimerText;

	private void Awake()
	{
		rimerText = gameObject.GetComponent<Text>();
	}
	private void Start()
	{
		playerData.PlayerScoreChange += UpdateScore;
	}
	private void OnDestroy()
	{
		playerData.PlayerScoreChange -= UpdateScore;
	}
	public void UpdateScore()
    {
        rimerText.text = timerPrefix + playerData.PlayerScore;
    }
}
