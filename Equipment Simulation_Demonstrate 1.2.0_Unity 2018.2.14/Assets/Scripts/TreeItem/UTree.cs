using UnityEngine;
using System.Collections.Generic;

public class UTree : MonoBehaviour 
{
	/// <summary>
	/// 树节点的高度
	/// </summary>
	public float itemHeight;

	/// <summary>
	/// 树数据
	/// </summary>
	private IList<UTreeData> dataList;

	/// <summary>
	/// 树节点列表
	/// </summary>
	private IList<UTreeItem> itemList;

	/// <summary>
	/// 节点索引
	/// </summary>
	private int itemIndex;

	/// <summary>
	/// 树的高度
	/// </summary>
	protected float treeHeight;

	/// <summary>
	/// 设置树节点对象
	/// </summary>
	public UTreeItem uTreeItem;

	void Awake()
	{
		this.InitTree ();
	}

	/// <summary>
	/// 初始化树数据
	/// </summary>
	protected virtual void InitTree()
	{
        
	}

	/// <summary>
	/// 创建树节点
	/// </summary>
	/// <returns>The tree item.</returns>
	/// <param name="index">Index.</param>
	private UTreeItem CreateTreeItem(int index)
	{
		if (index >= 0 && this.itemList != null && index <= this.itemList.Count) 
		{
			return this.itemList[index - 1].GetComponent<UTreeItem>();
		}

		if (this.uTreeItem == null) return null;
		GameObject treeItemObject = (GameObject)Instantiate(this.uTreeItem.gameObject);
		treeItemObject.transform.parent = this.transform;
		treeItemObject.transform.localScale = new Vector3(1f, 1f, 1f);
		
		UTreeItem uTreeItem = treeItemObject.GetComponent<UTreeItem>();
		this.itemList.Add(uTreeItem);
		
		return uTreeItem;
	}

	/// <summary>
	/// 更新树数据
	/// </summary>
	/// <param name="dataList">Data list.</param>
	public void ChangeData(IList<UTreeData> dataList)
	{
		this.InitItemList ();

		this.dataList = dataList;
		this.whileItem ("0", this.GetChildrenDataList ("0"));

		this.treeHeight = this.itemIndex * this.itemHeight;

		this.ChangeTreeHeight ();
	}

	/// <summary>
	/// 递归创建树节点
	/// </summary>
	/// <param name="parentID">Parent I.</param>
	/// <param name="parentDataList">Parent data list.</param>
	public void whileItem(string parentID, IList<UTreeData> parentDataList)
	{
		UTreeData parentTreeData = this.GetItemData (parentID);

		int level = 0;
		if (parentTreeData != null) level = parentTreeData.level + 1;

		foreach (UTreeData uTreeData in parentDataList) 
		{
			this.itemIndex ++;
			uTreeData.level = level;

			UTreeItem uTreeItem = this.CreateTreeItem(this.itemIndex);
			NGUITools.SetActive(uTreeItem.gameObject, true);

			uTreeItem.ChangeData(uTreeData, OnItemClickHandler);
			uTreeItem.transform.localPosition = new Vector3(0f, this.itemHeight - this.itemIndex * this.itemHeight, 0f);

			if(uTreeData.expand)
			{
				IList<UTreeData> childDataList = this.GetChildrenDataList(uTreeData.id);
				if(childDataList != null && childDataList.Count > 0) this.whileItem(uTreeData.id, childDataList);
			}
		}
	}

	/// <summary>
	/// 树节点点击事件
	/// </summary>
	/// <param name="uTreeData">U tree data.</param>
	private void OnItemClickHandler(UTreeData uTreeData)
	{
		IList<UTreeData> dataList = this.GetChildrenDataList (uTreeData.id);
		UTreeData resultData = this.GetItemData (uTreeData.id);
		if (resultData != null && dataList != null && dataList.Count > 0) 
		{
			resultData.expand = resultData.expand == true ? false : true;
			this.ChangeData (this.dataList);
		} else {
			this.ChangeTreeSelect(uTreeData);
		}
	}
	
	/// <summary>
	/// 更新树高度
	/// </summary>
	protected virtual void ChangeTreeHeight()
	{
		
	}

	/// <summary>
	/// 更新树节点选择
	/// </summary>
	/// <param name="uTreeData">U tree data.</param>
	protected virtual void ChangeTreeSelect(UTreeData uTreeData)
	{

	}

	/// <summary>
	/// 获取节点的子节点数据
	/// </summary>
	/// <returns>The children data list.</returns>
	/// <param name="parentID">Parent I.</param>
	private IList<UTreeData> GetChildrenDataList(string parentID)
	{
		IList<UTreeData> resultList = new List<UTreeData> ();
		foreach (UTreeData uTreeData in this.dataList) 
		{
			if(uTreeData.parentID == parentID) resultList.Add(uTreeData);
		}
		return resultList;
	}

	/// <summary>
	/// 根据节点 ID 数据获取树数据
	/// </summary>
	/// <returns>The item data.</returns>
	/// <param name="id">Identifier.</param>
	private UTreeData GetItemData(string id)
	{
		foreach (UTreeData uTreeData in this.dataList) 
		{
			if(uTreeData.id == id) return uTreeData;
		}
		return null;
	}

	/// <summary>
	/// 初始化树节点
	/// </summary>
	private void InitItemList()
	{
		this.itemIndex = 0;

		if (this.itemList == null) this.itemList = new List<UTreeItem> ();
		if (this.itemList.Count > 0) 
		{
			foreach (UTreeItem uTreeItem in this.itemList) 
			{
				NGUITools.SetActive(uTreeItem.gameObject, false);
			}
		}
	}
}
