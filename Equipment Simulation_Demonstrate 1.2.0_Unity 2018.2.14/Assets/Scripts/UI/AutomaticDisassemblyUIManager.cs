using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutomaticDisassemblyUIManager : MonoBehaviour
{
    /// <summary>
    /// 装备拆解面板中拆解顺序要求的面板
    /// </summary>
    public Transform disassemblyOrderPanel;

    /// <summary>
    /// 装备拆解面板中返回系统介绍面板的“返回”按钮
    /// </summary>
    public Transform btnBack;

    /// <summary>
    /// 返回装备拆解面板拆解顺序介绍的“返回”按钮
    /// </summary>
    public Transform disassemblyBack;

    /// <summary>
    /// 装备拆解面板中“手工拆解”的按钮
    /// </summary>
    public Transform manualDisassemblyButton;

    /// <summary>
    /// 装备拆解面板中“自动拆解”的按钮
    /// </summary>
    public Transform automaticDisassemblyButton;

    /// <summary>
    /// 用于展示模型的主相机
    /// </summary>
    public Camera mainCamera;

    /// <summary>
    /// 装备拆解面板中自动拆解时用来提示拆解步骤的提示栏
    /// </summary>
    public Transform disassemblySubtitle;

    /// <summary>
    /// 装备自动拆解面板中“重置”的按钮
    /// </summary>
    public Transform resetButton;

    // Use this for initialization
    void Start()
    {
        if (Globe.isAutomaticDisassembly == true)
        {
            AutomaticDisassebmly();
        }
    }

    /// <summary>
    /// 自动拆解按钮事件
    /// </summary>
    public void AutomaticDisassebmly()
    {
        //隐藏用于返回系统介绍面板的“返回”按钮
        if (btnBack.gameObject.activeSelf == true)
        {
            btnBack.gameObject.SetActive(false);
        }

        //显示用于返回拆解顺序介绍面板的“返回”按钮
        if (disassemblyBack.gameObject.activeSelf == false)
        {
            disassemblyBack.gameObject.SetActive(true);
        }

        //禁用鼠标控制模型功能
        //if (mainCamera.GetComponent<MouseOrbit>().enabled == true)
        //{
        //    mainCamera.GetComponent<MouseOrbit>().enabled = false;
        //}

        //打开控制自动拆解的脚本
        if (mainCamera.transform.GetComponent<AutomaticDisassemly>().enabled == false)
        {
            mainCamera.transform.GetComponent<AutomaticDisassemly>().enabled = true;
        }

        //打开自动拆解时的信息提示栏
        if (disassemblySubtitle.gameObject.activeSelf == false)
        {
            disassemblySubtitle.gameObject.SetActive(true);
        }

        mainCamera.transform.GetComponent<Animator>().enabled = true;
        //mainCamera.transform.GetComponent<MouseOrbit>().enabled = false;

        manualDisassemblyButton.GetComponent<UIButton>().isEnabled = false;
        automaticDisassemblyButton.GetComponent<UIButton>().isEnabled = false;
        resetButton.GetComponent<UIButton>().isEnabled = false;
    }

    /// <summary>
    /// 手工拆解按钮事件
    /// </summary>
    public void ManualDisassembly()
    {
        Globe.enterManualDisassembly = true;
        SceneManager.LoadScene("EquipmentManualDisassembly");
    }

    /// <summary>
    /// 返回拆解顺序介绍的返回按钮事件
    /// </summary>
    public void DisassemblyBackButton()
    {
        //显示拆解顺序要求的面板
        if (disassemblyOrderPanel.gameObject.activeSelf == false)
        {
            disassemblyOrderPanel.gameObject.SetActive(true);
        }

        //显示返回系统介绍面板的“返回”按钮
        if (btnBack.gameObject.activeSelf == false)
        {
            btnBack.gameObject.SetActive(true);
        }

        //隐藏返回拆解顺序介绍的“返回”按钮
        if (disassemblyBack.gameObject.activeSelf == true)
        {
            disassemblyBack.gameObject.SetActive(false);
        }

        //关闭自动拆解时的信息提示栏
        if (disassemblySubtitle.gameObject.activeSelf == true)
        {
            disassemblySubtitle.gameObject.SetActive(false);
        }

        //关闭控制自动拆解的脚本
        if (mainCamera.transform.GetComponent<AutomaticDisassemly>().enabled == true)
        {
            mainCamera.transform.GetComponent<AutomaticDisassemly>().enabled = false;
        }

        //激活鼠标控制模型设置
        if (mainCamera.GetComponent<MouseOrbit>().enabled == false)
        {
            mainCamera.GetComponent<MouseOrbit>().enabled = true;
        }

        Globe.isAutomaticDisassembly = false;

        manualDisassemblyButton.GetComponent<UIButton>().isEnabled = true;
        automaticDisassemblyButton.GetComponent<UIButton>().isEnabled = true;
        resetButton.GetComponent<UIButton>().isEnabled = true;
    }

    /// <summary>
    /// 返回系统介绍面板“返回”按钮点击事件
    /// </summary>
    public void BackButton()
    {
        SceneManager.LoadScene("EquipmentSimulationScene");
    }

    /// <summary>
    /// 重置按钮事件 
    /// </summary>
    public void Reset()
    {
        SceneManager.LoadScene("EquipmentAutomaticDisassembly");
    }

    /// <summary>
    /// 拆解顺序要求的面板的关闭按钮
    /// </summary>
    public void Exit()
    {
        //隐藏拆解顺序要求的面板
        if (disassemblyOrderPanel.gameObject.activeSelf == true)
        {
            disassemblyOrderPanel.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 退出系统
    /// </summary>
    public void ExitSystem()
    {
        Application.Quit();
    }
}
