using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 把这个类挂在Canvas上，这个类主要是在开发的时候起到一些辅助效果
/// 可以快速找到某个对象 ，或是快速找到某些处对象
/// </summary>
public class RootCanvas : MonoBehaviour 
{

    public static RootCanvas Instance = null;
    void Awake()
    {
        Instance = this;        
    }
    public static T[] GetComponentsInChildrens<T>(bool f=false)
    {
        return Instance.transform.GetComponentsInChildren<T>(f);
    }
    public static T GetComponentForName<T>(string name)
    {
        return RootCanvas.find(name).GetComponent<T>();
    }
    public static GameObject find(string path)
    {
        //绝对路径查找 - 可以查找隐藏的
        Transform obj = Instance.transform.Find(path);
        if (obj == null)
        {
            //查对路径查找 - 不可以查找隐藏的,如果将对象隐藏，可将其缩放成0
            obj = GameObject.Find(path).transform;
        }
        return obj.gameObject;
    }    
    /// <summary>
    /// 用来控制对象的隐藏或显示
    /// 可以完成某个对象缩放成0到1的隐藏和显示
    /// </summary>
    /// <param name="name"></param>
    /// <param name="f"></param>
    public static void setActive(string name, bool f)
    {
        GameObject obj = RootCanvas.find(name);
        if (obj != null)
        {
            if (obj.transform.localScale.x <= 0)
            {
                obj.transform.localScale = f ? Vector3.one : Vector3.zero;
            }
            else
            {
                obj.SetActive(f);
            }
        }
    }
    public static void setScale(string name, Vector3 value)
    {
        RootCanvas.find(name).transform.localScale = value;
    }
}
