using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 游戏控制中心类
/// 1，主要负责监听当前场景总共要出多少个僵尸，当前有多少，还要出多少
/// 2，当前关卡是多少
///3 ，如果怪快打完了，要调用怪物生产工厂马上生产怪物
/// 4，读取游戏设置的总xml
/// </summary>
public class GameContorl : MonoBehaviour
{
    //当前关卡
    int currentLevel = 1;
    public static GameContorl Instance = null;
    int currentZombieCount=0;
    void Awake(){ Instance = this;}

	void Start ()
    {
       /// LoadManager.startLoad(this, "file:///" + Application.dataPath + "/StreamingAssets/zombie_windows", delegate() 
        //{ ZombieFactory._Instance.LoadLeval(1); });
        Invoke("LoadNextLevel", 1f);
        currentZombieCount = BossFactory.Updayezombie();
	}
	
	void Update () 
    {
		
	}
    /// <summary>
    /// 检测结束死亡
    /// </summary>
    public void ZombieDeadNotify()
    {
        currentZombieCount--;
        if (currentZombieCount <= Random.Range(1,3))
        {
            currentZombieCount += BossFactory.Updayezombie();
        }
        if (currentZombieCount <= 0)
        {
            Debug.Log("Game Over.....");
            RootCanvas.setActive("BoderRedImage/GameSucess", true);
            EventTriggerListener.GetName("SucessNextButton").onClick = delegate(GameObject obj)
            {
                currentLevel++;
                LoadNextLevel();
                RootCanvas.setActive("BoderRedImage/GameSucess", false);
            };
            if (currentLevel >= 6)
            {
                RootCanvas.setActive("BoderRedImage/AllSucess", true);
            }
        }
    }

    /// <summary>
    /// 加载下一关
    /// </summary>
    public void LoadNextLevel()
    {
        Debug.Log("加载当前关卡："+currentLevel);
        BossFactory.LoadLevel(currentLevel);
        BossFactory.Updayezombie();
        //通知ui显示
        GameMainUI.Instance.InitGameMainData(currentLevel.ToString(), BossFactory.Instance.getCurrentLevelzombieCount.ToString());
    }



}
