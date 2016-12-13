using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderObject : MonoBehaviour
{

	private Ray ray;
	private RaycastHit hit;

	public GameObject ladaoutside;
	public GameObject ladainside;
	public GameObject mummy;
	public GameObject obi;
	public GameObject sarkofagbutton, mummybutton, obibutton;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			print (ray);
			float newz = 0;
			bool didhit = false;
			if (Physics.Raycast (ray, out hit)) {
				print (hit.collider.gameObject);
				if (hit.collider.gameObject == sarkofagbutton) {
					newz = hit.collider.gameObject.transform.localPosition.z;
					showSarcophage ();
					didhit = true;
				} else if (hit.collider.gameObject == mummybutton) {
					newz = hit.collider.gameObject.transform.localPosition.z;
					showMummy ();
					didhit = true;
				} else if (hit.collider.gameObject == obibutton) {
					newz = hit.collider.gameObject.transform.localPosition.z;
					showObi (1);
					didhit = true;
				}
				if (didhit) {
					Vector3 originalposition = transform.localPosition;
					transform.localPosition = new Vector3 (originalposition.x, originalposition.y, newz);
				}
			}
		}
		if (Input.touchCount > 0) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			print (ray);
			float newz = 0;
			bool didhit = false;
			if (Physics.Raycast (ray, out hit)) {
				print (hit.collider.gameObject);
				if (hit.collider.gameObject == sarkofagbutton) {
					newz = hit.collider.gameObject.transform.localPosition.z;
					showSarcophage ();
					didhit = true;
				} else if (hit.collider.gameObject == mummybutton) {
					newz = hit.collider.gameObject.transform.localPosition.z;
					showMummy ();
					didhit = true;
				} else if (hit.collider.gameObject == obibutton) {
					newz = hit.collider.gameObject.transform.localPosition.z;
					showObi (1);
					didhit = true;
				}
				if (didhit) {
					Vector3 originalposition = transform.localPosition;
					transform.localPosition = new Vector3 (originalposition.x, originalposition.y, newz);
				}
			}
		}
	}



	
	

	void showSarcophage ()
	{
		//ladaoutside.GetComponent<MeshRenderer> ().enabled = true;
		ladainside.GetComponent<MeshRenderer> ().enabled = true;
		mummy.GetComponent<SkinnedMeshRenderer> ().enabled = true;
		obi.GetComponent<MeshRenderer> ().enabled = true;

		ladaoutside.GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Standard");
		ladainside.GetComponent<MeshRenderer> ().material.shader = Shader.Find ("Standard");
		//ladaoutside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 1.0f);
		//ladainside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 1.0f);
	}

	void showMummy ()
	{
		ladaoutside.GetComponent<MeshRenderer> ().enabled = true;
		ladainside.GetComponent<MeshRenderer> ().enabled = true;
		mummy.GetComponent<SkinnedMeshRenderer> ().enabled = true;
		//obi.GetComponent<MeshRenderer>().enabled = true;
		/*
        Shader shader = Shader.Find("Mobile/Mobile-XrayEffect");
        ladaoutside.GetComponent<MeshRenderer>().material.shader = Shader.Find("Mobile/Mobile-XrayEffect");
        ladainside.GetComponent<MeshRenderer>().material.shader = Shader.Find("Mobile/Mobile-XrayEffect");
        ladaoutside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", zper);
        ladainside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", zper);*/
		mummy.GetComponent<SkinnedMeshRenderer> ().material.shader = Shader.Find ("Standard");

	}

	void showObi (float zper)
	{
		ladaoutside.GetComponent<MeshRenderer> ().enabled = true;
		ladainside.GetComponent<MeshRenderer> ().enabled = true;
		if (zper == 0) {
			mummy.GetComponent<SkinnedMeshRenderer> ().enabled = false;
		} else {
			mummy.GetComponent<SkinnedMeshRenderer> ().enabled = true;
		}
		//obi.GetComponent<MeshRenderer>().enabled = true;

		//ladaoutside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 0f);
		//ladainside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 0f);
		mummy.GetComponent<SkinnedMeshRenderer> ().material.shader = Shader.Find ("Mobile/Mobile-XrayEffect");
		mummy.GetComponent<SkinnedMeshRenderer> ().material.SetFloat ("_Inside", zper);


	}
}
