using UnityEngine;
using System.Collections;

public class TreeContract : MonoBehaviour {

    /// <summary>
    /// 是否收缩
    /// </summary>
    [HideInInspector]
    public bool isContract=false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    /// <summary>
    /// 点击树图结构父节点，子节点收缩/展开
    /// </summary>
    public void OnClick()
    {
        if (isContract == false)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<BoxCollider>())
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            isContract = true;
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeSelf==false)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            isContract = false;
        }
    }
}
