using UnityEngine;
using System.Collections;

public class Globe : MonoBehaviour 
{
    /// <summary>
    /// 是否执行手动组装
    /// </summary>
    public static bool isManualAssembly=false;

    /// <summary>
    /// 是否执行手动拆解
    /// </summary>
    public static bool isManualDisassembly = false;

    /// <summary>
    /// 是否进入手动组装状态
    /// </summary>
    public static bool enterManualAssembly = false;

    /// <summary>
    /// 是否进入手动拆解状态
    /// </summary>
    public static bool enterManualDisassembly = false;

    /// <summary>
    /// 是否执行自动组装
    /// </summary>
    public static bool isAutomaticAssembly = false;

    /// <summary>
    /// 是否执行自动拆解
    /// </summary>
    public static bool isAutomaticDisassembly = false;
}
