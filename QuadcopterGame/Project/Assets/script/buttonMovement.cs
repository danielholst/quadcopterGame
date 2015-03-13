using UnityEngine;
using System.Collections;
using System;

public class buttonMovement : MonoBehaviour {


	public Rigidbody Text;
	private Vector3 movementVec;
	private float counter;
	// Use this for initialization
	void Start () 
	{
		counter = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		counter++;
		movementVec = new Vector3 ((float)Math.Cos (counter/30), 0f, 0f);

		Text.MovePosition(transform.position+movementVec);

	}
}
