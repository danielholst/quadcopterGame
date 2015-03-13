using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

	public Rigidbody body;
	private Vector3 rot;


	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (0, 2 * Mathf.PI, 0);
	}
}
