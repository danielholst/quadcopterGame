using UnityEngine;
using System.Collections;
using System;

public class movement2 : MonoBehaviour {

	public Rigidbody body;
	public int score;
	private Vector3 refPos;
	private Vector3 posError;
	private float heightError;
	private Vector3 forceVec;
	private Vector3 torqueVec;
	private Quaternion refAng;
	private Quaternion angError;
	// Use this for initialization
	void Start () 
	{
		refPos = new Vector3(65f, 20f, -110f);
		score = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//error in position
		posError = refPos - body.position;
	
		//print (transform.localEulerAngles);
		//print (posError);

		//Inputs to controll quadcopter
		if (Input.GetKey (KeyCode.Q))
		{

			transform.Rotate (new Vector3(0.0f, 1.5f, 0.0f));
		}
		
		if (Input.GetKey (KeyCode.E))
		{
			transform.Rotate (new Vector3(0.0f, -1.5f, 0.0f));
		}

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			refPos.y += 0.2f;
		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			refPos.y -= 0.2f;
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			if (transform.localEulerAngles.z > 20f && transform.localEulerAngles.z < 337f)
			{
				refPos.x -= 0.2f;
			}
			else
				transform.Rotate(new Vector3(0.0f,0f,1.5f));
				refPos.x -= 0.2f;
		}

		if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 23)
		{
			transform.Rotate (new Vector3 (0.0f, 0f, -0.5f));
		}
		
		if (Input.GetKey (KeyCode.D)) 
		{
			if (transform.localEulerAngles.z > 23f && transform.localEulerAngles.z < 340f )
			{
				refPos.x += 0.2f;
			}
			else
				transform.Rotate(new Vector3(0.0f,0f,-1.5f));
				refPos.x += 0.2f;
		}

		if (transform.localEulerAngles.z > 337 && transform.localEulerAngles.z < 360)
		{
			transform.Rotate (new Vector3 (0.0f, 0f, 0.5f));
		}

		if (Input.GetKey (KeyCode.W)) 
		{
				if (transform.localEulerAngles.x > 20f && transform.localEulerAngles.x < 337f )
				{
					refPos.z += 0.2f;
				}
				else
					transform.Rotate(new Vector3(1.5f,0f,0.0f));
					refPos.z += 0.2f;
		}

		if (transform.localEulerAngles.x > 337 && transform.localEulerAngles.x < 360)
		{
			transform.Rotate (new Vector3 (0.5f, 0f, 0.0f));
		}
		
		if (Input.GetKey (KeyCode.S)) 
		{
			if (transform.localEulerAngles.x > 23f && transform.localEulerAngles.x < 340f )
			{
				refPos.z -= 0.2f;
			}
			else
				transform.Rotate(new Vector3(-1.5f,0f,0.0f));
				refPos.z -= 0.2f;
		}
		
		if (transform.localEulerAngles.x > 0 && transform.localEulerAngles.x < 23)
		{
			transform.Rotate (new Vector3 (-0.5f, 0f, 0.0f));
		}

		transform.Translate(posError*Time.deltaTime);

		if (Input.GetKey("escape"))
			Application.Quit();

		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "coin")
		{
			Destroy(other.gameObject);
			score++;

		}
	}
}


