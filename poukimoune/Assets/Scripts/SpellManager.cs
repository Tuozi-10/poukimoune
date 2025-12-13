
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

        // Pas giga claire 1 et 2, c'est dans le cas oû tu gagnes/ perd ? Y'a ptet mieux à faire niveau naming
        [SerializeField] private GameObject textGameOver1;
        [SerializeField] private GameObject textGameOver2;
        
        //

        private void Start()
        {
            textGameOver1.SetActive(false);
            textGameOver2.SetActive(false);
        }

        //

        private void CallSpellPlayer(int spellId, Poukimoune from, Poukimoune to)
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            to.runtimeData.hp -= from.runtimeData.spells[spellId].damages;
            CheckNewLife(to);
            from.PlayAttack();
            to.UpdateLife();
   
            m_turnManager.EndTurn();
        }
        
        // tu peux pas mal simplifier ton code en faisant un peu de DRY, tu as beaucoup de code duppliqué
        
        public void CallSpellPlayer1() => CallSpellPlayer(0, playerPokimon, playerPokimon);
        
        public void CallSpellPlayer2() => CallSpellPlayer(1, playerPokimon, otherPokimon);
        
        public void CallSpellPlayer3() => CallSpellPlayer(2, playerPokimon, otherPokimon);
        
        public void CallSpellPlayer4() => CallSpellPlayer(3, playerPokimon, otherPokimon);
        
        
        // pareil ici, tu peux appliquer la memelogique qu'au dessus
        
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