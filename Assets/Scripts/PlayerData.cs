using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Models/Player Data", fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
	public event Action PlayerScoreChange;

	[SerializeField] private int playerScore;
	[SerializeField] private int playerTimeLeftrScore;
	[SerializeField] private int playerTotalScore;
	[SerializeField] private int playerBestScore=0;

	public void AddScore(int _ammount)
	{
		playerScore += _ammount;
		PlayerScoreChange?.Invoke();
	}
	public void StoreTimeLift(int _timeLeft, int _timeLeftRate)
	{
		playerTimeLeftrScore = _timeLeft * _timeLeftRate;
		CalcTotal();
	}
	public void CalcTotal()
	{
		playerTotalScore = playerScore + playerTimeLeftrScore;
		if (playerTotalScore > playerBestScore)
		{
			playerBestScore = playerTotalScore;
		}
	}
	public void ResetScore()
	{
		playerScore = 0;
		playerTimeLeftrScore = 0;
		playerTotalScore = 0;

		PlayerScoreChange?.Invoke();
	}

	public int PlayerScore => playerScore;
	public int PlayerTimeLeftrScore => playerTimeLeftrScore;
	public int PlayerTotalScore => playerTotalScore;
	public int PlayerBestScore => playerBestScore;
}
