using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        [SerializeField] private Poukimoune ia;
        [SerializeField] private Poukimoune player;
        [SerializeField] private Button spellButton1;
        [SerializeField] private Button spellButton2;
        [SerializeField] private Button spellButton3;
        
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
            spellButton1.interactable = true;
            spellButton2.interactable = true;
            spellButton3.interactable = true;
        }
        
        // IA
        public void SetIATurn()
        {
            SetIADisplay();
            StartCoroutine(DetermineIAAction());
        }


        public IEnumerator DetermineIAAction()
        {
            yield return new WaitForSeconds(1);
            if (player.runtimeData.hp < 5)
            {
                player.loseLife(ia.runtimeData.spells[1].damages);
            }
            else if (ia.runtimeData.hp < 6)
            {
                ia.loseLife(ia.runtimeData.spells[0].damages);
            }
            else
            {
                if (Random.Range(0,2) < 1)
                {
                    player.loseLife(ia.runtimeData.spells[1].damages);
                }
                else
                {
                    player.loseLife(ia.runtimeData.spells[2].damages);
                }
            }
            EndTurn();
        }
        
        public void SetIADisplay()
        {
            spellButton1.interactable = false;
            spellButton2.interactable = false;
            spellButton3.interactable = false;
        }
    }
}