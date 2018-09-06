using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondModel : MonoBehaviour 
{
    public static SecondModel Instance = null;
    void Awake()
    {
        Instance = this;
    }
	void Start ()
    {
		
	}
	
}
