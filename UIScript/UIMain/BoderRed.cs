using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 边框红血
/// </summary>
public class BoderRed : MonoBehaviour 
{
    Image image;
    private static BoderRed _Instance = null;
    public static BoderRed Instance()
    {
        if (_Instance == null) { _Instance = new BoderRed(); }
        return _Instance;
    }
	void Start ()
    {
        image = RootCanvas.GetComponentForName<Image>("BoderRedImage");
	}
	void Update () 
    {
		
	}
    public void MakeRed()
    {
        image.color = new Color(255,255,255,255);
    }
    public void CancleRed()
    {
        image.color = new Color(255, 255, 255, 0 );
    }
}
