using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Image  = UnityEngine.UI.Image;

namespace DefaultNamespace
{
    public class Poukimoune : MonoBehaviour
    {
         [SerializeField]  private EntityData m_data;
         public EntityDataWrapper runtimeData;

         [SerializeField]
         private SpriteRenderer m_tadMorvRenderer;
         
         [SerializeField] Image m_healthBar;
         [SerializeField] Animator m_animator;
         
         
         
        
         
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

             UpdateUi();
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

         public void UpdateUi()
         {
             m_healthBar.fillAmount = (float)runtimeData.hp/runtimeData.hpToto;

             
         }
        

         public void anim()
         {
             m_animator.Play("Attack");
         }

    }
}