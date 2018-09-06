using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

// <summary>
/// 多个XML加载管理器
/// 当一个场景或一个项目有多个XML要加的时候
/// 为了不一个一个的加载，可以使用一个XML加载管理器
/// 来进行XML的加载操作，加载完以后，全部保存在管理器中，
/// 用的时候，通过XML的文件名来取出指定的XML就可以了
/// </summary>
public class XMLManager : MonoBehaviour
{
    //Weapon.xml,MainSene.xml
    //Assets\myFile\Weapon.xml
    //用来保存所有加载的XML
    private static Dictionary<string, XmlElement> dict = new Dictionary<string, XmlElement>();
    /// <summary>
    /// 加载所有的指定的XML，每次加载的时候，把XML的文件名取出来判断一下该XML是
    /// 否被加载过，如果加载过，就什么都不做了，如果没有加载过，就重新加载。
    /// </summary>
    /// <param name="path">路径</param>
    public static void LoadXML(string path) 
    {
        
        int end = path.LastIndexOf(".");
        int start = path.LastIndexOf("/");
        int len=end-start-1 ;
        string name=path.Substring (start+1,len );
        Debug.Log("xml1111:" + name + "加载成功");
        if (dict.ContainsKey(name)) return;
        load(name,path);
    }
    /// <summary>
    /// 开始加载XML，加载完以后，把XML的根节点做为值，XML文件名做为键
    /// 保存在字典里
    /// </summary>
    /// <param name="name">XML文件名</param>
    /// <param name="path">要加载的路径</param>
    private static  void load(string name, string path)
    {
        Debug.Log("xml222:" + name + "加载成功");
        XmlDocument d=new XmlDocument ();
        d.Load(path);
        XmlElement  root=d.DocumentElement ;
        dict.Add(name,root);
       
    }
    // <summary>
    /// 根据指定的XML文件名来取出已经被加载好的XML，
    /// 取出的是XML的根节点，开发者，只要得到根节点，就可以根据
    /// 根节点取出所有想要的任何子节点
    /// 
    /// 前提是要把所有XML先加载好
    /// </summary>
    /// <param name="filename">文件名</param>
    /// <returns>返回指定的根节点</returns>
    public static XmlElement GetXMLRoot(string filename)
    {
        if (dict.ContainsKey(filename))
        {
            Debug.Log("我是xml加载。。。。。");
            return dict[filename];
        }
        return null;
    }
	
}
