using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using util;
using UnityEngine.UI;
/// <summary>
/// 游戏设置
/// </summary>
public class GameSet : MonoBehaviour
{
    public static GameSet Instance = null;
    void Awake()
    {
        Instance = this;
    }
	void Start () 
    {
        this.transform.Find("okbtn").GetComponent<Button>().onClick.AddListener(delegate() {

            Text[] texts = GameObject.Find("Canves").GetComponentsInChildren<Text>();
        });
	}
	
	void Update () 
    {
		
	}
}
