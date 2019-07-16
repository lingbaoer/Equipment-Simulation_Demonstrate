using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManualAssemlyManager : MonoBehaviour
{
    #region 减速器组成部件
    /*
     * 用来存放减速器的组成部件，方便后边进行部件组装顺序相关的逻辑操作
     */
    /// <summary>
    /// 低速齿轮轴
    /// </summary>
    public Transform diSuZhou;
    /// <summary>
    /// 中速齿轮轴
    /// </summary>
    public Transform zhongSuZhou;
    /// <summary>
    /// 高速齿轮轴
    /// </summary>
    public Transform gaoSuZhou;
    /// <summary>
    /// 上盖
    /// </summary>
    public Transform shangGai;
    /// <summary>
    /// 固定螺栓--垫片
    /// </summary>
    public Transform[] components_01;
    /// <summary>
    /// 固定螺栓
    /// </summary>
    public Transform[] components_02;
    /// <summary>
    /// 固定螺母
    /// </summary>
    public Transform[] components_03;
    /// <summary>
    /// 轴承盖螺钉--垫片
    /// </summary>
    public Transform[] components_04;
    /// <summary>
    /// 轴承盖螺钉
    /// </summary>
    public Transform[] components_05;
    #endregion

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //处理变速轮轴和上盖之间的组装关系
        if (diSuZhou.GetComponent<ManualAssemlyMouseSelect>().isOk== true
            && zhongSuZhou.GetComponent<ManualAssemlyMouseSelect>().isOk == true
            && gaoSuZhou.GetComponent<ManualAssemlyMouseSelect>().isOk == true)
        {
            shangGai.GetComponent<ManualAssemlyMouseSelect>().isPlay = true;
        }

        //处理上盖和固定螺栓垫片及轴承盖垫片之间的组装关系
        if (shangGai.GetComponent<Animator>().enabled == true)
        {
            for (int i = 0; i < components_01.Length; i++)
            {
                components_01[i].GetComponent<ManualAssemlyMouseSelect>().isPlay = true;
            }
            for (int j = 0; j < components_04.Length; j++)
            {
                components_04[j].GetComponent<ManualAssemlyMouseSelect>().isPlay = true;
            }
            //上盖装上后，没有垫片的螺栓可以直接安装
            for (int k = components_01.Length - 1; k < components_02.Length;k++ )
            {
                components_02[k].GetComponent<ManualAssemlyMouseSelect>().isPlay = true;
            }
        }

        //处理固定螺栓--垫片和固定螺栓之间的组装关系
        for (int i = 0; i < components_01.Length; i++)
        {
            for (int j = 0; j < components_02.Length; j++)
            {
                if (components_01[i].GetComponent<Animator>().enabled == true)
                {
                    components_02[i].GetComponent<ManualAssemlyMouseSelect>().isPlay = true;
                }
            }
        }

        //处理固定螺栓和固定螺母之间的组装关系
        for (int i = 0; i < components_02.Length; i++)
        {
            for (int j = 0; j < components_03.Length; j++)
            {
                if (components_02[i].GetComponent<Animator>().enabled == true)
                {
                    components_03[i].GetComponent<ManualAssemlyMouseSelect>().isPlay = true;
                }
            }
        }

        //处理轴承盖螺钉--垫片和轴承盖螺钉之间的组装关系
        for (int i = 0; i < components_04.Length; i++)
        {
            for (int j = 0; j < components_05.Length; j++)
            {
                if (components_04[i].GetComponent<Animator>().enabled == true)
                {
                    components_05[i].GetComponent<ManualAssemlyMouseSelect>().isPlay = true;
                }
            }
        }
    }
}
