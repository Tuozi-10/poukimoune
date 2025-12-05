using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        
        //
        
        [SerializeField] private GameObject playerButtons;
        [SerializeField] private Poukimoune otherPokimon;
        [SerializeField] private Poukimoune playerPokimon;

        [SerializeField] private SpellManager spellManager;
        
        //
        
        public enum Turn
        {
            player,
            IA
        }
        public Turn m_currentTurn = Turn.player;
        
        //
        
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
            playerButtons.SetActive(true);
        }
        
        // IA
        
        public void SetIATurn()
        {
            SetIADisplay();
            StartCoroutine(WaitForNextAttack());
        }

        public IEnumerator WaitForNextAttack()
        {
            yield return new WaitForSeconds(0.7f);
            DetermineIAAction();
            
        }
        
        //

        public void DetermineIAAction()
        {
            Debug.Log(otherPokimon.runtimeData.hp);
            if (otherPokimon.runtimeData.hp > (float)otherPokimon.runtimeData.hpToto / 3)
            {
                if (Random.value > 0.5f)
                {
                    spellManager.CallSpellEnemy2();
                }
                else
                {
                    spellManager.CallSpellEnemy3();
                }
            }
            else if (otherPokimon.runtimeData.hp > (float)otherPokimon.runtimeData.hpToto / 5)
            {
                if (Random.value < 0.33f)
                {
                    spellManager.CallSpellEnemy2();
                }
                else if (Random.value > 0.75f)
                {
                    spellManager.CallSpellEnemy3();
                }
                else
                {
                    spellManager.CallSpellEnemy1();
                }
            }
            else if (otherPokimon.runtimeData.hp >= playerPokimon.runtimeData.hp)
            {
                spellManager.CallSpellEnemy1();
            }
            else
            {
                if (Random.value > 0.75f)
                {
                    spellManager.CallSpellEnemy2();
                }
                else
                {
                    spellManager.CallSpellEnemy1();
                }
            }
        }
        
        //
        
        public void SetIADisplay()
        {
            playerButtons.SetActive(false);
        }
    }
    
}