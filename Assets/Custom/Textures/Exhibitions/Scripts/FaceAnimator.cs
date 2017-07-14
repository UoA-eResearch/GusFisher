using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAnimator : MonoBehaviour {

	public Material[] matArray;
	public bool isAnimating;
	public int index = 0;
	public float updateDelay = .5f;
	private float lastChange = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isAnimating && Time.time - lastChange > updateDelay)
		{
			lastChange = Time.time;
			GetComponent<Renderer>().material = matArray[++index % matArray.Length];
		}
	}
}
