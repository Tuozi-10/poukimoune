using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Poukimoune : MonoBehaviour
    {
        [SerializeField] private EntityData m_data;
        private EntityDataWrapper runtimeData;

        [SerializeField] private SpriteRenderer m_tadMorvRenderer;

        [SerializeField] private Image healthBar;
        [SerializeField] private TMP_Text healthText;
        private int maxHp;

        private void Awake()
        {
            runtimeData = m_data.GetRuntimeData();
            var coroutine = StartCoroutine(SwapRandomColorEveryXSeconds());
            maxHp = runtimeData.hp;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //GameManager.instance.currentState = GameManager.GameState.Menu;
                TakeDamage();
            }



        }

        public void TakeDamage()
        {
            runtimeData.hp -= 9;
            healthBar.fillAmount = (float) runtimeData.hp / maxHp;
            healthText.text = runtimeData.hp + " / " + maxHp + " PV";
        }






    public IEnumerator SwapRandomColorEveryXSeconds()
         {
             yield return new WaitForSeconds(0.01f); 

             m_tadMorvRenderer.color = 
                 new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
             
             
             StartCoroutine(SwapRandomColorEveryXSeconds());
         }

    }
}