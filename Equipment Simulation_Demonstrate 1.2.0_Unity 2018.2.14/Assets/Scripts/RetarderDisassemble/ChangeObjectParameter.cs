using UnityEngine;
using System.Collections;

public class ChangeObjectParameter : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void ChangeMaterial()
    {
        this.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
    }
}
