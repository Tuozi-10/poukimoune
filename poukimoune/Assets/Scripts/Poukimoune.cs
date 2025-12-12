using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Poukimoune : MonoBehaviour
    {

         [SerializeField]  private EntityData m_data;
         public EntityDataWrapper runtimeData;

         [SerializeField]
         private SpriteRenderer m_tadMorvRenderer;

         [SerializeField]
         private Image bDeV;

         [SerializeField] private Animator playerAnimator;
         
         public int isBuffed = 0;
         
         
        
         private void Awake()
         {
             runtimeData = m_data.GetRuntimeData();
            //var coroutine = StartCoroutine(SwapRandomColorEveryXSeconds());
         }

         public void playAttack()
         {
             playerAnimator.Play("Attack");
         }

         private void Update()
         {
             if (Input.GetKeyDown(KeyCode.A))
             {
                 GameManager.instance.currentState = GameManager.GameState.Menu;
             }

             if (runtimeData.hp > runtimeData.hpToto)
             {
                 runtimeData.hp = runtimeData.hpToto;
             }

             bDeV.fillAmount = (float)runtimeData.hp / runtimeData.hpToto;

             if (runtimeData.hp <= 0)
             {
                 
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