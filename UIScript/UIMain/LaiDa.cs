using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaiDa : MonoBehaviour 
{
    Image oi;
	void Start ()
    {
        oi = this.GetComponent<Image>();
	}
	
	void Update ()
    {
        if(oi.fillAmount==1)
        {
            oi.fillAmount = 0;
        }
        oi.fillAmount += 0.01f;
	}
    void FixedUpdate()
    {
    }
}
