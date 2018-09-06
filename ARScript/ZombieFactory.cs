using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.AI;
/// <summary>
/// 从xml中读取，根据当前关卡判断共要生产多少只僵尸
/// 生产完以后放到场景中
/// </summary>
public class ZombieFactory : MonoBehaviour
{
    public static ZombieFactory _Instance = null;
    
    private int currentLeval = 0;//当前关卡
    private int currentCountZombie = 0;//当前共要生产的怪物
    private List<Zombie> zombies = null;
    string currentLevalPosition = "";
    private bool outEnumyComplete = false;//当前怪是否已出完
    public Transform Parent;
    void Start()
    {
        //Parent = GameObject.Find("Cube1").transform;
    }
    void Awake()
    {
        _Instance = this;
        zombies = new List<Zombie>();
    }
    public int LoadLeval(int _currentLeval)
    {
        if (currentLeval <= 0)
        {
            currentLeval = _currentLeval;
            LoadCurrentLevalZombie();
            return Create();
        }
        return 0;
    }
    public int updateZombie()
    {
        return Create();
    }
    private int Create()
    {
        int CreateCount = Random.Range(3, 6);//3,5
        //2: 要判断一下当前生产的怪物是不是已经超过了剩余的怪物，
        //3: 如果超过了，就把还剩下的怪物做为当前要产生的怪物总数,并且设置当前怪物已出玩
        //4: 从zombies中得到要生产的怪物，生产一个，要从数组中删除一个
        //5: 并且设置怪物在场景中的位置
        if (CreateCount > currentCountZombie)
        {
            CreateCount = currentCountZombie;
            outEnumyComplete = true;//当前怪物已出完
        }
        if (CreateCount <= 0)
        {
            currentLeval = 0;
            return currentLeval;
        }
        List<Vector3> point = getPoint(CreateCount);
        for (int i = 0; i < CreateCount; i++)
        {
            Zombie zom = zombies[0];            
            zom.gameObject.SetActive(true);
            zom.transform.position = point[i];
            zombies.RemoveAt(0);
        }
        point.Clear();
        currentCountZombie -= CreateCount;
        return CreateCount;
    }
    /// <summary>
    /// 选择不重复的位置
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    private List<Vector3> getPoint(int n)
    {
        List<Vector3> list = new List<Vector3>(n);
        //每随机选中一个位置的时候，就把这个下标当做键保存起，以后只要比较一下就可以知道有没有相同过
        Dictionary<int, int> dict = new Dictionary<int, int>();
        string[] pos = currentLevalPosition.Split('#');
        int posLen = pos.Length;
        while (true)
        {
            int index = Random.Range(0, posLen);
            if (dict.ContainsKey(index)) continue;
            dict.Add(index,0);
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
    /// <summary>
    /// 1:从XML中把当前关的怪物物全部加载出来，且设置它们为SetActive(false);把怪物代码挂上
    /// 2：把它们都保存在zombies数组中
    /// 3: 设置每一只怪物的血量，英雄去血
    /// 4: 在这里要用到XMLManager,WWWLoad
    /// </summary>
    private void LoadCurrentLevalZombie()
    {
        XMLManager.LoadXML("file:///" + Application.dataPath + "/File/Enemy.xml");
        XmlElement root = XMLManager.GetXMLRoot("Enemy")["Level" + currentLeval];
        currentLevalPosition = root["pos"].InnerText;
        currentCountZombie = int.Parse(root.GetAttribute("count"));
       // Debug.Log(root.GetAttribute("count"));
        XmlNodeList list = root.ChildNodes;
        foreach (XmlNode _node in list)
        {
            XmlElement node = (XmlElement)_node;
            if (node.Name .Equals("pos")) break;
            int count = int.Parse(node.GetAttribute("count"));
            Debug.Log(node.GetAttribute("count"));
            
            for (int i = 0; i < count; i++)
            {
                GameObject zombieObj = Instantiate<GameObject>(LoadManager.getGameObject(node.GetAttribute("name")));
                Debug.Log(node.GetAttribute("name"));
                Zombie zom = zombieObj.AddComponent<Zombie>();
                //zombieObj.transform.SetParent(Parent);
                //给僵尸添加EnemyFollow自动向目的地移动的类
                //zombieObj.AddComponent<EnemyFollow>();
                //添加自动寻路组件
                //zombieObj.AddComponent<NavMeshAgent>();
                zom.Hpzom = int.Parse(node.GetAttribute("hp"));
                zom.HeroLoseHp = int.Parse(node.GetAttribute("heroLoseHp"));
                zombieObj.SetActive(false);
                
                //别名
               // zombieObj.tag = "zombies";
                //Debug.Log( zombies.Count + "5555555");
                zombies.Add(zom);                
            }
        }
        switchPosition();
    }
    private void switchPosition()
    {
        int len = zombies.Count;
        int i = 0;
        while (len > 0)
        {
            int index = Random.Range(0, len);
            Zombie zom = zombies[i];
            zombies[i] = zombies[index];
            zombies[index] = zom;
            i++;
            len--;
        }
    }
	
}
