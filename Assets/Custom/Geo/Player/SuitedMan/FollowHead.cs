using System.Collections;
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
		if (head.transform.rotation.eulerAngles.x < 45)
		{
			transform.rotation = Quaternion.Euler(0, head.transform.rotation.eulerAngles.y, 0);
		}
		transform.position = head.transform.position;
		playermodel.transform.localPosition = new Vector3(0, -head.transform.position.y, -0.21f);
		playermodel.transform.localScale = new Vector3(1, head.transform.position.y /2, 1);
	}
}
