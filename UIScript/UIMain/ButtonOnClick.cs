using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 鼠标点击事件
/// </summary>
public class ButtonOnClick : MonoBehaviour
{

	void Start () 
    {
        GameSucessUIButton();
	}
    //游戏胜利界面按钮
    void GameSucessUIButton()
    {
        EventTriggerListener.GetName("SucessReplyButton").onClick = delegate(GameObject obj)
        {
            SceneManager.LoadSceneAsync(3);
        };
        EventTriggerListener.GetName("SucessExitButton").onClick = delegate(GameObject obj)
        {
            SceneManager.LoadSceneAsync(1);
        };
    }
    /// <summary>
    /// 游戏通关界面按钮 
    /// </summary>
    void GameAllSucessUIButton()
    {
        EventTriggerListener.GetName("AllSucessReturnButton").onClick = delegate(GameObject obj)
        {
            RootCanvas.setActive("BoderRedImage/AllSucess", false);
            SceneManager.LoadSceneAsync(3);
        };
        EventTriggerListener.GetName("AllSucessExitButton").onClick = delegate(GameObject obj)
        {
            RootCanvas.setActive("BoderRedImage/AllSucess", false);
            SceneManager.LoadSceneAsync(1);
        };
    }

   

}
