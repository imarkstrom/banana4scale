using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarverScript : MonoBehaviour
{
	public Camera cam;
	public GameObject mummy;
	//public GameObject depthmask;
	public GameObject depthmaskpasstwo;
	public GameObject videoplane;
	public ParticleSystem woweffect;

	// Use this for initialization
	public float zoomdistance = 5;
	private bool carve;

	public GameObject magnifyingglass;

	void Start ()
	{
		carve = true;

	}

	public void MakeActive ()
	{
		carve = true;
	}

	public void MakeInactive ()
	{
		carve = false;
	}

	// Update is called once per frame
	void Update ()
	{
		//zoomdistance = Math.Abs ((GetComponent<Camera> ().transform.position - mummy.transform.position).magnitude);

		if (carve) {
			float lastplace = videoplane.transform.localPosition.z;
			videoplane.transform.localPosition = new Vector3 (0, 0, 0.5f);
			videoplane.transform.localScale = videoplane.transform.localScale / lastplace / 2.0f; 
			cam.nearClipPlane = 0.01f;
			magnifyingglass.SetActive (true);
		} else {
			cam.nearClipPlane = 1.5f;
			magnifyingglass.SetActive (false);
		}
		Vector3 mummyposition = mummy.transform.position;
		Vector3 cameraposition = cam.transform.position;
		Vector3 cameradiff = mummyposition - cameraposition;

		/*
		float cameradiffdistance = zoomdistance - Math.Abs (cameradiff.magnitude);
		//depthmask.transform.position = cameradiff * newdistance;
		print ("cameradeiffdist " + cameradiffdistance.ToString ());

		//Debug.LogError (cameradiff.ToString ());
		//float scalefactor = ((cameradiffdistance - zoomdistance) - 1f) / (float)Math.Pow (cameradiffdistance, 2);

		depthmask.transform.localScale = new Vector3 (scalefactor, scalefactor, scalefactor);
		depthmask.transform.localPosition = (zoomdistance - 2.0f * cameradiffdistance) * Vector3.forward;
		*/

		float cameradifference = cameradiff.magnitude;
		float maskscale = (zoomdistance / cameradifference - 1) * 0.5f;
		if (maskscale > 10f) {
			maskscale = 10f;
		}
		if (maskscale < 0) {
			maskscale = 0f;
		}
		//depthmask.transform.localScale = new Vector3 (maskscale, maskscale, maskscale);
		/*
		try {
			Vector3 sarcloc = sarcofague.transform.localPosition;
			if (sarcloc.z < 0.0001) {
				sarcloc.z = 1;
			}
			depthmask.transform.localPosition = new Vector3 (sarcloc.x / sarcloc.z, sarcloc.y / sarcloc.z, 1);
			depthmaskpasstwo.transform.localPosition = new Vector3 (sarcloc.x / sarcloc.z * 10f, sarcloc.y / sarcloc.z * 10f, 10);
		} catch {
		}*/
		ParticleSystem.ShapeModule sm = woweffect.shape;
		if (carve && maskscale > 0.01) {
			depthmaskpasstwo.SetActive (true);
			depthmaskpasstwo.transform.localScale = new Vector3 (maskscale, maskscale, maskscale) * 10.0f;
			magnifyingglass.transform.localScale = depthmaskpasstwo.transform.localScale / 90f;
			print (maskscale);
			sm.radius = maskscale * 0.12f;
		} else {
			//depthmaskpasstwo.transform.localScale = new Vector3 (200, 200, 1) * 0.25f;
			depthmaskpasstwo.SetActive (false);
			magnifyingglass.transform.localScale = Vector3.zero;
			sm.radius = 1000000000;
		}
	}
}
