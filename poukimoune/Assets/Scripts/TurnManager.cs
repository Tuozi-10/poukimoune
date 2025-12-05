using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        public enum Turn
        {
            player,
            IA
        }

        public Turn m_currentTurn = Turn.player;
        
        public GameObject spell_button;
        
        private int currentSpellIA = 0;
        private bool state_item = true ;
        private bool low = false ;
        
        
        [SerializeField] private SpellManager spellManager;
        [SerializeField] private Poukimoune poukimoune;
        [SerializeField] private Poukimoune mypokimoune;
        
        public WaitForSeconds WaitForSeconds2 = new WaitForSeconds(2);
        
        
        
        public void EndTurn()
        {
            switch (m_currentTurn )
            {
                case Turn.player: 
                    m_currentTurn = Turn.IA;
                    SetIATurn();
                    break;
                case Turn.IA:
                    m_currentTurn = Turn.player;
                    SetPlayerTurn();
                    break;
            }
        }

        // PLAYER
        public void SetPlayerTurn()
        {
            
            
        }
        
        // IA
        
        public void SetIATurn()
        {
            SetIADisplay();
            DetermineIAAction();
            EndTurn();
        }

        public void DetermineIAAction()
        {
            

            if (poukimoune.runtimeData.hp <= 10 & state_item & low != true)
            {
                spellManager.CallItemIA();
                state_item = false;
                
            }

            if (mypokimoune.runtimeData.hp <= 10)
            {
                low = true;
                spellManager.CallSpell1IA();
            }
            
            currentSpellIA = Random.Range(1, 3);
            switch (currentSpellIA)
            {
                case 1:
                    spellManager.CallSpell1IA();
                    break;
                case 2:
                    spellManager.CallSpell2IA();
                    break;
                case 3:
                    spellManager.CallSpell3IA();
                    break;
                
                
            }
        }

    
        
        public void SetIADisplay()
        {
            StartCoroutine(turn_on());

        }

        public IEnumerator turn_on()
        
        {
            
            spell_button.SetActive(false);
            
            yield return new WaitForSeconds(1f);
            
            spell_button.SetActive(true);
            
            
            
        }
    }
}