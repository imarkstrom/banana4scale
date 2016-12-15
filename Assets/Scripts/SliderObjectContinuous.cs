using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderObjectContinuous : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;

    public GameObject ladaoutside;
    public GameObject ladainside;
    public GameObject mummy;
    public GameObject obi;
    public GameObject sarkofagbutton, mummybutton, obibutton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)/* || Input.touchCount > 0*/)
        {
            if (Input.GetMouseButton(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }/* else {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            }*/

            float newz = 0;
            float perz = 0;
            bool didhit = false;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "SlideBar")
                {
                    newz = hit.point.y - 1.156f;
                    float end = -1.16f - 1.156f;
                    perz = newz / end;
                    Debug.Log(perz);
                    calculateLayer(perz);
                    didhit = true;
                }
                if (didhit)
                {
                    transform.position = new Vector3(0.973279f, hit.point.y, -0.4670012f);
                }
            }
        }
    }

    void calculateLayer(float percent) {
        if(percent < 0.05) {
            showSarcophage(0);
        } else if (0.05f <= percent && percent < 0.33f) {
            if (0.23f < percent) { showObi(0); }
            else { showObi((1-percent/0.33f)); };
        }
        else if (0.33f <= percent && percent < 0.66f) {
            if (0.56f < percent) { showObi(0); }
            else { showObi((1-(percent-0.33f)/0.33f)); };
        }
        else {
            if (0.95f < percent) { showObi(0); }
            else { showObi((1-(percent-0.66f)/0.33f)); }
        }
    }

    void showSarcophage(float per)
    {
        //ladaoutside.GetComponent<MeshRenderer> ().enabled = true;
        ladainside.GetComponent<MeshRenderer>().enabled = true;
        mummy.GetComponent<SkinnedMeshRenderer>().enabled = true;
        obi.GetComponent<MeshRenderer>().enabled = true;
        Debug.Log("sacro");
        //ladaoutside.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        //ladainside.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        //ladaoutside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 1.0f);
        //ladainside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 1.0f);
    }

    void showMummy(float per)
    {
        Debug.Log("mummy");
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
        //ladaoutside.GetComponent<MeshRenderer>().enabled = true;
        //ladainside.GetComponent<MeshRenderer>().enabled = true;
        if (zper == 0) {
            mummy.GetComponent<SkinnedMeshRenderer>().enabled = false;
        } else {
            mummy.GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
        //obi.GetComponent<MeshRenderer>().enabled = true;
        Debug.Log("obi");
        //ladaoutside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 0f);
        //ladainside.GetComponent<MeshRenderer>().material.SetFloat("_Inside", 0f);
        mummy.GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Mobile/Mobile-XrayEffect");
        mummy.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Inside", zper);


    }
}