using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MouseSelectManager : MonoBehaviour
{
    #region 减速器组成部件
    /*
     * 用来存放减速器的组成部件，方便后边进行部件拆解顺序相关的逻辑操作
     */
    /// <summary>
    /// 轴承盖螺钉
    /// </summary>
    public Transform[] components_01;
    /// <summary>
    /// 轴承盖螺钉——垫片
    /// </summary>
    public Transform[] components_02;
    /// <summary>
    /// 固定螺母
    /// </summary>
    public Transform[] components_03;
    /// <summary>
    /// 固定螺栓
    /// </summary>
    public Transform[] components_04;
    /// <summary>
    /// 固定螺栓——垫片
    /// </summary>
    public Transform[] components_05;
    /// <summary>
    /// 变速轮轴
    /// </summary>
    public Transform[] components_06;
    /// <summary>
    /// 上盖
    /// </summary>
    public Transform shangGai;
    #endregion

    /// <summary>
    /// 用来存放拆下来的轴承盖螺钉--垫片
    /// </summary>
    private List<Transform> luoDingDP;

    /// <summary>
    /// 用来存放拆下来的固定螺栓
    /// </summary>
    private List<Transform> luoShuan;

    /// <summary>
    /// 用来存放拆下来的固定螺栓--垫片
    /// </summary>
    private List<Transform> luoShuanDP;

    // Use this for initialization
    void Start()
    {
        //轴承盖螺钉和固定螺母一开始就具有可操作性
        for (int i = 0; i < components_01.Length; i++)
        {
            components_01[i].GetComponent<ChangeSelectObjectColor>().isPlay = true;
        }
        for (int i = 0; i < components_03.Length; i++)
        {
            components_03[i].GetComponent<ChangeSelectObjectColor>().isPlay = true;
        }

        luoDingDP = new List<Transform>();
        luoShuanDP = new List<Transform>();
        luoShuan = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //处理轴承盖螺钉和垫片之间的拆解关系
        for (int i = 0; i < components_01.Length; i++)
        {
            for (int j = 0; j < components_02.Length; j++)
            {
                if (components_01[i].GetComponent<Animator>().enabled == true)
                {
                    components_02[i].GetComponent<ChangeSelectObjectColor>().isPlay = true;
                }
            }
        }

        //存放拆下的螺钉垫片
        for (int i = 0; i < components_02.Length; i++)
        {
            if (components_02[i].GetComponent<Animator>().enabled == true)
            {
                if (!luoDingDP.Contains(components_02[i]))
                {
                    luoDingDP.Add(components_02[i]);
                }
            }
        }

        //处理固定螺母和固定螺栓之间的拆解关系
        for (int i = 0; i < components_03.Length; i++)
        {
            for (int j = 0; j < components_04.Length; j++)
            {
                if (components_03[i].GetComponent<Animator>().enabled == true)
                {
                    components_04[i].GetComponent<ChangeSelectObjectColor>().isPlay = true;
                }
            }
        }

        //存放拆下的螺栓
        for (int i = 0; i < components_04.Length; i++)
        {
            if (components_04[i].GetComponent<Animator>().enabled == true)
            {
                if (!luoShuan.Contains(components_04[i]))
                {
                    luoShuan.Add(components_04[i]);
                }
            }
        }

        //处理固定螺栓和垫片之间的拆解关系
        for (int i = 0; i < components_04.Length-4; i++)
        {
            for (int j = 0; j < components_05.Length; j++)
            {
                if (components_04[i].GetComponent<Animator>().enabled == true)
                {
                    components_05[i].GetComponent<ChangeSelectObjectColor>().isPlay = true;
                }
            }
        }

        //存放拆下的螺栓垫片
        for (int i = 0; i < components_05.Length; i++)
        {
            if (components_05[i].GetComponent<Animator>().enabled == true)
            {
                if (!luoShuanDP.Contains(components_05[i]))
                {
                    luoShuanDP.Add(components_05[i]);
                }
            }
        }

        //上盖的拆解
        if (luoDingDP.Count == components_02.Length && luoShuan.Count == components_03.Length&&luoShuanDP.Count==8)
        {
            shangGai.GetComponent<ChangeSelectObjectColor>().isPlay = true;
        }

        //变速轮轴的拆解
        if (shangGai.GetComponent<Animator>().enabled == true)
        {
            for (int i = 0; i < components_06.Length; i++)
            {
                components_06[i].GetComponent<ChangeSelectObjectColor>().isPlay = true;
            }
        }
    }

}


