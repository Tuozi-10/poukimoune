using System;
using UnityEngine;

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
            SetIADisplay();
            DetermineIAAction();
            EndTurn();
        }

        public void DetermineIAAction()
        {
            
        }
        
        public void SetIADisplay()
        {
            // désactive boutons
        }
    }
}