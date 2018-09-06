using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 第一个界面
/// </summary>
public class FirstModel : MonoBehaviour 
{
    public static FirstModel Instance = null;
    void Awake()
    {
        Instance = this;
    }
	void Start ()
    {
        initEvent();
	}

    void initEvent()
    {
        EventTriggerListener.GetName("shareButton").onClick = openSeetting;
        EventTriggerListener.GetName("enterButton").onClick = InGame;
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    /// <param name="obj"></param>
    void InGame(GameObject obj)
    {
        this.transform.gameObject.SetActive(false);
        RootCanvas.setActive("BackGround/secondSences", true);
    }
    /// <summary>
    /// 打开设置
    /// </summary>
    /// <param name="obj"></param>
    void openSeetting(GameObject obj)
    {
        RootCanvas.setActive("BackGround/GameSetImage", true);
    }
	
}
