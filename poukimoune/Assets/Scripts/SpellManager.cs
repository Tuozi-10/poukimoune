
using UnityEngine;

namespace DefaultNamespace
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        
        [SerializeField] private TurnManager m_turnManager;
        
        public void CallSpell1()
        {       
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[0].damages;
            playerPokimon.anim();
            m_turnManager.EndTurn();
        }
        
        public void CallSpell2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[1].damages;
            playerPokimon.anim();
            m_turnManager.EndTurn();
        }
        
        public void CallSpell3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[2].damages;
            playerPokimon.anim();
            m_turnManager.EndTurn();
        }
        
        public void CallSpell1IA()
        {       
            if (m_turnManager.m_currentTurn != TurnManager.Turn.IA)
                return;
            
            playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[0].damages;
            otherPokimon.anim();
            
        }
        
        public void CallSpell2IA()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.IA)
                return;
            
            playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[1].damages;
            otherPokimon.anim();
            
        }
        
        public void CallSpell3IA()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.IA)
                return;
            
            playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[2].damages;
            otherPokimon.anim();
            
        }
        
        public void CallItemIA()
        {
            
            
            otherPokimon.runtimeData.hp += otherPokimon.runtimeData.spells[3].health;
            
            
        }
        
    }
}