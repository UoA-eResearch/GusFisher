using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToHead : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "HeadCollider")
		{
			foreach (var r in gameObject.GetComponentsInChildren<Renderer>())
			{
				r.enabled = false;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "HeadCollider")
		{
			foreach (var r in gameObject.GetComponentsInChildren<Renderer>())
			{
				r.enabled = true;
			}
		}
	}
}
