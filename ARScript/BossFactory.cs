using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.AI;
/// <summary>
/// 加载指定关卡的僵尸
/// </summary>
public class BossFactory : MonoBehaviour 
{
    private Transform parent;
    private List<Zombie> zombies = new List<Zombie>();
    //保存当前关卡怪物的随机位置
    private string currentLevelZombiePosition;
    //保存当前关卡共有多少僵尸
    private int currentLevelzombieCount = 0;

    public int getCurrentLevelzombieCount
    {
        get { return currentLevelzombieCount; }
    }
    public static BossFactory Instance = null;
    void Awake() {Instance = this;}
	void Start () 
    {
        parent =GameObject.Find("Cube1").transform;
	}
    public static void LoadLevel(int _level)
    {
        //静态方法里面不能直接调用普通方法
        Instance.LoadLevelXml(_level);
    }
    /// <summary>
    /// 加载xml
    /// </summary>
    /// <param name="_level"></param>
    private void LoadLevelXml(int _level)
    {
        XMLManager.LoadXML(PlatformPath.path+ "Enemy.xml");
        XmlElement root = XMLManager.GetXMLRoot("Enemy")["Level" + _level];
        Debug.Log(root.Name + "----------" + root.GetAttribute("position"));
        currentLevelzombieCount = int.Parse(root.GetAttribute("count"));
        //string[] ps = root.GetAttribute("position").Split(',');
        Debug.Log(root.GetAttribute("position").Split(','));
        //parent.transform.position = new Vector3(float.Parse(ps[0]),0.58f,float.Parse(ps[1]));
        //得到root的所有子节点
        XmlNodeList list= root.ChildNodes; 
        currentLevelZombiePosition=root["pos"].InnerText;
        for (int i = 0; i < list.Count-1;i++ )
        {
            XmlElement node=(XmlElement)list[i];
            int count = int.Parse(node.GetAttribute("count"));
            for (int j = 0; j < count;j++ )
            {
                GameObject zomobj = Instantiate<GameObject>(LoadManager.getGameObject(node.GetAttribute("name")));
                Zombie zom= zomobj.AddComponent<Zombie>();
                zom.Hpzom = int.Parse(node.GetAttribute("hp"));
                zom.HeroLoseHp = int.Parse(node.GetAttribute("heroLoseHp"));
                zomobj.AddComponent<EnemyFollow>();
                zomobj.AddComponent<NavMeshAgent>();
                zomobj.transform.SetParent(parent);
                Debug.Log("////"+parent.transform.position);
                zomobj.SetActive(false);
                zomobj.tag = "Respawn";
                zombies.Add(zom);
            }
        }
    }
    /// <summary>
    /// 随机生产一些怪物
    /// </summary>
    /// <returns></returns>
    public static int Updayezombie()
    {
        int count = Random.Range(3,6);

        if(count>Instance.currentLevelzombieCount)
        {
            count = Instance.currentLevelzombieCount;
        }
        if(count<=0)
        {
            return 0;
        }
        List<Vector3> pos = Instance.getPoint(count);
        for (int i = 0; i < count;i++ )
        {
            Zombie zom = Instance.zombies[0];
            zom.gameObject.SetActive(true);
            zom.transform.position = pos[i];
            Instance.zombies.RemoveAt(0);
        }
        Instance.currentLevelzombieCount -= count;
        return count;
    }
    private List<Vector3> getPoint(int n)
    {
        List<Vector3> list = new List<Vector3>(n);
        //每随机选中一个位置的时候，就把这个下标当做键保存起，以后只要比较一下就可以知道有没有相同过
        Dictionary<int, int> dict = new Dictionary<int, int>();
        string[] pos = currentLevelZombiePosition.Split('#');
        int posLen = pos.Length;
        while (true)
        {
            int index = Random.Range(0, posLen);
            if (dict.ContainsKey(index)) continue;
            dict.Add(index, 0);
            string[] p3 = pos[index].Split(',');
            Vector3 v = new Vector3(float.Parse(p3[0]), 0, float.Parse(p3[1]));
            list.Add(v);
            if (list.Count >= n)
            {
                break;
            }
        }
        dict.Clear();
        return list;
    }
}
