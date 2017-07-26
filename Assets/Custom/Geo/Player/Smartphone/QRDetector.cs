using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRDetector : MonoBehaviour {

	public Collider QRCode;
	public Camera backCam;
	public TextMesh helpText;
	public GameObject scansAnim;

	private bool scanning = true;
	
	void Update ()
	{
		if (scanning)
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
