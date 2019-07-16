using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour 
{
	/// <summary>
	/// 鼠标控制相机旋转，所围绕的模型对象
	/// </summary>
    public Transform Target;   
	
	/// <summary>
    /// 鼠标拖拽时相机旋转的速度（X轴方向,Y轴方向）
	/// </summary>
    public float xSpeed = 200f, ySpeed = 200f;

    /// <summary>
    /// 滚轮缩放的速度
    /// </summary>
    public float wheelSpeed = 5.0f;

    /// <summary>
    /// 鼠标拖拽时Y轴视角的极限值，最小值、最大值
    /// </summary>
    public float yMinLimit = -50f, yMaxLimit = 50f;
	
    /// <summary>
    /// 滚轮控制相机远近时，相机距离模型的距离，当前值、最小值、最大值
    /// </summary>
	public float initDis = 4f,minDis = 2.0f,maxDis = 10.0f;

    /// <summary>
    /// 鼠标拖拽时，是否开启相机平滑
    /// </summary>
    public bool needDamping = false;

    /// <summary>
    /// 开启相机平滑时 平滑完成的时间 值越小越快
    /// </summary>
    public float damping = 5.0f;

    /// <summary>
    /// 拖拽对象的欧拉角
    /// </summary>
    public float x = 0.0f, y = 0.0f;

    /// <summary>
    /// 鼠标是否在NGUI上
    /// </summary>
    public bool isOnHove = false;
	
	
	// Use this for initialization
	void Start () 
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
	}

	void Update () 
    {
        if (Target)
        {
            if (isOnHove)
            {
                //使用鼠标左键点击拖拽控制相机旋转
                if (Input.GetMouseButton(0))
                {
                    x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                    y = ClampAngle(y, yMinLimit, yMaxLimit);
                }
                initDis -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed;
                initDis = Mathf.Clamp(initDis, minDis, maxDis);
                Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
                Vector3 disVector = new Vector3(0.0f, 0.0f, -initDis);
                Vector3 position = rotation * disVector + Target.position;
                //adjust the camera
                if (needDamping)    //相机缓冲功能
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
                    transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
                }
                else
                {
                    transform.rotation = rotation;
                    transform.position = position;
                }
            }
        }
	}

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle,min,max);
    }

    //相机缓冲功能的GUI控件
    //void OnGUI()
    //{
    //    needDamping = GUI.Toggle(new Rect(10, 10, 100, 30), needDamping, "相机缓冲");
    //}
}
