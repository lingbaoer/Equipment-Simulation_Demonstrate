using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManualDisassemblyUIManager : MonoBehaviour
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
    /// 装备自动拆解面板中“重置”的按钮
    /// </summary>
    public Transform resetButton;

    // Use this for initialization
    void Start()
    {
        if (Globe.enterManualDisassembly)
        {
            ManualDisassebmly();
        }
    }

    /// <summary>
    /// 手工拆解按钮事件
    /// </summary>
    public void ManualDisassebmly()
    {
        Globe.isManualDisassembly = true;

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

        manualDisassemblyButton.GetComponent<UIButton>().isEnabled = false;
        automaticDisassemblyButton.GetComponent<UIButton>().isEnabled = false;
        resetButton.GetComponent<UIButton>().isEnabled = false;
    }

    /// <summary>
    /// 自动拆解按钮事件
    /// </summary>
    public void AutomaticDisassembly()
    {
        Globe.isAutomaticDisassembly = true;
        SceneManager.LoadScene("EquipmentAutomaticDisassembly");
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

        Globe.isManualDisassembly = false;
        Globe.enterManualDisassembly = false;

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
        SceneManager.LoadScene("EquipmentManualDisassembly");
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
