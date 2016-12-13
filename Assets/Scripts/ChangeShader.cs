using UnityEngine;
using System.Collections;

public class ChangeShader : MonoBehaviour {
    private MeshRenderer[] layers;

	// Use this for initialization
	void Start () {

        layers = gameObject.GetComponentsInChildren<MeshRenderer>();
        Debug.Log("");
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Material layerMaterial = layers[0].material;
            //Material layerMaterial = new Material()
            layerMaterial.shader = Shader.Find("Mobile-XrayEffect");
            layerMaterial.SetFloat("_Inside", 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Material layerMaterial = layers[1].material;
            layerMaterial.SetFloat("_Inside", 0.5f);
        }

    }
}
