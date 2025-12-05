
using UnityEngine;

namespace DefaultNamespace
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        
        [SerializeField] private TurnManager m_turnManager;
        [SerializeField] private Animator trophyAnimation;
        
        public void CallSpell1()
        {       
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            playerPokimon.loseLife(playerPokimon.runtimeData.spells[0].damages);
            m_turnManager.EndTurn();
        }
        
        public void CallSpell2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.loseLife(playerPokimon.runtimeData.spells[1].damages);
            m_turnManager.EndTurn();
            //trophyAnimation.parameters.attacking = true;
        }
        
        public void CallSpell3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.loseLife(playerPokimon.runtimeData.spells[2].damages);
            m_turnManager.EndTurn();
        }
        
    }
}