using UnityEngine;
using System.Collections;

public class ifClicked : MonoBehaviour {


	private void OnGUI()
	{
		if(GUI.Button(new Rect(0, 0, 200, 50), "" , "buttonText"))
		{
			Application.Quit();
		}
	}
}