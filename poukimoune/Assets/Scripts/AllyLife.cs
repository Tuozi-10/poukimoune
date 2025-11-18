using System;
using DefaultNamespace;
using UnityEngine;

public class AllyLife : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.allyHP = GameManager.instance.allyMaxHP;
    }
    
    public void incrementHP(int incr_amount)
    {
        if (GameManager.instance.allyHP + incr_amount > GameManager.instance.allyMaxHP)
        {
            GameManager.instance.allyHP = GameManager.instance.allyMaxHP;
        }
        if (GameManager.instance.allyHP + incr_amount < 0)
        {
            GameManager.instance.allyHP = 0;
        }
        GameManager.instance.allyHP += incr_amount;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            incrementHP(-1);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            incrementHP(1);
        }
    }
}
