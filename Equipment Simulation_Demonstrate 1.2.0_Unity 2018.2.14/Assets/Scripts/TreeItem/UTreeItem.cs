using UnityEngine;
using System.Collections;

public class UTreeItem : MonoBehaviour 
{
	public delegate void ItemClick(UTreeData treeData);

	/// <summary>
	/// 图标
	/// </summary>
	public UISprite icon;

	/// <summary>
	/// 标题
	/// </summary>
	public UILabel text;
   
	/// <summary>
	/// 图标范围
	/// </summary>
	private Bounds iconBounds;

	/// <summary>
	/// 节点数据
	/// </summary>
	[HideInInspector]
    public UTreeData treeData;

	/// <summary>
	/// 节点点击回调函数
	/// </summary>
	private UTreeItem.ItemClick itemClick;
	
	void Awake()
	{
		this.InitAwakeItem ();
	}

	/// <summary>
	/// 树节点初始化
	/// </summary>
	protected virtual void InitAwakeItem()
	{
		UIEventListener.Get (this.gameObject).onClick = OnClickHandler;
		this.iconBounds = NGUIMath.CalculateRelativeWidgetBounds (this.icon.transform);
	}

	/// <summary>
	/// 设置数据
	/// </summary>
	/// <param name="treeData">Tree data.</param>
	/// <param name="itemClick">Item click.</param>
	public void ChangeData(UTreeData treeData, UTreeItem.ItemClick itemClick)
	{
		this.itemClick = itemClick;
		this.treeData = treeData;
		this.text.text = treeData.name;

		this.TreeItemRender ();
	}

	/// <summary>
	/// 树节点渲染
	/// </summary>
	protected virtual void TreeItemRender()
	{
		float offsetX = this.treeData.offset * this.treeData.level;
		
		this.icon.transform.localPosition = new Vector3 (offsetX, this.icon.transform.localPosition.y, 0f);
		this.text.transform.localPosition = new Vector3 (offsetX + this.iconBounds.size.x + 10.0f, this.text.transform.localPosition.y, 0f);
	}

	private void OnClickHandler(GameObject o)
	{
		if (this.itemClick != null) this.itemClick.Invoke (this.treeData);
	}
}
