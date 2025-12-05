
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        
        [SerializeField] private TurnManager m_turnManager;
        
        [SerializeField, Space] private  TextMeshProUGUI textSpell1;
        [SerializeField] private TextMeshProUGUI textSpell2;
        [SerializeField] private TextMeshProUGUI textSpell3;
        
        

        private void Start()
        {
            textSpell1.text = playerPokimon.runtimeData.spells[0].ToString();
            textSpell2.text = playerPokimon.runtimeData.spells[1].ToString();
            textSpell3.text = playerPokimon.runtimeData.spells[2].ToString();
        }

        public void CallSpell1()
        {       
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            playerPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[0].damages;
            
            m_turnManager.EndTurn();
        }
        
        public void CallSpell2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[1].damages;
            m_turnManager.EndTurn();
        }
        
        public void CallSpell3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[2].damages;
            m_turnManager.EndTurn();
        }
        
    }
}