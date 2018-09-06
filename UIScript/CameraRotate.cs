using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 调用手机的陀螺仪，控制摄像头旋转的方法；
/// </summary>
public class CameraRotate : MonoBehaviour
{

    /// <summary>
    /// 陀螺仪启动成功与否；
    /// </summary>
    bool gyInfo;
    /// <summary>
    /// 陀螺仪
    /// </summary>
    Gyroscope go;
    /// <summary>
    /// 电子罗盘启动成功与否；
    /// </summary>
    bool CmInfo;

	// Use this for initialization
	void Start ()
    {
        //判断手机是否支持陀螺仪；
        gyInfo = SystemInfo.supportsGyroscope;
        //得到陀螺仪；
        go = Input.gyro;
        //启动陀螺仪；
        go.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gyInfo)
        {
            //获得陀螺仪的欧拉角；
            Vector3 a = go.attitude.eulerAngles;
            //对直接读取到的欧拉角进行符号调整；
            a = new Vector3(-a.x, -a.y, a.z);
            //改变物体（摄像机）本身的欧拉角；
            this.transform.eulerAngles = a;
            //将摄像机旋转到正确的位置；
            this.transform.Rotate(Vector3.right * 90, Space.World);
        }
	}
    

}


