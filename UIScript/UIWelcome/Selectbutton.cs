using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectbutton : MonoBehaviour 
{

    bool isUpdate = false;
	void Start ()
    {
        EventTriggerListener.Get(transform.Find("ButtonChallenge").gameObject).onClick = RUN;
	}
    /// <summary>
    /// 委托方法
    /// </summary>
    /// <param name="obj"></param>
    void RUN(GameObject obj)
    {
        if (isUpdate)
        {
            cancleStytle();
            return;
        }
        UpdateStyle();
    }
    /// <summary>
    /// 改变背景和字体颜色
    /// </summary>
    void UpdateStyle()
    {
        isUpdate = true;
        Image[] images=transform.GetComponentsInChildren<Image>();
        foreach(Image img in images)
        {
            img.color = Color.gray;
        }
        Text[] texts = transform.GetComponentsInChildren<Text>();
        foreach(Text t in texts)
        {
            t.color = Color.yellow;
        }
    }
    /// <summary>
    /// 取消改变背景和字体颜色
    /// </summary>
    void cancleStytle()
    {
        isUpdate = false;
        Image[] images = transform.GetComponentsInChildren<Image>();
        foreach (Image img in images)
        {
            img.color = Color.white;
        }
        Text[] texts = transform.GetComponentsInChildren<Text>();
        foreach (Text t in texts)
        {
            t.color = Color.white;
        }
    }
   
}
