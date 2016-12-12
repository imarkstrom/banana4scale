using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderObject : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;

    public GameObject ladaoutside;
    public GameObject ladainside;
    public GameObject mummy;
    public GameObject obi;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "SlideBar")
                {
                    //Vector3 fingerPos = hit.point.z;
                    float z = hit.point.z;
                    if (z < 0.15f && z > -0.15f)
                    {
                        z = 0;
                    }
                    else if (z < -0.15f)
                    {
                        z = -0.3f;
                    }
                    else
                    {
                        z = 0.3f;
                    }
                    transform.position = new Vector3(0.4f, 0f, z);
                    if (z == 0.3f)
                    {
                        showSarcophage();
                    }
                    else if (z == 0)
                    {
                        showMummy();
                    }
                    else
                    {
                        showObi();
                    }
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "SlideBar")
                {
                    //Vector3 fingerPos = hit.point.z;
                    float z = hit.point.z;
                    if (z < 0.15f && z > -0.15f)
                    {
                        z = 0;
                    }
                    else if (z < -0.15f)
                    {
                        z = -0.3f;
                    }
                    else
                    {
                        z = 0.3f;
                    }
                    transform.position = new Vector3(0.4f, 0f, z);
                    if (z == 0.3f)
                    {
                        showSarcophage();
                    }
                    else if (z == 0)
                    {
                        showMummy();
                    }
                    else
                    {
                        showObi();
                    }
                }
            }
        }
    }

    void showSarcophage()
    {
        ladaoutside.GetComponent<MeshRenderer>().enabled = true;
        ladainside.GetComponent<MeshRenderer>().enabled = true;
        mummy.GetComponent<SkinnedMeshRenderer>().enabled = true;
        obi.GetComponent<MeshRenderer>().enabled = true;
    }

    void showMummy()
    {
        ladaoutside.GetComponent<MeshRenderer>().enabled = false;
        ladainside.GetComponent<MeshRenderer>().enabled = false;
        mummy.GetComponent<SkinnedMeshRenderer>().enabled = true;
        obi.GetComponent<MeshRenderer>().enabled = true;
    }

    void showObi()
    {
        ladaoutside.GetComponent<MeshRenderer>().enabled = false;
        ladainside.GetComponent<MeshRenderer>().enabled = false;
        mummy.GetComponent<SkinnedMeshRenderer>().enabled = false;
        obi.GetComponent<MeshRenderer>().enabled = true;
    }
}
