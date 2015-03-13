using UnityEngine;
using System;
using System.Collections;

public class movement3 : MonoBehaviour {
	
	public Rigidbody body;
	Animator anim; 
	
	private static float k = 0.1f;
	private static float b = 0.1f;
	private static float d = 2;
	
	private Matrix4x4 R = new Matrix4x4();
	
	private float w1;
	private float w2;
	private float w3;
	private float w4;
	
	private Vector3 rot;
	
	private Vector3 localRot;
	
	private Vector4 acc;
//	bool thrust = false;
	//	var pid : PID;
	//	var correction = pid.Update(setSpeed, actualSpeed, Time.deltaTime);
	//	
	// Update is called once per frame

	void start ()
	{

		anim = GetComponent <Animator> ();
	}
	void Update ()
	{

//		thrust = false;
//false		body.AddForce = 0;
		R = Matrix4x4.identity;
		
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate (new Vector3(0.0f, 0.0f, 3.0f));
		}

		if (Input.GetKey (KeyCode.Q))
		{
			transform.Rotate (new Vector3(0.0f, 3.0f, 0.0f));
		}

		if (Input.GetKey (KeyCode.E))
		{
			transform.Rotate (new Vector3(0.0f, -3.0f, 0.0f));
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate (new Vector3(0.0f, 0.0f, -3.0f));
		}
		
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Rotate (new Vector3(3.0f, 0.0f, 0.0f));
		}
		
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Rotate (new Vector3(-3.0f, 0.0f, 0.0f));
		}

		
		if(Input.GetKey ("space")) 
		{
			w1 = w2 = w3 = w4 = 1;
//			thrust = true;
//			anim.SetBool ("isflying", thrust);
//			
		}
		
		if(Input.GetKeyUp ("space")) 
		{
			w1 = w2 = w3 = w4 = 0;

		}

		localRot = (transform.localRotation).ToEulerAngles(); 
		//print (localRot);

		R = GetRotMatZYX (localRot);
		print (R);

		acc.x = 0;
		acc.y = (float)(d * (Math.Pow (w1, 2) + Math.Pow (w2, 2) + Math.Pow (w3, 2) + Math.Pow (w4, 2)));;
		acc.z = 0;
		acc.w = 0;
		
		

		body.AddForce (R*acc);
		
		
		
	}


	//rotMat ZYX
	private Matrix4x4 GetRotMatZYX(Vector3 localRot)
	{
		Matrix4x4 R = new Matrix4x4();

				R.SetColumn(0, new Vector4((float)(Math.Cos (localRot.y)*Math.Cos (localRot.z)),
				                           (float)(-Math.Cos (localRot.y)*Math.Sin (localRot.z)),
				                           (float)(Math.Sin(localRot.y)),
				                           (1.0f)));
				
				R.SetColumn(1, new Vector4((float)(Math.Cos (localRot.x)*Math.Sin (localRot.z) + Math.Cos (localRot.z)*Math.Sin (localRot.x)*Math.Sin (localRot.y)),
				                           (float)(Math.Cos (localRot.x)*Math.Cos (localRot.z) - Math.Sin (localRot.x)*Math.Sin (localRot.y)*Math.Sin (localRot.z)),
				                           (float)(Math.Cos (localRot.y)*Math.Sin(localRot.x)),
				                           1f));
				
				
				R.SetColumn(2, new Vector4((float)(Math.Sin (localRot.x)*Math.Sin (localRot.z) - Math.Cos (localRot.x)*Math.Cos (localRot.z)*Math.Sin (localRot.y)),
				                           (float)(Math.Cos (localRot.z)*Math.Sin (localRot.x) + Math.Cos (localRot.x)*Math.Sin (localRot.y)*Math.Sin (localRot.z)),
				                           (float)(Math.Cos (localRot.x)*Math.Cos(localRot.y)),
				                           1f));
				
				R.SetColumn (3, new Vector4(0,0,0,1f));

//		R.SetColumn(0, new Vector4((float)(Math.Cos (localRot.y)*-Math.Cos (localRot.x)),
//		                           (float)(Math.Cos (localRot.x)*Math.Sin (localRot.y)),
//		                           (float)(Math.Sin(localRot.x)),
//		                           (1.0f)));
//		
//		R.SetColumn(1, new Vector4((float)(-Math.Cos (localRot.z)*Math.Sin (localRot.y) - Math.Cos (localRot.y)*Math.Sin (localRot.x)*Math.Sin (localRot.z)),
//		                           (float)(Math.Cos (localRot.y)*Math.Cos (localRot.z) - Math.Sin (localRot.x)*Math.Sin (localRot.y)*Math.Sin (localRot.z)),
//		                           (float)(-Math.Cos (localRot.x)*Math.Sin(localRot.z)),
//		                           1f));
//		
//		
//		R.SetColumn(2, new Vector4((float)(Math.Sin (localRot.y)*Math.Sin (localRot.z) - Math.Cos (localRot.y)*Math.Cos (localRot.z)*Math.Sin (localRot.x)),
//		                           (float)(-Math.Cos (localRot.z)*Math.Sin (localRot.y)*Math.Sin (localRot.x) - Math.Cos (localRot.y)*Math.Sin (localRot.z)),
//		                           (float)(-Math.Cos (localRot.x)*Math.Cos(localRot.z)),
//		                           1f));
//		
//		R.SetColumn (3, new Vector4(0,0,0,1f));
		
		return R;
		
		
	}
	// rotMat ZYZ
	private Matrix4x4 GetRotMatZYZ(Vector3 localRot)
	{
		Matrix4x4 R = new Matrix4x4();

		R.SetColumn(0, new Vector4((float)(-Math.Cos (localRot.x)*Math.Cos (localRot.z)),
		                           (float)(-Math.Sin (localRot.z)*Math.Sin (localRot.y)*Math.Cos (localRot.z)+Math.Cos (localRot.y)*Math.Sin (localRot.y)),
		                           (float)(-Math.Cos (localRot.z)*Math.Sin (localRot.y)*Math.Cos (localRot.z) - Math.Sin (localRot.y)*Math.Sin (localRot.z)),
		                           (1f)));
		
		R.SetColumn(1, new Vector4((float)(-Math.Cos (localRot.y)*Math.Sin (localRot.z)),
		                           (float)(-Math.Sin (localRot.y)*Math.Sin (localRot.x)*Math.Sin (localRot.z)- Math.Cos (localRot.y)*Math.Cos (localRot.z)),
		                           (float)(-Math.Cos (localRot.z)*Math.Sin (localRot.x)*Math.Sin (localRot.z) + Math.Sin (localRot.y)*Math.Cos (localRot.z)),
		                           (1)));
		
		
		R.SetColumn(2, new Vector4((float)(-Math.Sin (localRot.x)),
		                           (float)(-Math.Sin (localRot.y)*Math.Cos (localRot.x)),
		                           (float)(-Math.Cos (localRot.y)*Math.Cos(localRot.x)),
		                           1f));
		
		R.SetColumn (3, new Vector4(0,0,0,1f));

		return R;
	}
}
