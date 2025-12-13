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
            // ton check sur le gameOver est duppliqué, n'hésite pas à DRY, tu pourrais ne l'appeller qu'une fois à la fin
            int action = Random.Range(0, 4);
            // pense aussi à retirer les debug.log quand tu as finis de les utiliser, ca coute cher en perf
            // c'est dommage pour le random sur les actions, si tu avais seulement mis
            // if ( playerPokimon.runtimeData.hp > otherPokimon.runtimeData.hp )
            // else if (playerPokimon.runtimeData.hp < otherPokimon.runtimeData.hp)
            // tu aurais déja eu un bon bout de logique d'ia en plus
            
            switch (action)
            {
                case 1:
                    playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[0].damages;
                    Debug.Log("IA joue "+otherPokimon.runtimeData.spells[0]);
                    playerPokimon.PlayAttack();
          
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
               
                    break;
                case 3:
                    playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[2].damages;
                    Debug.Log("IA joue "+otherPokimon.runtimeData.spells[2]);
                    playerPokimon.PlayAttack();
          
                    break;
            }
            
            if (GameOver())
            {
                Time.timeScale = 0;
                gameOverMenu.SetActive(true);
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
            // pas besoin du else ( juste le mot clef ), si tu rentres dans le if, le return te fera quitter la fonction
            else if (playerPokimon.runtimeData.hp <= 0)
            {
                Debug.Log("Gagné");
                return true;
            }
            return false;
        }
        
        
    }
}