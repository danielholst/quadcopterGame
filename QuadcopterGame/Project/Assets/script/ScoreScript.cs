using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	private GameObject g;
	public Text scoreText;
	private int Score;
	public float time = 30f;
	public float time2 = 5f;
	// Use this for initialization
	void Start () 
	{
		g = GameObject.Find ("copter");
		StartCoroutine (countdown());
	}
	

	IEnumerator countdown()
	{
		while (time > -1)
		{
			yield return new WaitForSeconds(1);

			
			time -= 1;
		}
		while (time2 > 0)
		{
			yield return new WaitForSeconds(1);
			movement2 e = g.GetComponent<movement2> ();
			Score = e.score;
			scoreText.text = "YOUR SCORE: " + Score;
			print (Score);
			time2 -= 1;
		}

		Application.LoadLevel ("Menu");
	}
}
