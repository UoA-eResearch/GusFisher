﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour {

	public GameObject head;
	public GameObject playermodel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float angle = head.transform.rotation.eulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;
		if (angle < 45)
		{
			transform.rotation = Quaternion.Euler(0, head.transform.rotation.eulerAngles.y, 0);
		}
		transform.position = head.transform.position;
	}
}
