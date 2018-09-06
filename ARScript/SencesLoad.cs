using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SencesLoad : MonoBehaviour 
{

	void Start () 
    {
        this.GetComponent<Button>().onClick.AddListener(delegate() { run(); });
	}
    public void run()
    {
        SceneManager.LoadSceneAsync(2);
    }
	void Update () 
    {
		
	}
}
