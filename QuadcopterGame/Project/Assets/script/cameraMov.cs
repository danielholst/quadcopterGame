using UnityEngine;
using System.Collections;

public class cameraMov : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(0.02f,0.0f,0.0f); //Space.World
		if (transform.localEulerAngles.x > 320f) 
		{
			transform.Rotate(-0.01f,0.0f,0.0f);
		}
		if (transform.localEulerAngles.x > 330f) 
		{
			transform.Rotate(-0.01f,0.0f,0.0f);
		}
		print (transform.localEulerAngles);
	}
}
