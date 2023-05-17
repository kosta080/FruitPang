using UnityEngine;
using UnityEngine.UI;

public class GuiInputProv : MonoBehaviour
{
	public static GuiInputProv Instance { get; private set; }

	public bool clickLeft { get; private set; }
	public bool clickRight { get; private set; }
	public bool clickFire { get; private set; }

	[SerializeField] private Button btnLeft;
	[SerializeField] private Button btnRight;
	[SerializeField] private Button btnFire;

	public void pressLeft(){clickLeft = true;}
	public void releaseLeft(){clickLeft = false;}
	public void pressRight(){clickRight = true;}
	public void releaseRight(){clickRight = false;}
	public void pressFire(){clickFire = true;}
	public void releaseFire(){clickFire = false;}

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
