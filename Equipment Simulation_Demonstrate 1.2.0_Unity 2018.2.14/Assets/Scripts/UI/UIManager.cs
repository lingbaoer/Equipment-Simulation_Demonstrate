using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    #region 装备介绍面板的UI控件
    /// <summary>
    /// 装备介绍面板
    /// </summary>
    public Transform equipmentList;

    /// <summary>
    /// 装备介绍中展示装备明细的面板
    /// </summary>
    public Transform equipmentListPanel;

    /// <summary>
    /// 装备介绍面板中返回系统介绍的返回按钮
    /// </summary>
    public Transform btnBack;

    /// <summary>
    /// 装备介绍面板中返回装备明细表的返回按钮
    /// </summary>
    public Transform backIntroductionButton;

    /// <summary>
    /// 装备介绍面板外部装备选项
    /// </summary>
    public Transform externalEquipment;

    /// <summary>
    /// 装备介绍面板内部装备选项
    /// </summary>
    public Transform interiorEquipment;

    /// <summary>
    /// 装备介绍面板中需要进行点击变色操作的按钮集合
    /// </summary>
    public Transform[] buttonList;
    #endregion

    /// <summary>
    /// 系统功能介绍面板
    /// </summary>
    public Transform systemFeature;

    /// <summary>
    /// 用于展示模型的主相机
    /// </summary>
    public Camera mainCamera;

    void Start()
    {
        
    }

    #region 装备介绍面板的UI操作
    /// <summary>
    /// 关闭装备介绍明细表
    /// </summary>
    public void EquipmentListExit()
    {
        btnBack.gameObject.SetActive(false);
        equipmentListPanel.gameObject.SetActive(false);
        backIntroductionButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// 装备介绍面板中返回装备明细表的返回按钮点击事件
    /// </summary>
    public void BackIntroductionButton()
    {
        equipmentListPanel.gameObject.SetActive(true);
        btnBack.gameObject.SetActive(true);
        backIntroductionButton.gameObject.SetActive(false);
    }

    /// <summary>
    /// 装备介绍面板中内部装备子节点收缩，则上移“外部装备”按钮
    /// </summary>
    public void OnContract()
    {
        float heigh = (interiorEquipment.childCount - 2) * 20;  //"内部装备"子选项所占的高度

        if (interiorEquipment.GetComponent<TreeContract>().isContract == false)
        {
            externalEquipment.localPosition = new Vector3(externalEquipment.localPosition.x, externalEquipment.localPosition.y + heigh, 0f);
        }
        else
        {
            externalEquipment.localPosition = new Vector3(externalEquipment.localPosition.x, externalEquipment.localPosition.y - heigh, 0f);
        }
    }

    /// <summary>
    /// 装备介绍面板中选中的选项颜色变化，其他的维持原来的颜色
    /// </summary>
    public void ChangItemColor()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].GetComponent<UIButton>().isEnabled == false)
            {
                buttonList[i].GetComponent<UIButton>().isEnabled = true;
            }
        }
    }
    #endregion

     
    #region 系统功能介绍面板的UI操作
    /// <summary>
    /// 装备介绍按钮点击事件
    /// </summary>
    public void EquipmentIntroduction()
    {
        equipmentList.gameObject.SetActive(true);   //显示装备介绍面板

        systemFeature.gameObject.SetActive(false);  //隐藏系统介绍面板
    }

    /// <summary>
    /// 装备拆解按钮点击事件
    /// </summary>
    public void EquipmentDisassembly()
    {
        Application.LoadLevel("EquipmentManualDisassembly");
    }

    /// <summary>
    /// 装备组装按钮点击事件
    /// </summary>
    public void EquipmentAssembly()
    {
        Application.LoadLevel("EquipmentManualAssembly");
    }
    #endregion

    /// <summary>
    /// 装备介绍面板的返回系统介绍面板“返回”按钮点击事件
    /// </summary>
    public void BackButton()
    {
        //隐藏装备介绍面板
        if (equipmentList.gameObject.activeSelf == true)
        {
            equipmentList.gameObject.SetActive(false);
        }

        //显示系统介绍面板
        if (systemFeature.gameObject.activeSelf == false)
        {
            systemFeature.gameObject.SetActive(true);
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
