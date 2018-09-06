using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹生产工厂
/// 主要用来生产子弹，根据不同的类型生产不同的子弹，每次生成指定数量的子弹
/// ，然后交给ARGun类
/// </summary>
public class BullteFactory  
{
   // string ButtleType;
    public static List<buttle> CreateButtle(BullteType type,int count)
    {
        List<buttle> list = null;
        switch (type)
        { 
            case BullteType.A:
                list=CreateA(count,type);
                break;
            case BullteType.B:
                list= CreateB(count,type);
                break;
        }
        return list;
    }
    private static List<buttle> CreateA(int count,BullteType _type)
    {
        List<buttle> list = new List<buttle>();
        for (int i = 0; i < count;i++ )
        {
            GameObject A = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            A.transform.Rotate(new Vector3(90, 0, 0));
            A.transform.localScale = new Vector3(0.009f, 0.01f, 0.01f);
            buttle but = A.AddComponent<buttle>();
            but.type = _type;
            list.Add(but);
        }
        return list;
    }
    private static List<buttle> CreateB(int count,BullteType _type)
    {
        List<buttle> list = new List<buttle>();
        for (int i = 0; i < count; i++)
        {
            GameObject B = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            B.transform.Rotate(new Vector3(90, 0, 0));
            B.transform.localScale = new Vector3(0.009f, 0.01f, 0.01f);
            buttle but = B.AddComponent<buttle>();
            but.type = _type;
            //B.SetActive(false);
            list.Add(but);
        }
        return list;
    }
    
}
public enum BullteType
{ 
    A,B
};
