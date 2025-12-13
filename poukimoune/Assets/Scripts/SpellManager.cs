
using UnityEngine;

namespace DefaultNamespace
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        
        [SerializeField] private TurnManager m_turnManager;
        
        // hésite pas à t'inspirer de la review sur Maxence pour DRY tes callSpell
        
        public void CallSpell1()
        {       
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            playerPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[0].damages;
            playerPokimon.playAttack();
            Debug.Log("Tu as " + playerPokimon.runtimeData.hp + "PV");
            m_turnManager.EndTurn();
        }
        
        public void CallSpell2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[1].damages * playerPokimon.runtimeData.attack;
            playerPokimon.playAttack();
            Debug.Log("L'ennemi a " + otherPokimon.runtimeData.hp + "PV");
            m_turnManager.EndTurn();
        }
        
        public void CallSpell3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[2].damages * playerPokimon.runtimeData.attack;
            playerPokimon.playAttack();
            // gaffe aux debug logs, ca coute cher en perf, faut les retirer quand tu t'en sers plus
            Debug.Log("L'ennemi a " + otherPokimon.runtimeData.hp + "PV");
            m_turnManager.EndTurn();
        }
        
        public void CallSpell4()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;

            playerPokimon.runtimeData.attack += 3;
            playerPokimon.isBuffed += 1;
            playerPokimon.playAttack();
            Debug.Log("L'ennemi a " + otherPokimon.runtimeData.hp + "PV");
            m_turnManager.EndTurn();
        }
    }
}