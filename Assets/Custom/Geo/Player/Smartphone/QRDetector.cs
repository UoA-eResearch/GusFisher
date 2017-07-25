using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRDetector : MonoBehaviour {

	public Collider QRCode;
	public Camera backCam;
	public TextMesh helpText;

	private bool scanning = false;
	
	void Update ()
	{
		if (scanning)
		{
			var planes = GeometryUtility.CalculateFrustumPlanes(backCam);
			if (GeometryUtility.TestPlanesAABB(planes, QRCode.bounds))
			{
				Debug.Log("QR code detected");
				helpText.text = "QR code\ndetected";
				StartCoroutine(PlaySequence());
			}
		}
	}

	private IEnumerator PlaySequence()
	{
		yield return new WaitForSeconds(5);
		Debug.Log("show now");
	}
}
