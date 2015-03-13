using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float timer = 30.0f;
	private GUIText text;

	void start()
	{
	}
	void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			timer = 0;
		}
	}
	
	void OnGUI()
	{

		GUI.Box (new Rect (600, 10, 70, 40), "" + text	);

	}

}
