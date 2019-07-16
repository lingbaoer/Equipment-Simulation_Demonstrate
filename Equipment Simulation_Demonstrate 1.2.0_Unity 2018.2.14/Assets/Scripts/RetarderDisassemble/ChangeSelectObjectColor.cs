using UnityEngine;
using System.Collections;

public class ChangeSelectObjectColor : MonoBehaviour
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
    /// 在手动拆解减速器过程中用来判断是否播放所选模型组件的拆解动画
    /// </summary>
    public bool isPlay = false;

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
                    if (Globe.isManualDisassembly == true)
                    {
                        if (this.transform.GetComponent<Animator>() != null)
                        {
                            if (isPlay == true)
                            {
                                this.transform.GetComponent<Animator>().enabled = true;
                            }
                            else
                            {
                                Debug.Log("拆解顺序错误！");
                            }
                        }
                        else
                        {
                            #region  拆解高速轮轴
                            //拆解高速轴端盖
                            if (this.transform.gameObject.name == "GaoSuDuanGai_L" || this.transform.gameObject.name == "GaoSuDuanGai_R")
                            {
                                if (this.transform.parent.GetComponent<Animator>().enabled == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 1);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //拆解高速轴轴承
                            if (this.transform.gameObject.name == "ZhouCheng_L03" || this.transform.gameObject.name == "ZhouCheng_R03")
                            {
                                if (this.transform.parent.transform.Find("GaoSuDuanGai_L").GetComponent<ChangeSelectObjectColor>().isPlay == true
                                    || this.transform.parent.transform.Find("GaoSuDuanGai_R").GetComponent<ChangeSelectObjectColor>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 2);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }


                            //拆解高速轴轴承--dyh
                            if (this.transform.gameObject.name == "ZhouCheng_dyh_L03" || this.transform.gameObject.name == "ZhouCheng_dyh_R03")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_L03").GetComponent<ChangeSelectObjectColor>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_R03").GetComponent<ChangeSelectObjectColor>().isPlay == true)
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

                            #region  拆解中速轮轴
                            //拆解中速轴端盖
                            if (this.transform.gameObject.name == "ZhongSuDuanGai_L" || this.transform.gameObject.name == "ZhongSuDuanGai_R")
                            {
                                if (this.transform.parent.GetComponent<Animator>().enabled == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 1);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //拆解中速轴轴承
                            if (this.transform.gameObject.name == "ZhouCheng_L02" || this.transform.gameObject.name == "ZhouCheng_R02")
                            {
                                if (this.transform.parent.transform.Find("ZhongSuDuanGai_L").GetComponent<ChangeSelectObjectColor>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhongSuDuanGai_R").GetComponent<ChangeSelectObjectColor>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 2);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }


                            //拆解中速轴轴承--dyh
                            if (this.transform.gameObject.name == "ZhouCheng_dyh_L02" || this.transform.gameObject.name == "ZhouCheng_dyh_R02")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_L02").GetComponent<ChangeSelectObjectColor>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_R02").GetComponent<ChangeSelectObjectColor>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 3);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //拆解中速轴协齿轮
                            if (this.transform.gameObject.name == "XieChiLun")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_dyh_L02").GetComponent<ChangeSelectObjectColor>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_dyh_R02").GetComponent<ChangeSelectObjectColor>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 4);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }
                            #endregion

                            #region  拆解低速轮轴
                            //拆解低速轴端盖
                            if (this.transform.gameObject.name == "DiSuDuanGai_L" || this.transform.gameObject.name == "DiSuDuanGai_R")
                            {
                                if (this.transform.parent.GetComponent<Animator>().enabled == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 1);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //拆解低速轴轴承
                            if (this.transform.gameObject.name == "ZhouCheng_L01" || this.transform.gameObject.name == "ZhouCheng_R01")
                            {
                                if (this.transform.parent.transform.Find("DiSuDuanGai_L").GetComponent<ChangeSelectObjectColor>().isPlay == true
                                    || this.transform.parent.transform.Find("DiSuDuanGai_R").GetComponent<ChangeSelectObjectColor>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 2);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }


                            //拆解低速轴轴承--dyh
                            if (this.transform.gameObject.name == "ZhouCheng_dyh_L01" || this.transform.gameObject.name == "ZhouCheng_dyh_R01")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_L01").GetComponent<ChangeSelectObjectColor>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_R01").GetComponent<ChangeSelectObjectColor>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 3);
                                }
                                else
                                {
                                    isPlay = false;
                                }
                            }

                            //拆解低速轴直齿轮
                            if (this.transform.gameObject.name == "ZhiChiLun")
                            {
                                if (this.transform.parent.transform.Find("ZhouCheng_dyh_L01").GetComponent<ChangeSelectObjectColor>().isPlay == true
                                    || this.transform.parent.transform.Find("ZhouCheng_dyh_R01").GetComponent<ChangeSelectObjectColor>().isPlay == true)
                                {
                                    isPlay = true;
                                    this.transform.parent.GetComponent<Animator>().SetInteger("Step", 4);
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
