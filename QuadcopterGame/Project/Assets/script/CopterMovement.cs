using UnityEngine;
using System;
using System.Collections;

public class CopterMovement : MonoBehaviour {

	public Rigidbody body;

	private static float k = 0.1f;
	private static float b = 0.1f;
	private static float d = 2;

	private Matrix4x4 R = new Matrix4x4();

	private float w1;
	private float w2;
	private float w3;
	private float w4;

	private Vector3 rot;

	private Quaternion localRot;

	private Vector3 acc;

//	var pid : PID;
//	var correction = pid.Update(setSpeed, actualSpeed, Time.deltaTime);
//	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.A)) 
		{
			w1 = 1;
		}
		
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			w3 = 1;
		}
		
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			w2 = 1;
		}
		
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			w4 = 1;
		}

		if (Input.GetKeyUp (KeyCode.A)) 
		{
			w1 = 0;
		}
		
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			w3 = 0;
		}
		
		if (Input.GetKeyUp (KeyCode.W)) 
		{
			w2 = 0;
		}
		
		if (Input.GetKeyUp (KeyCode.S)) 
		{
			w4 = 0;
		}
		
		if(Input.GetKey ("space")) 
		{
			w1 = w2 = w3 = w4 = 1;
			
		}

		if(Input.GetKeyUp ("space")) 
		{
			w1 = w2 = w3 = w4 = 0;
			
		}


		localRot = (transform.localRotation); 

//		localRot.x = Math.Abs (localRot.x) - 5;


		//Rotation matrix R, making local rotation to global rotation

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


		rot.x = (float)(k * (Math.Pow (w1, 2) - Math.Pow (w3, 2)));
		rot.y = (float)(b * (Math.Pow (w1, 2) - Math.Pow (w2, 2) + Math.Pow (w3, 2) - Math.Pow (w4, 2)));
		rot.z = (float)(k * (Math.Pow (w2, 2) - Math.Pow (w4, 2)));;
		print (rot);

			acc.x = 0;
			acc.y = (float)(d * (Math.Pow (w1, 2) + Math.Pow (w2, 2) + Math.Pow (w3, 2) + Math.Pow (w4, 2)));;
			acc.z = 0;

			
	

		body.AddTorque(rot);
		body.AddForce (R*acc);

//		if(crossUpdate == null)
//			crossUpdate = cross;
//		
//		crossUpdate = new Vector3(pid.Update(rot.x, crossUpdate.x, Time.deltaTime),
//		                          pid.Update(cross.y, crossUpdate.y, Time.deltaTime),
//		                          pid.Update(cross.z, crossUpdate.z, Time.deltaTime));
//		myObject.rigidbody.AddTorque(crossUpdate*1000);

		    

		}

}
