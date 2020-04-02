using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Transform组件助手类
/// </summary>
class TransformHelper
{
    /// <summary>
    /// 面向目标方向
    /// </summary>
    /// <param name="targetDirection">目标方向</param>
    /// <param name="transform">需要转向的对象</param>
    /// <param name="rotationSpeed">转向速度</param>
    public static void LookAtTarget(Vector3 targetDirection, Transform transform, float rotationSpeed)
    {
        if (targetDirection != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
        }
    }

    /// <summary>
    /// 查找子物体（递归查找）
    /// </summary>
    /// <param name="trans">父物体</param>
    /// <param name="goName">子物体的名称</param>
    /// <returns>找到的相应子物体</returns>
    public static Transform FindChild(Transform trans, string goName)
    {
        Transform child = trans.Find(goName);
        if (child != null)
            return child;

        Transform go = null;
        for (int i = 0; i < trans.childCount; i++)
        {
            child = trans.GetChild(i);
            go = FindChild(child, goName);
            if (go != null)
                return go;
        }
        return null;
    }
}
