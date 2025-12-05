using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private List<Image> allyHearts;
    [SerializeField] private List<Image> enemyHearts;
    
    private void Update()
    {
        FillHearts(allyHearts, GameManager.instance.allyHP, GameManager.instance.allyMaxHP);
        FillHearts(enemyHearts, GameManager.instance.enemyHP, GameManager.instance.enemyMaxHP);
    }

    private void FillHearts(List<Image> list, int hp, int maxHp)
    {
        switch (hp)
        {
            case <= 10 : list[0].fillAmount = hp / 3f; return;
            case <= 20 : list[1].fillAmount = hp - hp / 3f; return;
            case <= 30 : list[2].fillAmount = hp - (hp / 3f) * 2; return;
        }
    }
}
