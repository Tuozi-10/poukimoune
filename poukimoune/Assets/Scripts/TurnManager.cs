using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;

        [SerializeField] private GameObject spellList;

        [SerializeField] private GameObject deathMenu;
        [SerializeField] private GameObject winMenu;




        private void Awake()
        {
            deathMenu.SetActive(false);
            winMenu.SetActive(false);
        }

        public enum Turn
        {
            player,
            IA
        }

        public Turn m_currentTurn = Turn.player;
        
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
            // 
        }
        
        // IA
        
        public void SetIATurn()
        {
            StartCoroutine(WaitForTurn());
            
            
            
            EndTurn();

            
        }

        public void DetermineIAAction()
        {
            int decision = Random.Range(0, 10);

            // attention à tes valeurs hardcodées, hésite pas à utiliser des scriptable, faire des consts, etc

            if (otherPokimon.runtimeData.hp < 5 && playerPokimon.runtimeData.hp < 5) 
            {
                playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[1].damages * otherPokimon.runtimeData.attack;
                otherPokimon.playAttack();
            }
            else if (otherPokimon.runtimeData.hp < 10 && decision < 5)
            {
                otherPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[0].damages;
                otherPokimon.playAttack();
            }
            else if (decision <= 6)
            {
                otherPokimon.runtimeData.attack += 3;
                otherPokimon.isBuffed += 1;
                otherPokimon.playAttack();
            }
            else
            {
                playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[2].damages * otherPokimon.runtimeData.attack;
                otherPokimon.playAttack();
            }

                
                    
            
        }
        
        // ta fonction waitforturn, elle fait tout SAUF attendre pour le turn chef
        
        private IEnumerator WaitForTurn()
        {
            spellList.SetActive(false);
            yield return new WaitForSeconds(1f);
            DetermineIAAction();
            yield return new WaitForSeconds(1f);
            if (otherPokimon.runtimeData.hp <= 0)
            {
                Time.timeScale = 0;
                winMenu.SetActive(true);
            }
            else if (playerPokimon.runtimeData.hp <= 0)
            {
                Time.timeScale = 0;
                deathMenu.SetActive(true);
            }

            if (playerPokimon.isBuffed >= 1)
            {
                playerPokimon.isBuffed -= 1;
            }
            else
            {
                playerPokimon.runtimeData.attack = 3;
            }
            if (otherPokimon.isBuffed >= 1)
            {
                otherPokimon.isBuffed -= 1;
            }
            else
            {
                otherPokimon.runtimeData.attack = 3;
            }
            
            
            spellList.SetActive(true);
        }

        public void Retry()
        {
            otherPokimon.runtimeData.hp = otherPokimon.runtimeData.hpToto;
            playerPokimon.runtimeData.hp = playerPokimon.runtimeData.hpToto;
            deathMenu.SetActive(false);
            winMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}