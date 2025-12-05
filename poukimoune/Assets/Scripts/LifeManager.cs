using System;
using DefaultNamespace;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.allyHP = GameManager.instance.allyMaxHP;
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            GameManager.instance.allyHP =
                incrementHP(-1, GameManager.instance.allyHP, GameManager.instance.allyMaxHP);
            Debug.Log("-1");
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            GameManager.instance.allyHP = 
                incrementHP(1, GameManager.instance.enemyMaxHP, GameManager.instance.enemyMaxHP);
            Debug.Log("1");
        }
    }
    
    public int incrementHP(int incr_amount, int hp, int maxHp)
    {
        if (hp + incr_amount > maxHp)
        {
            hp = maxHp;
        }
        if (hp + incr_amount < 0)
        {
            hp = 0;
        }
        hp += incr_amount;
        return hp;
    }
}
