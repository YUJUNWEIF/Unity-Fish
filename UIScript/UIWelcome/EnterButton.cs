using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnterButton : MonoBehaviour 
{
    GameObject obj;
	void Start ()
    {
        obj = GameObject.FindGameObjectWithTag("seconds");
        obj.SetActive(false);
        Debug.Log(obj.name);
        this.GetComponent<Button>().onClick.AddListener(delegate() {  });
	}
   
}
