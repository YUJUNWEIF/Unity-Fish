using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttle : MonoBehaviour 
{

    int enemyLoseHp = 1;
    Rigidbody r = null;
    public BullteType type;
	void Start ()
    {
        r = GetComponent<Rigidbody>();
        if (r == null) r = transform.gameObject.AddComponent<Rigidbody>();
        r.isKinematic = true;
        this.gameObject.SetActive(false);
	}
    public void Move(Vector3 pos,Quaternion rotation)
    {
        this.gameObject.SetActive(true);
        this.transform.position = pos;
        r.isKinematic = false;
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        r.AddForce(cam.transform.forward*1000);
        isMove = true;
    }
	void Update () 
    {
        if (isMove)
        {
            time += Time.deltaTime;
            if (time >= 5)
            {
                buttleDestory();
            }
        }
	}
    void OnCollisionEnter(Collision con)
    {
        Debug.Log("碰撞："+con.collider.name+"<<<<<<<"+con.collider.tag);
        if (con.collider.tag == "Respawn")
        {
            //边框红血
           // BoderRed.Instance().MakeRed();
            Zombie zom=con.collider.GetComponent<Zombie>();
            zom.zombieLosehp(enemyLoseHp); 
            //子弹销毁
            buttleDestory();
            Debug.Log("僵尸正在掉血。。。");
        }

    }
    bool isMove = false;
    float time = 0;
    /// <summary>
    /// 子弹销毁（回收使用）
    /// </summary>
    public void buttleDestory()
    {
        isMove = false;
        r.isKinematic = true;
        this.gameObject.SetActive(false);
        this.transform.position = Vector3.zero;
        //开始回收子弹
        ARGun.Instance.rebackButtle(this);
    }
}
