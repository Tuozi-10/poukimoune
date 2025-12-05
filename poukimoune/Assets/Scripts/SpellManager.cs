
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        
        [SerializeField] private TurnManager m_turnManager;

        [SerializeField] private GameObject textGameOver1;
        [SerializeField] private GameObject textGameOver2;
        
        //

        private void Start()
        {
            textGameOver1.SetActive(false);
            textGameOver2.SetActive(false);
        }

        //
        
        public void CallSpellPlayer1()
        {   
            
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            playerPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[0].damages;
            CheckNewLife(playerPokimon);
            playerPokimon.PlayAttack();
            playerPokimon.UpdateLife();
   
            m_turnManager.EndTurn();
        }
        
        //
        
        public void CallSpellPlayer2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[1].damages;
            CheckNewLife(otherPokimon);
            playerPokimon.PlayAttack();
            otherPokimon.UpdateLife();

            m_turnManager.EndTurn();
        }
        
        //
        
        public void CallSpellPlayer3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[2].damages;
            CheckNewLife(otherPokimon);
            playerPokimon.PlayAttack();
            otherPokimon.UpdateLife();

            m_turnManager.EndTurn();
        }
        
        public void CallSpellPlayer4()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[3].damages;
            CheckNewLife(otherPokimon);
            playerPokimon.PlayAttack();
            otherPokimon.UpdateLife();

            m_turnManager.EndTurn();
        }
        
        //
        
        public void CallSpellEnemy1()
        {   
            
            if (m_turnManager.m_currentTurn != TurnManager.Turn.IA)
                return;
            
            otherPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[0].damages;
            CheckNewLife(otherPokimon);
            otherPokimon.PlayAttack();
            otherPokimon.UpdateLife();

            m_turnManager.EndTurn();
        }
        
        //
        
        public void CallSpellEnemy2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.IA)
                return;

            playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[1].damages;
            CheckNewLife(playerPokimon);
            otherPokimon.PlayAttack();
            playerPokimon.UpdateLife();

            m_turnManager.EndTurn();
        }
        
        //
        
        public void CallSpellEnemy3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.IA)
                return;

            playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[2].damages;
            CheckNewLife(playerPokimon);
            otherPokimon.PlayAttack();
            playerPokimon.UpdateLife();

            m_turnManager.EndTurn();
        }
        
        //
        
        public void CheckNewLife(Poukimoune pokimone)
        {
            if (pokimone.runtimeData.hp <= 0)
            {
                pokimone.runtimeData.hp = 0;
                if (m_turnManager.m_currentTurn == TurnManager.Turn.player)
                {
                    textGameOver2.SetActive(true); 
                }
                if (m_turnManager.m_currentTurn == TurnManager.Turn.IA)
                {
                    textGameOver1.SetActive(true); 
                }

                StartCoroutine(WaitForMenu());

            }
            else if (pokimone.runtimeData.hp >= pokimone.runtimeData.hpToto)
            {
                pokimone.runtimeData.hp = pokimone.runtimeData.hpToto;
            }
        }
        
        //

        private IEnumerator WaitForMenu()
        {
            yield return new WaitForSeconds(1f);
            GameManager.instance.currentState = GameManager.GameState.Menu;
        }
    }
    
}