using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainUI : MonoBehaviour
{
    public static GameMainUI Instance = null;

    void Awake() { Instance = this; }
	void Start () 
    {
		
	}
	
	void Update ()
    {
        
	}
    public void InitGameMainData(string level,string enemyCount)
    {
        RootCanvas.GetComponentForName<Text>("levelText").text=level;
        RootCanvas.GetComponentForName<Text>("EnemyText").text = enemyCount;

        EventTriggerListener.GetName("B").onClick = delegate(GameObject obj)
        {
            ARGun.Instance.Send(obj.name);
        };
        EventTriggerListener.GetName("A").onClick = delegate(GameObject obj)
        {
            ARGun.Instance.Send(obj.name);
        };
    }
    /// <summary>
    /// 游戏胜利结束，显示游戏结束进入下一关界面
    /// </summary>
    public void ShowNextLevel()
    {
        Image obj= RootCanvas.GetComponentForName<Image>("GameSucess");
        obj.gameObject.SetActive(true);
    }
    /// <summary>
    /// 显示游戏通关界面
    /// </summary>
    public void ShowAllSucess()
    {
        Image obj = RootCanvas.GetComponentForName<Image>("AllSucess");
        obj.gameObject.SetActive(true);
    }
    /// <summary>
    /// 显示游戏失败的结束界面
    /// </summary>
    public void ShowGameOver()
    {
        Image obj = RootCanvas.GetComponentForName<Image>("GameOver");
        obj.gameObject.SetActive(true);
    }
}
