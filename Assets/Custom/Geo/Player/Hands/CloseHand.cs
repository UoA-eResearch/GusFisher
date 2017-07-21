using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CloseHand : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var controller = this.GetComponentInParent<Hand>().controller;
		Vector2 triggerPosition = controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger);
		Debug.Log(triggerPosition);
		anim.Play("Take 001", -1, triggerPosition.x);
	}
}
