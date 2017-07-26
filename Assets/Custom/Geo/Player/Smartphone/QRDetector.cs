using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class QRDetector : MonoBehaviour {

	public Collider QRCode;
	public Camera backCam;
	public TextMesh helpText;
	public GameObject scansAnim;
	public Pickupable pickup;

	private bool scanning = true;
	
	void Update ()
	{
		if (scanning && pickup.attached)
		{
			var planes = GeometryUtility.CalculateFrustumPlanes(backCam);
			if (GeometryUtility.TestPlanesAABB(planes, QRCode.bounds))
			{
				Debug.Log("QR code detected");
				helpText.text = "QR code\ndetected";
				scanning = false;
				StartCoroutine(PlaySequence());
			}
		}
	}

	private IEnumerator PlaySequence()
	{
		yield return new WaitForSeconds(5);
		Debug.Log("show now");
		helpText.gameObject.SetActive(false);
		scansAnim.SetActive(true);
	}
}
