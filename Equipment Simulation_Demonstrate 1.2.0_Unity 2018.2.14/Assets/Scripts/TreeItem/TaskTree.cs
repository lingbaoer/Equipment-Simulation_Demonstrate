using UnityEngine;
using System.Collections.Generic;

public class TaskTree : UTree 
{
	protected override void InitTree ()
	{
		IList<UTreeData> testList = new List<UTreeData> ();
        testList.Add(new UTreeData(20, "1", "0", "总体介绍", null));
		testList.Add (new UTreeData (20, "2", "0", "内部设备", null));
		testList.Add (new UTreeData (20, "3", "0", "外部设备", null));
		testList.Add (new UTreeData (20, "4", "2", "雷达控制器", null));
		testList.Add (new UTreeData (20, "5", "2", "车载雷达开关", null));
        testList.Add(new UTreeData(20, "6", "3", "雷达天线", null));
        testList.Add(new UTreeData(20, "7", "3", "雷达接地线", null));
        testList.Add(new UTreeData(20, "8", "2", "升降杆", null));

		this.ChangeData (testList);
	}

	protected override void ChangeTreeHeight ()
	{
		Debug.Log ("树高度变化");
	}

	protected override void ChangeTreeSelect (UTreeData uTreeData)
	{
		Debug.Log ("当前选择任务：" + uTreeData.name + "(ID:" + uTreeData.id + ")");
	}
}
