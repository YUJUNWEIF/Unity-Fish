using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;
using UnityEngine.AI;
/// <summary>
/// 动态随机创建僵尸
/// </summary>
public class CreateEnmy : MonoBehaviour
{
    private static CreateEnmy _Instance = null;
    public static CreateEnmy Instance()
    { 
        if(_Instance==null)
        {
            _Instance = new CreateEnmy();
        }
        return _Instance;
    }

    void Start()
    {
    }
    /// <summary>
    /// 创建僵尸
    /// </summary>
    public void CreatEnmy()
    {
        XmlElement root = XMLManager.GetXMLRoot("Enemy")["Level1"]["enemy"];
        //随机创建4种僵尸
        string[] zombieTypes = { "z@walk", "DungeonSkeleton_demo", "Skeleton@Death", "skeleton_animated" };
        int index = UnityEngine.Random.Range(0,zombieTypes.Length);
        string name=zombieTypes[index];
        GameObject obj = Instantiate<GameObject>(LoadManager.getGameObject(name));
        //添加自动寻路组件
        obj.AddComponent<NavMeshAgent>();
        //给僵尸添加EnemyFollow自动向目的地移动的类
        Type classobj = Type.GetType(root.GetAttribute("className"));
        obj.AddComponent(classobj);
        
        //设置随机创建位置
    }
}

