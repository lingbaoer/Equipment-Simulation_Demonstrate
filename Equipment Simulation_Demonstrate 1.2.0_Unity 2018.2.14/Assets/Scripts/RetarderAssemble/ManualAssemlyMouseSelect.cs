using UnityEngine;
using System.Collections;

public class ManualAssemlyMouseSelect : MonoBehaviour
{
    /// <summary>
    /// 模型部件原来的颜色
    /// </summary>
    private Color oldColor;

    /// <summary>
    /// 模型部件原来的shader
    /// </summary>
    private Shader oldShader;

    /// <summary>
    /// 在手动组装减速器过程中用来判断是否播放所选模型组件的组装动画
    /// </summary>
    public bool isPlay = false;

    /// <summary>
    /// 在手动组装过程中用来判断低、中、高速轮轴是否组装完成
    /// </summary>
    public bool isOk = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 当鼠标进入部件时，部件变色
    /// </summary>
    void OnMouseEnter()
    {
        oldColor = this.gameObject.GetComponent<Renderer>().material.color;
        oldShader = this.gameObject.GetComponent<Renderer>().material.shader;
        this.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    /// <summary>
    /// 当鼠标离开时，部件回复原来的颜色
    /// </summary>
    void OnMouseExit()
    {
        this.gameObject.GetComponent<Renderer>().material.shader = oldShader;

        this.gameObject.GetComponent<Renderer>().material.color = oldColor;
    }

    /// <summary>
    /// 当鼠标点击模型组件，且符合条件是，播放组件的拆解动画
    /// </summary>
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.name == this.name)
                {
                    if (Globe.isManualAssembly == true)
                    {
                        if (this.transform.GetComponent<Animator>() != null)
                        {
                            if (isPlay == true)
                            {
                                this.transform.GetComponent<Animator>().enabled = true;
                            }
                            else
                            {
                                Debug.Log("组装顺序错误！");
                            }
                            //安装低速齿轮轴
                            if (this.transform.gameObject.name == "DiSuZhou")
                            {
                                if (this.transform.Find("DiSuDuanGai_L").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                        || this.transform.Find("DiSuDuanGai_R").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.GetComponent<Animator>().SetInteger("Step", 4);
                                    isOk = true;
                                }
                                else
                                {
                                    isPlay = false;
                                    isOk = false;
                                }
                            }

                            //安装中速齿轮轴
                            if (this.transform.gameObject.name == "ZhongSuChiLunZhou")
                            {
                                if (this.transform.Find("ZhongSuDuanGai_L").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                        || this.transform.Find("ZhongSuDuanGai_R").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.GetComponent<Animator>().SetInteger("Step", 4);
                                    isOk = true;
                                }
                                else
                                {
                                    isPlay = false;
                                    isOk = false;
                                }
                            }

                            //安装高速轮轴
                            if (this.transform.gameObject.name == "GaoSuChiLunZhou")
                            {
                                if (this.transform.Find("GaoSuDuanGai_L").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                        || this.transform.Find("GaoSuDuanGai_R").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.GetComponent<Animator>().SetInteger("Step", 3);
                                    isOk = true;
                                }
                                else
                                {
                                    isPlay = false;
                                    isOk = false;
                                }
                            }
                        }
                        else
                        {
                            #region 组装低速轮轴
                            //组装直齿轮
                            if (this.transform.gameObject.name == "ZhiChiLun")
                            {
                                this.transform.parent.GetComponent<Animator>().enabled = true;
                                isPlay = true;
                            }

                            //组装低速轴轴承--dyh
                            if (this.transform.gameObject.name == "ZhouCheng_dyh_L01" || this.transform.gameObject.name == "ZhouCheng_dyh_R01")
                            {
                                if (this.transform.parent.transform.Find("ZhiChiLun").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 1);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //组装低速轴轴承
                            if (this.transform.gameObject.name == "ZhouCheng_L01" || this.transform.gameObject.name == "ZhouCheng_R01")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_dyh_L01").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_dyh_R01").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 2);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //组装低速轴轴承端盖
                            if (this.transform.gameObject.name == "DiSuDuanGai_L" || this.transform.gameObject.name == "DiSuDuanGai_R")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_L01").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_R01").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 3);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }
                            #endregion

                            #region 组装中速轮轴
                            //组装斜齿轮
                            if (this.transform.gameObject.name == "XieChiLun")
                            {
                                this.transform.parent.GetComponent<Animator>().enabled = true;
                                isPlay = true;
                            }

                            //组装中速轴轴承--dyh
                            if (this.transform.gameObject.name == "ZhouCheng_dyh_L02" || this.transform.gameObject.name == "ZhouCheng_dyh_R02")
                            {
                                if (this.transform.parent.transform.Find("XieChiLun").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 1);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //组装中速轴轴承
                            if (this.transform.gameObject.name == "ZhouCheng_L02" || this.transform.gameObject.name == "ZhouCheng_R02")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_dyh_L02").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_dyh_R02").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 2);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //组装中速轴轴承端盖
                            if (this.transform.gameObject.name == "ZhongSuDuanGai_L" || this.transform.gameObject.name == "ZhongSuDuanGai_R")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_L02").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_R02").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 3);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }
                            #endregion

                            #region 组装高速轮轴
                            //组装高速轴轴承--dyh
                            if (this.transform.gameObject.name == "ZhouCheng_dyh_L03" || this.transform.gameObject.name == "ZhouCheng_dyh_R03")
                            {
                                this.transform.parent.GetComponent<Animator>().enabled = true;
                                isPlay = true;
                            }

                            //组装高速轴轴承
                            if (this.transform.gameObject.name == "ZhouCheng_L03" || this.transform.gameObject.name == "ZhouCheng_R03")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_dyh_L03").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_dyh_R03").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 1);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //组装高速轴轴承端盖
                            if (this.transform.gameObject.name == "GaoSuDuanGai_L" || this.transform.gameObject.name == "GaoSuDuanGai_R")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_L03").GetComponent<ManualAssemlyMouseSelect>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_R03").GetComponent<ManualAssemlyMouseSelect>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 2);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
        }
    }

}
