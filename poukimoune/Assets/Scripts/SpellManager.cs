
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
            
            playerPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[0].damages;
            if (playerPokimon.runtimeData.hp > playerPokimon.runtimeData.hpToto)
            {
                playerPokimon.runtimeData.hp = playerPokimon.runtimeData.hpToto;
            }
            playerPokimon.AttackAnimation();
            m_turnManager.EndTurn();
        }
        
        public void CallSpell2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[1].damages;
            playerPokimon.AttackAnimation();
            m_turnManager.EndTurn();
        }
        
        public void CallSpell3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[2].damages;
            playerPokimon.AttackAnimation();
            m_turnManager.EndTurn();
        }
        
    }
}