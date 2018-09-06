using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using UnityEngine.SceneManagement;
public class Load : MonoBehaviour
{
    XmlElement root;
    Slider slider = null;
    XmlElement current = null;
    Text text = null;
    AsyncOperation ao;
	void Start () 
    {
        slider =this.transform.Find("Slider").GetComponent<Slider>();
        init();
	}
    /// <summary>
    /// 加载配置文件xml
    /// </summary>
    void init()
    {
        XMLManager.LoadXML(PlatformPath.path + "LoadConfig.xml");
        text = this.transform.Find("Slider/Text").GetComponent<Text>();
        root = XMLManager.GetXMLRoot("LoadConfig");
        //首先加载资源
        LoadRes();
    }
    /// <summary>
    /// 加载xml
    /// </summary>
    void LoadXML()
    {
        slider.value=0;
        //得到根目录下面的第2个子节点
        current =(XmlElement)root.ChildNodes[1];
        //加载Enemy.xml
        XMLManager.LoadXML(PlatformPath.path + current.GetAttribute("name"));
    }
    /// <summary>
    /// 加载资源
    /// </summary>
    void LoadRes()
    {
        //得到根目录下面的第一个子节点
        current = (XmlElement)root.ChildNodes[0];
        upDateText();
        //www加载压缩资源
        LoadManager.startLoad(this, PlatformPath.path+ current.GetAttribute("name"), delegate()
        {
            LoadXML();
        } );
    }
    /// <summary>
    /// 加载场景
    /// </summary>
    void LoadSences()
    {
        //得到根目录下面的第3个子节点
         current=(XmlElement)root.ChildNodes[2];
         ao = SceneManager.LoadSceneAsync(current.GetAttribute("name"));
    }
    void upDateText()
    {
        //改变进度条的上面的text属性
        text.text = current.GetAttribute("text") + "......" + ((int)(slider.value * 100)) + "%";
    }
	void Update () 
    {
        if (slider != null)
        {
            if(current.GetAttribute("tag")=="res")
            {
                slider.value = LoadManager.Instance().progressGet;
            }
            else if (current.GetAttribute("tag") == "xml")
            {
                slider.value += 0.01f;
                if (slider.value >= 1)
                {
                    LoadSences();
                }
            }
            else if (current.GetAttribute("tag") == "sences")
            {
                slider.value = ao.progress;
                if (slider.value >= 0.9f) slider.value = 1f;
            }
            upDateText();
        }
	}
}
