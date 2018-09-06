using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
public class Zombie:MonoBehaviour
{
    private int _Hpzom;
    private int _HeroLoseHp;
    Animator am;
    void Start()
    {
        am = this.GetComponent<Animator>();
    }
    public void zombieLosehp(int n)
    {
        if (this.Hpzom <= 0) return;
        this.Hpzom -= n;
        if(Hpzom<=0)
        {
            Dead();
        }
    }
    void Dead()
    {
        //取消边框红血
       // BoderRed.Instance().CancleRed();
        am.SetTrigger("Todead");
        //通知控制中心，僵尸死亡
        GameContorl.Instance.ZombieDeadNotify();
        //销毁僵尸
        DestroyObject (this.gameObject, 5.0f);
        //Destroy(this,5.0f);建议上面
    }


    public int HeroLoseHp
    {
        get { return _HeroLoseHp; }
        set { _HeroLoseHp = value; }
    }
    public int Hpzom
    {
        get { return _Hpzom; }
        set { _Hpzom = value; }
    }
}

