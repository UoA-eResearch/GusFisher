using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGI_Force : MonoBehaviour {

	private float force = 0.05f;
	private Rigidbody rb;
	private float radius = 1.25f;
	private Vector3 centerPosition = new Vector3(-18.63854f, 3.287673f, -0.9795871f);
	private Vector3 direction;
	private float distance;

	void Start(){
		GameObject drone = GameObject.Find ("AGI_Drone");
		rb = drone.AddComponent<Rigidbody> ();
		rb.useGravity = false;
	}

	void FixedUpdate(){
		distance = Vector3.Distance(rb.transform.position, centerPosition);
		Debug.Log ("Distance: " + distance + "Radius: " + radius);
		if (distance > radius) {
			direction = -(rb.transform.position - centerPosition);
			Debug.Log ("Transformed Direction: " + direction);
		} else if (distance < radius) {
			direction = new Vector3 (Random.Range (-1.0f, 1.0f),Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f));
			Debug.Log ("Random Direction: " + direction);
		}
		rb.AddForce (direction * force, ForceMode.Acceleration);
	
	}

}
