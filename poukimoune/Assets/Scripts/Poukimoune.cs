using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Poukimoune : MonoBehaviour
    {
        
        //
        
        [SerializeField] private EntityData m_data;
        public EntityDataWrapper runtimeData;

        [SerializeField]
        private SpriteRenderer m_tadMorvRenderer;

        [SerializeField] private Image lifeBar;

        [SerializeField] private Animator playerAnimator;
        
        //
         
        private void Awake()
        { 
            runtimeData = m_data.GetRuntimeData();
            var coroutine = StartCoroutine(SwapRandomColorEveryXSeconds());
        }
        
        //

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                GameManager.instance.currentState = GameManager.GameState.Menu;
            }
            
        }
        
        //

        public WaitForSeconds WaitForSeconds1 = new WaitForSeconds(1);
         
        public IEnumerator SwapRandomColorEveryXSeconds()
        {
            yield return new WaitForSeconds(0.05f);
             
            m_tadMorvRenderer.color = 
                new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
             
            yield return WaitForSeconds1;
             
            StartCoroutine(SwapRandomColorEveryXSeconds());
        }
        
        //

        public void UpdateLife()
        {
            var newLife = (float)runtimeData.hp / runtimeData.hpToto;
            
            // attention aux get component, c'est couteux, il vaut mieux que tu le stock au awake et réutilise
            lifeBar.GetComponent<Image>().fillAmount = newLife;
        }
        
        //

        public void PlayAttack()
        {
            playerAnimator.Play("Attack");
        }
        
    }
}