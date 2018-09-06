
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

namespace Assets.myScript.Bag
{
    class WWWLoad
    {
        UnityAction uc;
        private Dictionary<string, Object> dict = new Dictionary<string,Object>();
        private MonoBehaviour node;
        private static WWWLoad _Instance = null;
        public static WWWLoad Instance()
        {
            if (_Instance == null) _Instance = new WWWLoad();
            return _Instance;
        }
        //加载路径
        IEnumerator Loadsrc(string path)
        {
            WWW www = new WWW(path);
            yield return www;
            if(www.error==null||www.error.Length==0)
            {
                this.parseResource(www.assetBundle);
                this.uc();
            }
        }
        //解析资源，取出所有加载的内容放到字典中去
        private void parseResource(AssetBundle bundle)
        { 
            Object [] os=bundle.LoadAllAssets<Object>();
            for (int i = 0; i < os.Length;i++ )
            {
                if (dict.ContainsKey(os[i].name))
                {
                    dict.Remove(os[i].name);
                }
                dict[os[i].name]=os[i];
            }
            bundle.Unload(false);
        }
        //启动枚举迭代器线程，使用了回调
        public void startLoad(MonoBehaviour _node, string path, UnityAction _uc)
        {
            this.uc = _uc;
            this.node = _node;
            this.node.StartCoroutine(Loadsrc(path));

        }
        //贴图
        public Texture getTexture(string name)
        {
            if (dict.ContainsKey(name))
            {
                return (Texture)dict[name];
            }
            return null;
        }

        public GameObject getGameobject(string name)
        { 
            if(dict.ContainsKey(name))
            {
                return (GameObject)dict[name];
            }
            return null;
        }




    }

   
}
