using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour 
{
    private Transform Parent;
	void Start ()
    {
        //获取位置
        Parent = GameObject.Find("Cube6").transform;
        Transform[] ts = Parent.GetComponentsInChildren<Transform>();
        string s = "";
        for (int i = 0; i < ts.Length; i++)
        {
            if (ts[i].tag == "SecondMon")
            {
                s = s + ts[i].localPosition.x + "," + ts[i].localPosition.z + "#";

            }

        }
        Debug.Log(s);
	}
}
