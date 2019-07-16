using UnityEngine;
using System.Collections;

public class AutomaticAssemly : MonoBehaviour
{
    /// <summary>
    /// 返回设备组装面板组装顺序介绍的“返回”按钮
    /// </summary>
    public Transform assemblyBack;

    /// <summary>
    /// 设备组装面板中“手工组装”的按钮
    /// </summary>
    public Transform manualAssemblyButton;

    /// <summary>
    /// 设备组装面板中“自动组装”的按钮
    /// </summary>
    public Transform automaticAssemblyButton;

    /// <summary>
    /// 相机
    /// </summary>
    public GameObject cameraObj;

    /// <summary>
    /// 用来显示组装步骤提示的标牌
    /// </summary>
    public GameObject assSubtitle;

    /// <summary>
    /// 装备自动组装面板中“重置”的按钮
    /// </summary>
    public Transform resetButton;

    //自动组装的步骤
    public GameObject[] step1;
    public GameObject[] step2;
    public GameObject[] step3;
    public GameObject[] step4;
    public GameObject[] step5;
    public GameObject[] step6;
    public GameObject[] step7;
    public GameObject[] step8;
    public GameObject[] step9;
    public GameObject[] step10;
    public GameObject[] step11;

    private Animator cameraAnimator;

    private AnimatorStateInfo cameraStateInfo;
    private AnimatorStateInfo assSubtitleStateInfo;

    public int currentStep;

    private float AddTime;

    // Use this for initialization
    void Start()
    {
        cameraAnimator = cameraObj.GetComponent<Animator>();
        currentStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentStep)
        {
            case 0:
                if (cameraAnimator)
                {
                    assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "组装低速齿轮轴";
                    cameraStateInfo = cameraAnimator.GetCurrentAnimatorStateInfo(0);
                    if (cameraStateInfo.IsName("Base Layer.Assembly Controller Anim 01"))
                    {
                        if (cameraStateInfo.normalizedTime > 1.0f)
                        {
                            currentStep = 1;
                        }
                    }
                }
                break;
            case 1:     //组装低速齿轮轴
                for (int i = 0; i < step1.Length; i++)
                {
                    if (step1[i].GetComponent<Animator>())
                    {
                        step1[i].GetComponent<Animator>().enabled = true;
                    }
                }
                currentStep = 2;
                break;
            case 2:    //相机动画显示字幕
                if (step1[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "组装中速齿轮轴";
                        cameraAnimator.SetInteger("Step", 2);
                        currentStep = 3;
                        AddTime = 0;
                    }
                }
                break;
            case 3:     //组装中速齿轮轴
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
               && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step2.Length; i++)
                    {
                        if (step2[i].GetComponent<Animator>())
                        {
                            step2[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 4;
                }
                break;
            case 4: //相机动画显示字幕
                if (step2[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "组装高速齿轮轴";
                        cameraAnimator.SetInteger("Step", 3);
                        currentStep = 5;
                        AddTime = 0;
                    }
                }
                break;
            case 5:     //组装高速齿轮轴
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
               && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step2.Length; i++)
                    {
                        if (step3[i].GetComponent<Animator>())
                        {
                            step3[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 6;
                }
                break;
            case 6: //相机动画显示字幕
                if (step3[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "安装上盖";
                        cameraAnimator.SetInteger("Step", 4);
                        currentStep = 7;
                        AddTime = 0;
                    }
                }
                break;
            case 7:     //安装上盖
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
               && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step4.Length; i++)
                    {
                        if (step4[i].GetComponent<Animator>())
                        {
                            step4[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 8;
                }
                break;
            case 8: //相机动画显示字幕
                if (step4[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "安装固定螺栓垫片";
                        cameraAnimator.SetInteger("Step", 5);
                        currentStep = 9;
                        AddTime = 0;
                    }
                }
                break;
            case 9:     //安装固定螺栓垫片
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
               && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step5.Length; i++)
                    {
                        if (step5[i].GetComponent<Animator>())
                        {
                            step5[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 10;
                }
                break;
            case 10: //相机动画显示字幕
                if (step5[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "安装固定螺栓";
                        cameraAnimator.SetInteger("Step", 6);
                        currentStep = 11;
                        AddTime = 0;
                    }
                }
                break;
            case 11:    //安装固定螺栓
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
              && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step6.Length; i++)
                    {
                        if (step6[i].GetComponent<Animator>())
                        {
                            step6[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 12;
                }
                break;
            case 12:    //安装固定螺母
                if (step6[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 2.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "安装固定螺母";
                        for (int i = 0; i < step7.Length; i++)
                        {
                            if (step7[i].GetComponent<Animator>())
                            {
                                step7[i].GetComponent<Animator>().enabled = true;
                            }
                        }
                        currentStep = 13;
                    }
                }
                break;
            case 13: //相机动画显示字幕
                if (step7[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "安装轴承盖垫片";
                        cameraAnimator.SetInteger("Step", 7);
                        currentStep = 14;
                        AddTime = 0;
                    }
                }
                break;
            case 14:    //安装轴承盖垫片
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
              && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step8.Length; i++)
                    {
                        if (step8[i].GetComponent<Animator>())
                        {
                            step8[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 15;
                }
                break;
            case 15:    //安装轴承盖螺钉
                if (step8[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "安装轴承盖螺钉";
                        for (int i = 0; i < step9.Length; i++)
                        {
                            if (step9[i].GetComponent<Animator>())
                            {
                                step9[i].GetComponent<Animator>().enabled = true;
                            }
                        }
                        currentStep = 16;
                    }
                }
                break;
            case 16: //相机动画显示字幕
                if (step9[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "安装轴承盖垫片";
                        cameraAnimator.SetInteger("Step", 8);
                        currentStep = 17;
                        AddTime = 0;
                    }
                }
                break;
            case 17:    //安装轴承盖垫片
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
              && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step10.Length; i++)
                    {
                        if (step10[i].GetComponent<Animator>())
                        {
                            step10[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 18;
                }
                break;
            case 18:    //安装轴承盖螺钉
                if (step10[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "安装轴承盖螺钉";
                        for (int i = 0; i < step11.Length; i++)
                        {
                            if (step11[i].GetComponent<Animator>())
                            {
                                step11[i].GetComponent<Animator>().enabled = true;
                            }
                        }
                        currentStep = 19;
                    }
                }
                break;
            case 19:    //自动安装结束
                if (step11[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    AddTime += Time.deltaTime;
                    if (AddTime > 1.0f)
                    {
                        assSubtitle.transform.Find("Text").GetComponent<UILabel>().text = "减速器安装结束\n查看模型：左键按下拖动旋转，滚轮缩放。";
                        cameraObj.GetComponent<Animator>().enabled = false;
                        cameraObj.GetComponent<MouseOrbit>().enabled = true;
                        if (assemblyBack.GetComponent<UIButton>().isEnabled == false)
                        {
                            assemblyBack.GetComponent<UIButton>().isEnabled = true;
                        }
                        manualAssemblyButton.GetComponent<UIButton>().isEnabled = true;
                        automaticAssemblyButton.GetComponent<UIButton>().isEnabled = true;
                        resetButton.GetComponent<UIButton>().isEnabled = true;
                        Globe.isAutomaticAssembly = false;

                        AddTime = 0;
                    }
                }
                break;
            default:
                Debug.Log("over");
                break;
        }
    }


}
