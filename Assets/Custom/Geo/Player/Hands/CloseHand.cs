using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CloseHand : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var controller = this.GetComponentInParent<Hand>().controller;
		anim.Play("Take 001", -1, controller.hairTriggerDelta);
	}
}
