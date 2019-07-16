using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutomaticAssemblyUIManager : MonoBehaviour
{
    /// <summary>
    /// 装备组装面板中组装顺序要求的面板
    /// </summary>
    public Transform assOrderPanel;

    /// <summary>
    /// 装备组装面板中返回系统介绍面板的“返回”按钮
    /// </summary>
    public Transform assBack;

    /// <summary>
    /// 返回装备组装面板组装顺序介绍的“返回”按钮
    /// </summary>
    public Transform assemblyBack;

    /// <summary>
    /// 装备组装面板中“手工组装”的按钮
    /// </summary>
    public Transform manualAssemblyButton;

    /// <summary>
    /// 装备组装面板中“自动组装”的按钮
    /// </summary>
    public Transform automaticAssemblyButton;

    /// <summary>
    /// 用于展示模型的主相机
    /// </summary>
    public Camera mainCamera;

    /// <summary>
    /// 装备组装面板中自动组装时用来提示组装步骤的提示栏
    /// </summary>
    public Transform assSubtitle;

    /// <summary>
    /// 装备自动组装面板中“重置”的按钮
    /// </summary>
    public Transform resetButton;

    // Use this for initialization
    void Start()
    {
        if (Globe.isAutomaticAssembly == true)
        {
            AutomaticAssebmly();
        }
    }

    /// <summary>
    /// 自动组装按钮事件
    /// </summary>
    public void AutomaticAssebmly()
    {
        //隐藏用于返回系统介绍面板的“返回”按钮
        if (assBack.gameObject.activeSelf == true)
        {
            assBack.gameObject.SetActive(false);
        }

        //显示用于返回组装顺序介绍面板的“返回”按钮
        if (assemblyBack.gameObject.activeSelf == false)
        {
            assemblyBack.gameObject.SetActive(true);
        }

        //禁用鼠标控制模型功能
        //if (mainCamera.GetComponent<MouseOrbit>().enabled == true)
        //{
        //    mainCamera.GetComponent<MouseOrbit>().enabled = false;
        //}

        //打开控制自动组装的脚本
        if (mainCamera.transform.GetComponent<AutomaticAssemly>().enabled == false)
        {
            mainCamera.transform.GetComponent<AutomaticAssemly>().enabled = true;
        }

        //打开自动组装时的信息提示栏
        if (assSubtitle.gameObject.activeSelf == false)
        {
            assSubtitle.gameObject.SetActive(true);
        }

        mainCamera.transform.GetComponent<Animator>().enabled = true;
        //mainCamera.transform.GetComponent<MouseOrbit>().enabled = false;

        manualAssemblyButton.GetComponent<UIButton>().isEnabled = false;
        automaticAssemblyButton.GetComponent<UIButton>().isEnabled = false;
        resetButton.GetComponent<UIButton>().isEnabled = false;
    }

    /// <summary>
    /// 手工组装按钮事件
    /// </summary>
    public void ManualAssembly()
    {
        Globe.enterManualAssembly = true;
        SceneManager.LoadScene("EquipmentManualAssembly");
    }

    /// <summary>
    /// 返回组装顺序介绍的返回按钮事件
    /// </summary>
    public void AssemblyBackButton()
    {
        //显示组装顺序要求的面板
        if (assOrderPanel.gameObject.activeSelf == false)
        {
            assOrderPanel.gameObject.SetActive(true);
        }

        //显示返回系统介绍面板的“返回”按钮
        if (assBack.gameObject.activeSelf == false)
        {
            assBack.gameObject.SetActive(true);
        }

        //隐藏返回组装顺序介绍的“返回”按钮
        if (assemblyBack.gameObject.activeSelf == true)
        {
            assemblyBack.gameObject.SetActive(false);
        }

        //关闭自动组装时的信息提示栏
        if (assSubtitle.gameObject.activeSelf == true)
        {
            assSubtitle.gameObject.SetActive(false);
        }

        //关闭控制自动组装的脚本
        if (mainCamera.transform.GetComponent<AutomaticAssemly>().enabled == true)
        {
            mainCamera.transform.GetComponent<AutomaticAssemly>().enabled = false;
        }

        //激活鼠标控制模型设置
        if (mainCamera.GetComponent<MouseOrbit>().enabled == false)
        {
            mainCamera.GetComponent<MouseOrbit>().enabled = true;
        }

        Globe.isAutomaticAssembly = false;

        manualAssemblyButton.GetComponent<UIButton>().isEnabled = true;
        automaticAssemblyButton.GetComponent<UIButton>().isEnabled = true;
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
        SceneManager.LoadScene("EquipmentAutomaticAssembly");
    }

    /// <summary>
    /// 组装顺序要求的面板的关闭按钮
    /// </summary>
    public void Exit()
    {
        //隐藏组装顺序要求的面板
        if (assOrderPanel.gameObject.activeSelf == true)
        {
            assOrderPanel.gameObject.SetActive(false);
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
