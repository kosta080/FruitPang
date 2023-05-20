using UnityEngine;
using UnityEngine.UI;

public class SummaryContentFiller : MonoBehaviour
{
	[SerializeField] private Text textField1;
	[SerializeField] private Text textField2;
	[SerializeField] private Text textField3;

	[SerializeField] private PlayerData playerData;

	private void Start()
	{
		string summaryText1 = string.Format("Congratulations you won! \n you got {0} bace points and {1} for the time left", playerData.PlayerScore, playerData.PlayerTimeLeftrScore);
		string summaryText2 = string.Format("TOTAL : {0}", playerData.PlayerTotalScore);
		string summaryText3;
		if (playerData.PlayerTotalScore >= playerData.PlayerBestScore)
			summaryText3 = string.Format("This is your new best score !!!");
		else
			summaryText3 = string.Format("Best score : {0}", playerData.PlayerBestScore);

		textField1.text = summaryText1;
		textField2.text = summaryText2;
		textField3.text = summaryText3;
	}
}
