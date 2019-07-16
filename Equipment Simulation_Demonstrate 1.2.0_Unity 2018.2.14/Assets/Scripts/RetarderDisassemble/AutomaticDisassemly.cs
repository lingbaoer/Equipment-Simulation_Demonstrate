using UnityEngine;
using System.Collections;

public class AutomaticDisassemly : MonoBehaviour
{

    /// <summary>
    /// 返回设备拆解面板拆解顺序介绍的“返回”按钮
    /// </summary>
    public Transform disassemblyBack;

    /// <summary>
    /// 设备拆解面板中“手工拆解”的按钮
    /// </summary>
    public Transform manualDisassemblyButton;

    /// <summary>
    /// 设备拆解面板中“自动拆解”的按钮
    /// </summary>
    public Transform automaticDisassemblyButton;

    /// <summary>
    /// 相机
    /// </summary>
    public GameObject cameraObj;

    /// <summary>
    /// 用来显示拆解步骤提示的标牌
    /// </summary>
    public GameObject subtitleObj;

    /// <summary>
    /// 装备自动拆解面板中“重置”的按钮
    /// </summary>
    public Transform resetButton;

    public GameObject[] step1;
    public GameObject[] step2;
    public GameObject[] step3;
    public GameObject[] step4;
    public GameObject[] step5;
    public GameObject[] step6;
    public GameObject[] step7;
    public GameObject[] step8;
    public GameObject[] step9;

    private Animator cameraAnimator;
    private Animator subtitleAnimator;

