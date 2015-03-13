using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updateTimer : MonoBehaviour {

	public Text timer;
	private int Score;
	public float time = 30f;
	private GameObject g;
	void Start()
	{
		StartCoroutine (countdown());
		g = GameObject.Find ("copter");
	}
	
	IEnumerator countdown()
	{
		while (time > 0)
		{
			yield return new WaitForSeconds(1);
			
			timer.text = time.ToString();
			
			time -= 1;
		}


		timer.text = " ";
	}
}

