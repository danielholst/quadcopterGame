using UnityEngine;
using System;
using System.Collections;

public class movement : MonoBehaviour {

	private Vector3 position;
	public Transform target;
	public float smoothing = 5f;
	Vector3 offset;

	// Use this for initialzation
	void Start () 
	{
		position = transform.position;
		offset = position - target.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

	
//		if (Input.GetKey (KeyCode.Q))
//		{
//			
//			transform.Rotate (new Vector3(0.0f, 1.5f, 0.0f));
//		}
//		
//		if (Input.GetKey (KeyCode.E))
//		{
//			transform.Rotate (new Vector3(0.0f, -1.5f, 0.0f));
//		}

		Vector3 targetCamPos = target.position + offset ;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
				
	}
		
}