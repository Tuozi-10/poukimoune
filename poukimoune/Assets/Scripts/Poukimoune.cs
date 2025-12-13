using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Poukimoune : MonoBehaviour
    {
         [SerializeField] private EntityData m_data;
         public EntityDataWrapper runtimeData;

         [SerializeField] private SpriteRenderer m_tadMorvRenderer;
         [SerializeField] private Image healthBar; 
         [SerializeField] private TMP_Text healthText; 
         
         private void Awake()
         {
             runtimeData = m_data.GetRuntimeData();
             var coroutine = StartCoroutine(SwapRandomColorEveryXSeconds());
         }
         
         // attention au naming, les autres fonctions utilisent une majuscule au début
         public void loseLife(int damage)
         {
             runtimeData.hp -= damage;
             // pas ouf ca, vaudrait mieux checker le maxHp, là tous tes mobs ont le meme max de pv
             if (runtimeData.hp > 30)
             {
                 runtimeData.hp = 30;
             }
             healthBar.fillAmount = (float)runtimeData.hp / runtimeData.hpToto;
             healthText.text = (runtimeData.hp).ToString() + "/" + (runtimeData.hpToto).ToString();
             if (runtimeData.hp <= 0)
             {
                 Time.timeScale = 0;
                 if (gameObject.CompareTag("Player"))
                 {
                     MenuManager.instance.OpenDieScreen("player");
                 }
                 else
                 {
                     MenuManager.instance.OpenDieScreen("");
                 }
             }
         }
         
         public WaitForSeconds WaitForSeconds1 = new WaitForSeconds(1);
         
         public IEnumerator SwapRandomColorEveryXSeconds()
         {
             yield return new WaitForSeconds(0.05f);
             
             m_tadMorvRenderer.color = 
                 new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
             
             yield return WaitForSeconds1;
             
             StartCoroutine(SwapRandomColorEveryXSeconds());
         }

    }
}