using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private string timerPrefix;
    private Text rimerText;
	private void Awake()
	{
		rimerText = gameObject.GetComponent<Text>();
	}
	public void UpdateTime(int secondsLeft)
    {
        rimerText.text = timerPrefix + secondsLeft;
    }
}
