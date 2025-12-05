using System;
    using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] private GameObject parentSpells;
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        [SerializeField] private GameObject gameOverMenu;

        private void Start()
        {
            gameOverMenu.SetActive((false));
            Time.timeScale = 1;
        }

        public enum Turn
        {
            player,
            IA
        }

        public Turn m_currentTurn = Turn.player;
        public WaitForSeconds WaitForSeconds5 = new WaitForSeconds(5);
        
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
                    SetPlayerTurnDisplay();
                    break;
            }
        }

        // PLAYER
        public void SetPlayerTurnDisplay()
        {
            parentSpells.SetActive(true);
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
            int action = Random.Range(0, 4);
            switch (action)
            {
                case 1:
                    playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[0].damages;
                    Debug.Log("IA joue "+otherPokimon.runtimeData.spells[0]);
                    playerPokimon.PlayAttack();
                    if (GameOver())
                    {
                        Time.timeScale = 0;
                        gameOverMenu.SetActive(true);
                    }
                    break;
                case 2:
                    if (otherPokimon.runtimeData.hp - otherPokimon.runtimeData.spells[1].damages >
                        playerPokimon.runtimeData.hpToto)
                    {
                        otherPokimon.runtimeData.hp = otherPokimon.runtimeData.hpToto;
                    }
                    else
                    {
                        otherPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[1].damages;
                    }

                    Debug.Log("IA joue "+otherPokimon.runtimeData.spells[1]);
                    playerPokimon.PlayAttack();
                    if (GameOver())
                    {
                        Time.timeScale = 0;
                        gameOverMenu.SetActive(true);
                    }
                    break;
                case 3:
                    playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[2].damages;
                    Debug.Log("IA joue "+otherPokimon.runtimeData.spells[2]);
                    playerPokimon.PlayAttack();
                    if (GameOver())
                    {
                        Time.timeScale = 0;
                        gameOverMenu.SetActive(true);
                    }
                    break;
            }
        }
        
        public void SetIADisplay()
        {
            StartCoroutine(DiscableForOneSec());
        }

        public IEnumerator DiscableForOneSec()
        {
            parentSpells.SetActive(false);
            yield return new WaitForSeconds(1f);
            parentSpells.SetActive(true);
            
        }
        
        public bool GameOver()
        {
            if (playerPokimon.runtimeData.hp <= 0)
            {
                Debug.Log("perdu");
                return true;
            }
            return false;
        }
        
        
    }
}