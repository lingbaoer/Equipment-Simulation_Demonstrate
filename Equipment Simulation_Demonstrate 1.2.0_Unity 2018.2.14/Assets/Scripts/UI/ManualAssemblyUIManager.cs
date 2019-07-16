using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManualAssemblyUIManager : MonoBehaviour
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
    /// 装备自动组装面板中“重置”的按钮
    /// </summary>
    public Transform resetButton;

    // Use this for initialization
    void Start()
    {
        if (Globe.enterManualAssembly == true)
        {
            ManualAssebmly();
        }
    }

    /// <summary>
    /// 手工组装按钮事件
    /// </summary>
    public void ManualAssebmly()
    {
        Globe.isManualAssembly = true;

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

        manualAssemblyButton.GetComponent<UIButton>().isEnabled = false;
        automaticAssemblyButton.GetComponent<UIButton>().isEnabled = false;
        resetButton.GetComponent<UIButton>().isEnabled = false;
    }

    /// <summary>
    /// 自动组装按钮事件
    /// </summary>
    public void AutomaticAssembly()
    {
        Globe.isAutomaticAssembly = true;
        SceneManager.LoadScene("EquipmentAutomaticAssembly");
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

        Globe.isManualAssembly = false;
        Globe.enterManualAssembly = false;

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
        SceneManager.LoadScene("EquipmentManualAssembly");
    }

    /// <summary>
    /// 组装顺序要求的面板的关闭按钮
    /// </summary>
    public void Exit()
    {
        //组装拆解顺序要求的面板
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
