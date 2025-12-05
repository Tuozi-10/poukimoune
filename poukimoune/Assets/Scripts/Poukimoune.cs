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
         [SerializeField]  private EntityData m_data;
         public EntityDataWrapper runtimeData;

         [SerializeField]
         private SpriteRenderer m_tadMorvRenderer;

         [SerializeField, Space] private Image hpBar;
         [SerializeField] private TextMeshProUGUI hpText;

         [SerializeField, Space] private Animator m_animator;
         
         private void Awake()
         {
             runtimeData = m_data.GetRuntimeData();
            var coroutine = StartCoroutine(SwapRandomColorEveryXSeconds());
         }

         private void Update()
         {
             if (Input.GetKeyDown(KeyCode.A))
             {
                 GameManager.instance.currentState = GameManager.GameState.Menu;
             }
             HPText();
             HPBar();
             
         }

         public void PlayAttack()
         {
             m_animator.Play("Attack");
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

         public void HPBar()
         {
             hpBar.fillAmount = (float)runtimeData.hp / runtimeData.hpToto;
         }

         public void HPText()
         {
             hpText.text = runtimeData.hp.ToString() + "/" + runtimeData.hpToto.ToString();
         }
    }
}