using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModulesShowUIManager : MonoBehaviour 
{
    /// <summary>
    /// 用来控制组件展示的按钮
    /// </summary>
    public Transform[] modulesBtns;

    /// <summary>
    /// 用来展示的组件
    /// </summary>
    public GameObject[] modules;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        for (int i = 0; i < modulesBtns.Length; i++)
        {
            for (int j = 0; j < modules.Length; j++)
            {
                modules[i].SetActive(false);
                if (modulesBtns[i].GetComponent<UIButton>().isEnabled == false)
                {
                    modules[i].SetActive(true);
                }
            }
        }
	}
}
