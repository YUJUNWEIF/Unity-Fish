using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeCanvesManager : MonoBehaviour
{
    public static WelcomeCanvesManager Instance = null;
    void Awake()
    {
        Instance = this; 
    }
	void Start ()
    {
		
	}
}
