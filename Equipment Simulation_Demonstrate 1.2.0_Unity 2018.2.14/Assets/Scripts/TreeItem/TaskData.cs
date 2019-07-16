using UnityEngine;
using System.Collections;

public class TaskData
{
	/// <summary>
	/// 任务编号
	/// </summary>
	public string taskID;

	/// <summary>
	/// 任务名称
	/// </summary>
	public string taskName;

	public TaskData(string taskID, string taskName)
	{
		this.taskID = taskID;
		this.taskName = taskName;
	}
}
