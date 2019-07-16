using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (IsMouseOverUI == true)
        {
            GameObject.Find("Main Camera").GetComponent<MouseOrbit>().isOnHove = false;
            GameObject.Find("Camera").GetComponent<MouseControlModel>().isOnHove = true;
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<MouseOrbit>().isOnHove = true;
            GameObject.Find("Camera").GetComponent<MouseControlModel>().isOnHove = false;
        }
	}

    public static bool IsMouseOverUI
    {
        get
        {
            Vector3 mousePosition = Input.mousePosition;
            GameObject hoverobject = UICamera.Raycast(mousePosition, out UICamera.lastHit) ? UICamera.lastHit.collider.gameObject : null;

            if (hoverobject != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
