using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] private Canvas canvasUI;
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
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
                    SetPlayerTurnDisplay();
                    break;
            }
        }

        // PLAYER
        public void SetPlayerTurnDisplay()
        {
            //
            gameObject.SetActive(canvasUI);
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
                    break;
                case 2:
                    playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[1].damages;
                    break;
                case 3:
                    playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[2].damages;
                    break;
            }
        }
        
        public void SetIADisplay()
        {
            gameObject.SetActive(canvasUI);
        }
    }
}