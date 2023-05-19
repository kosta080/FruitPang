using UnityEngine;
using UnityEngine.UI;

public class SummaryContentFiller : MonoBehaviour
{
	[SerializeField] private Text SummaryText;
	[SerializeField] private PlayerData playerData;
	private const string SCORE_MESSAGE_PREFIX = "Congratulations you won! your score is ";
	private void Start()
	{
		SummaryText.text = SCORE_MESSAGE_PREFIX + playerData.PlayerScore;
	}
}
