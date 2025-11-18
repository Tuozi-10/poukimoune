using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor.Embree;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class AllyLifeUI : MonoBehaviour
{
    [SerializeField] private List<Image> heartsImages;
    
    private void Update()
    {
        for (int i = 0; i < heartsImages.Count; i++)
        {
            if(GameManager.instance.allyHP < i)
            {
                heartsImages[i].fillAmount = 0;
            }
        }
    }
}
