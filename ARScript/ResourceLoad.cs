using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

/// <summary>
/// 加载xml 和压缩文件
/// </summary>
public class ResourceLoad : MonoBehaviour
{
    
	void Start ()
    {
        LoadManager.startLoad(this, "file:///" + Application.dataPath + "/StreamingAssets/zombie_windows", LoadComplete);
        LoadManager.startLoad(this, "file:///" + Application.dataPath + "/StreamingAssets/zombie_andriond", LoadComplete);
	}
    void  LoadComplete()
    {
        XMLManager.LoadXML("file:///" + Application.dataPath + "/File/Enemy.xml");
        XMLManager.LoadXML("file:///"+Application.dataPath+"/File/Language.xml");
        CreateEnmy.Instance().CreatEnmy();
    }
}
