using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flap : MonoBehaviour {

	public float range = 45f;
	public float speed = 1f;

	private Quaternion top;
	private Quaternion bottom;

	// Use this for initialization
	void Start () {
		top = transform.rotation * Quaternion.Euler(range, range, 1);
		bottom = transform.rotation * Quaternion.Euler(-range, -range, 1);
	}
	
	// Update is called once per frame
	void Update () {
		var t = (Mathf.Sin(Time.time * speed) + 1) / 2f;
		transform.rotation = Quaternion.Lerp(top, bottom, t);
	}
}
