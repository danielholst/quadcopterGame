using UnityEngine;
using System.Collections;
using System;

public class EulerMovement : MonoBehaviour {

	public Rigidbody body;
	private float refHeight;
	private float w1;
	private float w2;
	private float w3;
	private float w4;
	private Vector3 forceVec;
	private float d;
	private Vector3 bodyVelocity;
	private Vector3 prevBodyVelocity;
	private Vector3 bodyPosition;
	private Vector3 prevBodyPosition;
	private float mass;
	private Vector3 gravity;

	// Use this for initialization
	void Start ()
	{
		mass = 0.5f;
		gravity = new Vector3(0f, 9.8f, 0f);
		refHeight = 10f;
		w1 = w2 = w3 = w4 = 0;
		d = 2f;
		prevBodyVelocity = Vector3.zero;
		prevBodyPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if(Input.GetKey ("space")) 
		{
			w1 = w2 = w3 = w4 = 1;
		}
		if(Input.GetKeyUp ("space")) 
		{
			w1 = w2 = w3 = w4 = 0;
			
		}

		//sparar hastigheten och position från förra update
		prevBodyVelocity = bodyVelocity;
		prevBodyPosition = bodyPosition;

		forceVec = GetForceVec(w1, w2, w3, w4, d)-mass * gravity;


		//Euler
		bodyVelocity = prevBodyVelocity + Time.deltaTime * forceVec/mass;
		bodyPosition = prevBodyPosition + Time.deltaTime * bodyVelocity;

		body.MovePosition(bodyPosition); 
		//body.AddForce(forceVec);

	}


//Functions

private Vector3 GetForceVec(float w1, float w2, float w3, float w4, float k)
{
	Vector3 force;

	force.x = 0;
	force.y = (float)(d * (Math.Pow (w1, 2) + Math.Pow (w2, 2) + Math.Pow (w3, 2) + Math.Pow (w4, 2)));;
	force.z = 0;

	return force;	
}

	private Vector3 GetBodyVelocity (Vector3 forceVec, float mass)
	{
		Vector3 bodyVelocity;
		bodyVelocity.x = 0;
		bodyVelocity.y = forceVec.y/mass * Time.deltaTime;
		bodyVelocity.z = 0;

		return bodyVelocity;
	}

}