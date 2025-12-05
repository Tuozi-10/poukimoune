using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] private GameObject ennemie;
        public enum Turn
        {
            player,
            IA
        }

        public Turn currentTurn = Turn.player;
        
        public void EndTurn()
        {
            switch (currentTurn)
            {
                case Turn.player: 
                    currentTurn = Turn.IA;
                    SetIATurn();
                    break;
                case Turn.IA:
                    currentTurn = Turn.player; 
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
            //.DetermineIAAction();
            EndTurn();
        }

        
        public void SetIADisplay()
        {
            // désactive boutons
        }
    }
}