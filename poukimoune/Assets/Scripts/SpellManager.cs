
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune otherPokimon;
        
        [SerializeField] private TurnManager m_turnManager;
        [SerializeField] private Animator trophyAnimation;
        public int lastSpell = 0;
        private float multiplier = 1;
        
        public void CallSpell1()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            lastSpell = 0;
            playerPokimon.loseLife(playerPokimon.runtimeData.spells[0].damages);
            m_turnManager.EndTurn();
        }
        
        public void AnimationSpell2()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            
            lastSpell = 1;
            trophyAnimation.Play("TrophyAttack");
            StartCoroutine(CallSpell2());
        }

        public IEnumerator CallSpell2()
        {
            yield return new WaitForSeconds(1/3f);
            multiplier = 1f;
            if (otherPokimon.runtimeData.type.ToString() == "grass")
            {
                print("caca");
                multiplier = 1.4f;
            }
            else if (otherPokimon.runtimeData.type.ToString() == "fire")
            {
                multiplier = 0.6f;
            }
            else if (otherPokimon.runtimeData.type.ToString() == "ice")
            {
                multiplier = 0.6f;
            }
            else if (otherPokimon.runtimeData.type.ToString() == "water")
            {
                multiplier = 0.6f;
            }
            else if (otherPokimon.runtimeData.type.ToString() == "poison")
            {
                multiplier = 1f;
            }
            
            otherPokimon.loseLife((int)(playerPokimon.runtimeData.spells[1].damages * multiplier));
            m_turnManager.EndTurn();
        }
        
        public void CallSpell3()
        {
            if (m_turnManager.m_currentTurn != TurnManager.Turn.player)
                return;
            multiplier = 1f;
            if (otherPokimon.runtimeData.type.ToString() == "grass")
            {
                multiplier = 1.4f;
            }
            else if (otherPokimon.runtimeData.type.ToString() == "fire")
            {
                multiplier = 0.8f;
            }
            else if (otherPokimon.runtimeData.type.ToString() == "ice")
            {
                multiplier = 1.4f;
            }
            else if (otherPokimon.runtimeData.type.ToString() == "water")
            {
                multiplier = 0.8f;
            }
            else if (otherPokimon.runtimeData.type.ToString() == "poison")
            {
                multiplier = 1f;
            }
            lastSpell = 2;
            otherPokimon.loseLife((int)(playerPokimon.runtimeData.spells[2].damages * multiplier));
            m_turnManager.EndTurn();
        }
        
    }
}