    private AnimatorStateInfo cameraStateInfo;
    private AnimatorStateInfo subtitleStateInfo;

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
            case 0: //第01步 相机
                //-------------下一步 提前执行
                if (cameraAnimator)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "减速器分解开始";
                    cameraStateInfo = cameraAnimator.GetCurrentAnimatorStateInfo(0);
                    if (cameraStateInfo.IsName("Base Layer.Camera Anim 01"))
                    {
                        if (cameraStateInfo.normalizedTime > 1.0f)
                        {
                            currentStep = 1;
                        }
                    }
                }
                break;
            case 1: 
                currentStep = 2;
                break;
            case 2: 
                currentStep = 3;
                break;
            case 3: //第03步 相机动画
                cameraAnimator.SetInteger("StepNumber", 2);
                subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "拆下端盖紧固螺钉";
                currentStep = 4;
                break;
            case 4: //第04步 显示字幕
                if (cameraAnimator)
                {
                    cameraStateInfo = cameraAnimator.GetCurrentAnimatorStateInfo(0);
                    if (cameraStateInfo.IsName("Base Layer.Camera Anim 02"))
                    {
                        if (cameraStateInfo.normalizedTime > 1.0f)
                        {
                            currentStep = 5;
                        }
                    }
                }
                break;
            case 5: //第05步 拆下端盖紧固螺钉1
                for (int i = 0; i < step1.Length; i++)
                {
                    if (step1[i].GetComponent<Animator>())
                    {
                        step1[i].GetComponent<Animator>().enabled = true;
                    }
                }
                currentStep = 6;
                break;
            case 6: //第06步：拆下端盖紧固螺钉 垫片1
                if (step1[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "拆下端盖紧固螺钉--垫片";
                    AddTime += Time.deltaTime;
                    if (AddTime > 2.0f)
                    {
                        for (int i = 0; i < step2.Length; i++)
                        {
                            if (step2[i].GetComponent<Animator>())
                            {
                                step2[i].GetComponent<Animator>().enabled = true;
                            }
                        }
                        AddTime = 0;
                        currentStep = 7;
                    }
                }
                break;
            case 7: //第07步：相机动画 显示字幕
                if (step2[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "拆下端盖紧固螺钉";
                    cameraAnimator.SetInteger("StepNumber", 3);
                    currentStep = 8;
                }
                break;
            case 8: //第08步：拆下端盖紧固螺钉2
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
                    && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step3.Length; i++)
                    {
                        if (step3[i].GetComponent<Animator>())
                        {
                            step3[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 9;
                }
                break;
            case 9: //第09步：拆下端盖紧固螺钉 垫片2
                if (step3[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "拆下端盖紧固螺钉--垫片";
                    AddTime += Time.deltaTime;
                    if (AddTime > 2.0f)
                    {
                        for (int i = 0; i < step4.Length; i++)
                        {
                            if (step4[i].GetComponent<Animator>())
                            {
                                step4[i].GetComponent<Animator>().enabled = true;
                            }
                        }
                        AddTime = 0;
                        currentStep = 10;
                    }
                }
                break;
            case 10:    //第10步：相机动画 显示字幕
                if (step4[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "拆下箱体紧固螺母";
                    cameraAnimator.SetInteger("StepNumber", 4);
                    currentStep = 11;
                }
                break;
            case 11:    //第11步：拆下箱体紧固螺母
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
                    currentStep = 12;
                }
                break;
            case 12:    //第13步：相机动画 显示字幕
                if (step5[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "取下箱体紧固螺栓";
                    cameraAnimator.SetInteger("StepNumber", 5);
                    currentStep = 13;
                }
                break;
            case 13:    //第13步：取下箱体紧固螺栓
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
                    currentStep = 14;
                }
                break;
            case 14:    //第14步：取下箱体紧固螺栓--垫片
                if (step6[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "取下箱体紧固螺栓--垫片";
                    for (int i = 0; i < step7.Length; i++)
                    {
                        if (step7[i].GetComponent<Animator>())
                        {
                            step7[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 15;
                }
                break;
            case 15:    //第15步：相机动画 显示字幕
                if (step7[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "取下减速器箱体上盖";
                    cameraAnimator.SetInteger("StepNumber", 6);
                    currentStep = 16;
                }
                break;
            case 16:    //第16步：取下减速器箱体上盖
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
                    currentStep = 17;
                }
                break;
            case 17:    //第17步：相机动画 显示字幕
                if (step8[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "取下变速齿轮轴";
                    cameraAnimator.SetInteger("StepNumber", 7);
                    currentStep = 18;
                }
                break;
            case 18:    //第18步：取下变速齿轮轴
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
                    && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step9.Length; i++)
                    {
                        if (step9[i].GetComponent<Animator>())
                        {
                            step9[i].GetComponent<Animator>().enabled = true;
                        }
                    }
                    currentStep = 19;
                }
                break;
            case 19:    //第19步：相机动画 显示字幕
                if (step9[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "分解齿轮轴";
                    cameraAnimator.SetInteger("StepNumber", 8);
                    currentStep = 20;
                }
                break;
            case 20:    //第20步：分解齿轮轴
                if (cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f
                    && cameraObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.02f)
                {
                    for (int i = 0; i < step9.Length; i++)
                    {
                        step9[i].GetComponent<Animator>().SetInteger("Step", 2);
                    }
                    currentStep = 21;
                }
                break;
            case 21:    //第21步
                if (step9[2].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    if (step9[2].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.ZhiChiLun"))
                    {
                        subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "减速器分解结束";
                        currentStep = 22;
                    }
                }
                break;
            case 22:    //第22步
                AddTime += Time.deltaTime;
                if (AddTime > 2.0f)
                {
                    subtitleObj.transform.Find("Text").GetComponent<UILabel>().text = "查看模型：左键按下拖动旋转，滚轮缩放。";
                    cameraObj.GetComponent<Animator>().enabled = false;
                    cameraObj.GetComponent<MouseOrbit>().enabled = true;
                    if (disassemblyBack.GetComponent<UIButton>().isEnabled == false)
                    {
                        disassemblyBack.GetComponent<UIButton>().isEnabled = true;
                    }
                    manualDisassemblyButton.GetComponent<UIButton>().isEnabled = true;
                    automaticDisassemblyButton.GetComponent<UIButton>().isEnabled = true;
                    resetButton.GetComponent<UIButton>().isEnabled = true;
                    Globe.isAutomaticDisassembly = false;

                    AddTime = 0;
                }
                break;
            default:
                Debug.Log("Default");
                break;
        }
    }
}
