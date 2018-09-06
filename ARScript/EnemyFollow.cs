using Assets.MyScript.ARScript;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 僵尸自动向目的地移动
/// </summary>
public class EnemyFollow : MonoBehaviour
{
    Animator am;//动画状态机
    public Transform obj;
    NavMeshAgent Nam;
    bool isAttack = false;
    public int Zomhp = 0;//僵尸血量
    Hero hero;
	void Start ()
    {
        obj = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//获取对象
        am = this.GetComponent<Animator>();
        Nam = this.GetComponent<NavMeshAgent>();//z自动寻路
        Invoke("MoveDestination", 3.0f);//一秒后执行
       // InvokeRepeating("MoveDestination",5.0f,1.0f);//5秒开始后执行，以后一秒执行一次
	}

    public void MoveDestination()
    {
        this.transform.LookAt(obj.position);
        Nam.SetDestination(obj.position);
    }
	void Update ()
    {
        if(!isAttack)
        {
            CheckDistence();
        }
	}

    void CheckDistence()
    {
        float f = Vector3.Distance(this.transform.position,obj.position);
        if (f <= 2.0f)
        {
            Nam.isStopped = true;//关闭自动寻路
            doAttack();
        }
        else
        { 
            if(Nam.isStopped==true)
            {
                Nam.isStopped = false;//打开自动寻路
            }
        }
    }
    /// <summary>
    /// 攻击
    /// </summary>
    void doAttack()
    {
        isAttack = true;
        am.SetTrigger("walkToattack");
        Invoke("GoOnAttack", 1.5f);
    }
    void GoOnAttack()
    {
        //英雄掉血
        //如果英雄的血量>0， isAttack = false;
        isAttack = false;
    }
    /// <summary>
    /// 设置血量和子弹类型
    /// </summary>
    /// <param name="n"></param>
    public void SetHp(int n)
    {
        this.Zomhp -= n;
        if (Zomhp <= 0)
        {
            dead();
        }

    }
    /// <summary>
    /// 死亡
    /// </summary>
    void dead()
    {
        am.SetTrigger("Todead");
        Destroy(this,5.0f);
    }

}
