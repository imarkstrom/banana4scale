using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateXray : MonoBehaviour
{

	private Ray ray;
	private RaycastHit hit;
	public Camera cam;
	public Material mat;

	public float smallNearClipPlane = 0.01f;
	public float bigNearClipPlane = 1;
	private bool pressed = true;

	// Use this for initialization
	void Start ()
	{
		mat.color = Color.green;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var carver = cam.GetComponent<CarverScript> ();
		//touch input
		if (Input.touchCount > 0) {
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.gameObject.name == "Button") {
					pressed = !pressed;
					Debug.Log ("Pressed button");

					if (pressed) {
						carver.MakeActive ();
						cam.GetComponent<Camera> ().nearClipPlane = bigNearClipPlane;
						mat.color = Color.green;
					} else {
						carver.MakeInactive ();
						cam.GetComponent<Camera> ().nearClipPlane = smallNearClipPlane;
						mat.color = Color.red;
					}
				}
			}
		}
		//mouse input
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.gameObject.name == "Button") {
					pressed = !pressed;
					Debug.Log ("Pressed button");

					if (pressed) {
						carver.MakeActive ();
						cam.GetComponent<Camera> ().nearClipPlane = bigNearClipPlane;
						mat.color = Color.green;
					} else {
						carver.MakeInactive ();
						cam.GetComponent<Camera> ().nearClipPlane = smallNearClipPlane;
						mat.color = Color.red;
					}
				}
			}
		}
	}
}
