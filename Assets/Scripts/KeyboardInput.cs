using UnityEngine;

public class KeyboardInput: IinputProvider
{
	public Vector3 GetAxies()
	{
		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			return Vector3.left;
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			return Vector3.right;
		} 
		return Vector3.zero;
	}

}
