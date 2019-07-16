using UnityEngine;
using System.Collections;

public class StartUIHandel : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    /// <summary>
    /// 跳转到雷达车仿真训练场景
    /// </summary>
    public void RadarVechile()
    {
        Application.LoadLevel("EquipmentSimulationScene");
    }
}
