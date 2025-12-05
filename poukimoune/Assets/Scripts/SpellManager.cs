
using UnityEngine;

namespace DefaultNamespace
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        [SerializeField] private TurnManager m_turnManager;
        [SerializeField] private GameObject LifeBarImage;
        [SerializeField] private GameObject LifeBarImageIA;
        public void CallSpell1()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.IA)
            {
                playerPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[0].damages;
            }
            else
            {
                playerPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[0].damages;
            }
            LifeBarImage.transform.localScale = new Vector3((float)playerPokimon.runtimeData.hp / playerPokimon.runtimeData.hpToto, 1, 1); 
            m_turnManager.EndTurn();
        }
        
        public void CallSpell2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.IA)
            {
                otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[1].damages;
            }
            else
            {
                otherPokimon.runtimeData.hp -= otherPokimon.runtimeData.spells[1].damages;
            }
            LifeBarImageIA.transform.localScale = new Vector3((float)otherPokimon.runtimeData.hp / otherPokimon.runtimeData.hpToto, 1, 1); 
            m_turnManager.EndTurn();
        }
        
        public void CallSpell3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            otherPokimon.runtimeData.hp -= playerPokimon.runtimeData.spells[2].damages;
            LifeBarImage.transform.localScale = new Vector3((float)otherPokimon.runtimeData.hp / otherPokimon.runtimeData.hpToto, 1, 1);
            m_turnManager.EndTurn();
        }
        
    }
}