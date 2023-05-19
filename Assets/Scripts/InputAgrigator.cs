using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputAgrigator
{
	private List<IInputProvider> inputProviders = new List<IInputProvider>();

	public void initInput()
	{
		inputProviders.Add(new KeyboardInput());
		inputProviders.Add(new GuiInput());
		Debug.Log("<color=green>"+inputProviders.Count+" input methods are active "+ getInputMethodsNames()+"</color>");
	}

	public Vector3 GetAxies()
	{
		foreach (IInputProvider prov in inputProviders)
		{
			Vector3 inputVal = prov.GetAxies();
			if (inputVal != Vector3.zero)
			{
				return inputVal;
			}
			
		}
		return Vector3.zero;
	}

	public bool GetFire()
	{
		foreach (IInputProvider prov in inputProviders)
		{
			bool inputVal = prov.GetFire();
			if (prov.GetFire())
			{
				return inputVal;
			}

		}
		return false;
	}
	private string getInputMethodsNames()
	{
		string inputMethodNames="";
		foreach (IInputProvider prov in inputProviders)
		{
			inputMethodNames += ", "+prov.GetType();
		}
		return inputMethodNames;
	}
}
