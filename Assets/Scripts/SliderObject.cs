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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "SlideBar")
                {
                    float z = hit.point.z;
                    /*if (z < 0.15f && z > -0.15f)
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
                    }*/
                    if (z > 0.3f)
                    {
                        z = 0.3f;
                    }
                    else if (z < -0.3f)
                    {
                        z = -0.3f;
                    }
                    transform.position = new Vector3(0.4f, 0f, z);
                    float zper = z / 0.3f;
                    if (zper == 1)
                    {
                        showSarcophage();
                    }
                    else if (z >= 0)
                    {
                        showMummy(zper);
                    }
                    else
                    {
                        showObi((1 + zper));
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
                    float z = hit.point.z;
                    /*if (z < 0.15f && z > -0.15f)
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
                    }*/
                    if (z > 0.3f)
                    {
                        z = 0.3f;
                    }
                    else if (z < -0.3f)
                    {
                        z = -0.3f;
                    }
                    transform.position = new Vector3(0.4f, 0f, z);
                    float zper = z / 0.3f;
                    if (zper == 1)
                    {
                        showSarcophage();
                    }
                    else if (z >= 0)
                    {
                        showMummy(zper);
                    }
                    else
                    {
                        showObi((1 + zper));
                    }
                }
            }
        }
    }

    void showSarcophage()
    {
        /*ladaoutside.GetComponent<MeshRenderer>().enabled = true;
        ladainside.GetComponent<MeshRenderer>().enabled = true;
        mummy.GetComponent<SkinnedMeshRenderer>().enabled = true;
        obi.GetComponent<MeshRenderer>().enabled = true;

        ladaoutside.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        ladainside.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        //ladaoutside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 1.0f);
        //ladainside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 1.0f);*/
    }

    void showMummy(float zper)
    {
        ladaoutside.GetComponent<MeshRenderer>().enabled = true;
        ladainside.GetComponent<MeshRenderer>().enabled = true;
        mummy.GetComponent<SkinnedMeshRenderer>().enabled = true;
        //obi.GetComponent<MeshRenderer>().enabled = true;
        /*
        Shader shader = Shader.Find("Mobile/Mobile-XrayEffect");
        ladaoutside.GetComponent<MeshRenderer>().material.shader = Shader.Find("Mobile/Mobile-XrayEffect");
        ladainside.GetComponent<MeshRenderer>().material.shader = Shader.Find("Mobile/Mobile-XrayEffect");
        ladaoutside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", zper);
        ladainside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", zper);*/
        mummy.GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Standard");

    }

    void showObi(float zper)
    {
        ladaoutside.GetComponent<MeshRenderer>().enabled = true;
        ladainside.GetComponent<MeshRenderer>().enabled = true;
        if (zper == 0)
        {
            mummy.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
        else
        {
            mummy.GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
        //obi.GetComponent<MeshRenderer>().enabled = true;

        //ladaoutside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 0f);
        //ladainside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 0f);
        mummy.GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Mobile/Mobile-XrayEffect");
        mummy.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Inside", zper);


    }
}
