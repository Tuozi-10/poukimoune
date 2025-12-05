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
            //
            
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
                    break;
                case 2:
                    playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[1].damages;
                    Debug.Log("IA joue "+otherPokimon.runtimeData.spells[1]);
                    break;
                case 3:
                    playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[2].damages;
                    Debug.Log("IA joue "+otherPokimon.runtimeData.spells[2]);
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
    }
}