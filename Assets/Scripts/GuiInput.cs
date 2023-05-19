using UnityEngine;

public class GuiInput : IInputProvider
{
	public Vector3 GetAxies()
	{
		if (GuiInputProv.Instance.clickLeft)
		{
			return Vector3.left;
		}
		else if(GuiInputProv.Instance.clickRight)
		{
			return Vector3.right;
		}
		return Vector3.zero;
	}

	public bool GetFire()
	{
		if (GuiInputProv.Instance.clickFire)
		{
			return true;
		}
		return false;
	}
}
