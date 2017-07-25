using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {
	public DictationScript ds;
	void OnHandHoverBegin()
	{
		ds.OnButtonPush(gameObject);
	}
}
