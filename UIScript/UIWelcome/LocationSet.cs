using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using UnityEngine;

///注意这里有一个util命名空间
/*
 * 
 * 如：english.xml
 * <?xml version="1.0" encoding="UTF-8"?>
        <language>
	    <text>开始#Start</text>
	    <text>游戏#Game</text>
	    <text>退出#Exit</text>
    </language>
*/
namespace util
{
    /// <summary>
    /// 语言本地化
    /// </summary>
    public class LocationSet
    {
        private static LanguageType currentType;
        //中文目录
        private static Dictionary<string, string> chinas = new Dictionary<string, string>();
        //国家对国家语言转换
        private static Dictionary<string, string> dict = new Dictionary<string, string>();

        public static void ReplaceLanguge(LanguageType type,Text[] texts)
        {
            //当前语言重复自己替换自己
            if (type == currentType) return;
            currentType = type;

            XmlDocument doc = new XmlDocument();
            string file = System.Enum.GetName(type.GetType(), type);
            doc.Load(UnityEngine.Application.dataPath + "/myfile/" + file+".xml");
            XmlElement root = doc.DocumentElement;//get root;

            if (dict.Count <= 0)
            {
                XmlNodeList list = root.ChildNodes;
                foreach (XmlNode node in list)
                {
                    string[] value = node.InnerText.Split('#');
                    //中文目录
                    chinas.Add(value[0], value[1]);// 开始#Start
                    dict.Add(value[0], value[1]);// 开始#Start               
                }
            }
            else
            {
                dict.Clear();
                XmlNodeList list = root.ChildNodes;
                foreach (XmlNode node in list)
                {
                    string[] value = node.InnerText.Split('#');//游戏#2390
                    //每个国家的对应表数目都要一样
                    if (chinas.ContainsKey(value[0]))//用中文目录来进行比较
                    {
                        //上一门语言做为Key: Start ,当前语言做为Value 2390
                        dict.Add(chinas[value[0]], value[1]);
                        //更新中文目录中的对应值,把中文重新对应该当前值，方便下一次别的语言更新
                        chinas[value[0]] = value[1];//游戏#Start -> 游戏#2390 : 中文目录始终不变
                    }
                }
            }
            LocationSet.replace(texts);
        }
        private static void replace(Text[] texts)
        {
            try
            {
                foreach (Text t in texts)
                {
                    string value = t.text.Trim();
                    //dict: Key: 上一门语言, Value:当前语言
                    if (dict.ContainsKey(value))
                    {
                        t.text = dict[value];
                    }
                }
            }
            catch (System.Exception e) { }
        }
    }

    /// <summary>
    /// 把每个国家的语言的文件名和枚举名一样。
    /// 如：china.xml
    ///     english.xml
    ///     ....
    /// 通过枚举的类型获得字符串值：如：
    /// LanguageType.english
    /// string name = System.Enum.GetName(LanguageType.english.GetType(), LanguageType.english);
    /// 得到字符串：english
    /// 再如：
    /// void test(LanguageType type)
    /// {
    ///     string name = System.Enum.GetName(type.GetType(),type);
    ///     Debug.Log(name);//打印english
    /// }
    /// test(LanguageType.english);
    /// </summary>
    public enum LanguageType
    {
        china,english,hanguo,jiaopen
    };
}