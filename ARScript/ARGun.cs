using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 主要用来发射子弹，要有子弹夹，子弹要有回收功能，要用对象池，发布到手机上之后，
/// 这个类要挂上陀螺仪
/// </summary>
public class ARGun : MonoBehaviour 
{
    Dictionary<string, List<buttle>> bulltes = new Dictionary<string, List<buttle>>(); 
	void Start () 
    {
        InitButtle();
	}
    void InitButtle()
    { 
        //A 50ge
        List<buttle> buttleA = BullteFactory.CreateButtle(BullteType.A,50);
        List<buttle> buttleB = BullteFactory.CreateButtle(BullteType.B,10);
        bulltes.Add("A",buttleA);
        bulltes.Add("B",buttleB);
    }
	void Update () 
    {
        sendButtle();
	}
    void sendButtle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Send("A");
           // AudioScript.Instance.PlayShootA();
        }
        if(Input.GetMouseButtonDown(1))
        {
            Send("B");
            //AudioScript.Instance.PlayShootB();
        }
    }
    public void Send(string type)
    {
        if (bulltes[type].Count <= 0)
        { return; }
        buttle b = bulltes[type][0];
        Transform t = GameObject.Find("ARGunSphere").transform;
        b.Move(t.position,t.rotation);
        bulltes[type].RemoveAt(0);
    }
    public void rebackButtle(buttle b)
    {
        string type = System.Enum.GetName(b.type.GetType(),b.type);
        bulltes[type].Add(b);
    }

    public static ARGun Instance = null;
    void Awake()
    {
        Instance = this;
    }

}
