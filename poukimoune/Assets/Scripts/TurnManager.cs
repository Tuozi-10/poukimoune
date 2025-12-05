using System;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;


namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TurnText;
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        [SerializeField] private SpellManager m_spellmanager;
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
                    TurnText.text = "Tour de l'ennemi";
                    m_currentTurn = Turn.IA;
                    SetIATurn();
                    break;
                case Turn.IA:
                    TurnText.text = "Tour du joueur";
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
        }
        
        
        public void DetermineIAAction()
        {
            int a = Random.Range(0, 10);
            if (a < 5)
            {
                if (otherPokimon.runtimeData.hp <= (float)playerPokimon.runtimeData.hp / 2)
                {
                    m_spellmanager.CallSpell2();
                }
            }
            else
            {
                m_spellmanager.CallSpell1();
            }
        }
        
        public void SetIADisplay()
        {
            // désactive boutons
        }
    }
}