using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            this.transform.position += Vector3.forward;
        }
        if(Input.GetMouseButtonDown(2))
        {
            this.transform.position += Vector3.forward * -1;
        }
	}
}
