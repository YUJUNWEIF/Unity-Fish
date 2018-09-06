using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CancleButton : MonoBehaviour 
{
    public string tag="";
	void Start () 
    {
        this.GetComponent<Button>().onClick.AddListener(delegate() { Close(); });
	}
    public void Close()
    {
        GameObject obj = GameObject.FindGameObjectWithTag(tag);
        Debug.Log(obj.name);
        obj.SetActive(false);
    }

	void Update () {
		
	}
}
