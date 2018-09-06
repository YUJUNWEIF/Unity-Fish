using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
/// <summary>
/// 加载管理
/// 1：多个相同的内容要使用的时候，要使用管理器
/// 2：多个内容要动态创建时，要用加载管理器
/// 3： Dictionary<k,v> 对象池时一种思想 适用于各种各样的语言
/// 4：多个内容重复使用时 使用对象池
/// </summary>
public class LoadManager:MonoBehaviour
{
    private static LoadManager _Instance = null;
    public static LoadManager Instance()
    { 
        if(_Instance==null)
        {
            _Instance = new LoadManager();

        }
        return _Instance;
    }
     static WWW  www;
    //把所有要加载的内容保存到字典里
    private static Dictionary<string, Object> dict = new Dictionary<string, Object>();
    private static UnityAction uc = null;
    public static void startLoad(MonoBehaviour _node,string path,UnityAction _uc)
    {
        uc = _uc;
        _node.StartCoroutine(Load(path));
    }
    public float progressGet
    { 
        get{return www.progress;}
    }
    static IEnumerator Load(string path)
    {
        www = new WWW(path);//启动一条线程
       // WWW www1 = WWW.LoadFromCacheOrDownload(path,1);
        //等待加载成功
        yield return www;
        //判断加载是否出错
        if(www.error==null||www.error.Length==0)
        {
            AssetBundle ab= www.assetBundle;
            //解析资源
            parseAssets(ab);
            //释放加载器中的内容，但是内存中的并没有删除
            ab.Unload(false);
            //使用回调函数
            uc();
            Debug.Log("www压缩资源加载成功！！");
        }
    }
    //解析资源
    private static void parseAssets(AssetBundle bundle)
    {
        Object[] objs = bundle.LoadAllAssets<Object>();
        for (int i = 0; i < objs.Length;i++ )
        {
            if(dict.ContainsKey(objs[i].name))
            {
                dict.Remove(objs[i].name);
            }
            //dict[objs[i].name]=objs[i];
            dict.Add(objs[i].name,objs[i]);
        }
    }
   // (此方法可以获取所有类型资源，只需要在调用的时候制定资源类型即可)：
	/// <summary>
    /// 获得资源 T：资源类型，如果不存在资源或类型错误则返回null
    /// </summary>
    /// <param name="name">资源名字</param>
    /// <returns></returns>
    public T GetRes<T>(string name) where T : Object
    {
        if (dict.ContainsKey(name))
        {
            return (T)dict[name];
        }
        return null;
    }
    public static Texture getTexture(string name)
    { 
        if(dict.ContainsKey(name))
        {
            Debug.Log("我是getTexture。。。j、-001");
            return (Texture)dict[name];
        }
        return null;
    }

    public static GameObject getGameObject(string name)
    {
        if(dict.ContainsKey(name))
        {
            Debug.Log("我是存在的");
            return (GameObject)dict[name];
         }
        return null;
        
    }
    public static AudioClip getAudioClip(string name)
    { 
        if(dict.ContainsKey(name))
        {
            return (AudioClip)dict[name];
        }
        return null;
    }
}

