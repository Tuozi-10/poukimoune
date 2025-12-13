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
        // ca marche pas ca chef, si t'as 20/20 pv, si t'ajoutes 3, il va te mettre à 20, puis le hp += à la fin va te faire dépasser
        // faudrait faire hp = Math.Clamp(hp + incr_amount, 0, maxHp);
        
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
