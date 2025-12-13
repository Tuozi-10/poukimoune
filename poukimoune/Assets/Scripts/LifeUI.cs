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
        // tu pourrais rendre le code totalement générique en modifiant 10 20 et 30 par
        // maxHp / 3 et /2 si jamais tu veux gérer ca avec plus de coeurs tu pourrais avoir tout directement géré
        // et en prime ca t'évite des magic numbers
        switch (hp)
        {
            case <= 10 : list[0].fillAmount = hp / 3f; return;
            case <= 20 : list[1].fillAmount = hp - hp / 3f; return;
            case <= 30 : list[2].fillAmount = hp - (hp / 3f) * 2; return;
        }
    }
}
