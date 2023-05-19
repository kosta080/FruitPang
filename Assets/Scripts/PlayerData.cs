using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Models/Player Data", fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
	public event Action PlayerScoreChange;

	[SerializeField]
	private int playerScore;

	public void AddScore(int ammount)
	{
		playerScore += ammount;
		PlayerScoreChange?.Invoke();
	}
	public void ResetScore()
	{
		playerScore = 0;
		PlayerScoreChange?.Invoke();
	}

	public int PlayerScore => playerScore;
}
