using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class PlatformPath
{
    public static string path
    {
        get 
        {
            string filepath= 
            #if UNITY_EDITOR
                         Application.dataPath + "/StreamingAssets/" ;
            #elif UNITY_IPHONE
                         Application.dataPath +"/Raw/";
            #elif UNITY_ANDROID
                        "jar:file://" + Application.dataPath + "!/assets/";
            #endif
            return filepath;
        }
        
    }
}
   