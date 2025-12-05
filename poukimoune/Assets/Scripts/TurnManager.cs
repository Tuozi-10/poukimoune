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
        [SerializeField] private SpellManager spellManager;
        private int iaLastSpell;
        private float multiplier = 1f;
        
        
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
            switch (spellManager.lastSpell)
            {
                case 0:
                    spellButton2.interactable = true;
                    spellButton3.interactable = true;
                    break;
                case 1:
                    spellButton1.interactable = true;
                    spellButton3.interactable = true;
                    break;
                case 2:
                    spellButton1.interactable = true;
                    spellButton2.interactable = true;
                    break;
            }
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
            if (player.runtimeData.hp < 5 && iaLastSpell!=1)
            {
                multiplier = 1f;
                if (player.runtimeData.type.ToString() == "grass")
                {
                    print("caca");
                    multiplier = 1.4f;
                }
                else if (player.runtimeData.type.ToString() == "fire")
                {
                    multiplier = 0.6f;
                }
                else if (player.runtimeData.type.ToString() == "ice")
                {
                    multiplier = 0.6f;
                }
                else if (player.runtimeData.type.ToString() == "water")
                {
                    multiplier = 0.6f;
                }
                else if (player.runtimeData.type.ToString() == "poison")
                {
                    multiplier = 1f;
                }
                player.loseLife((int)(ia.runtimeData.spells[2].damages * multiplier));
                iaLastSpell = 1;
            }
            else if (ia.runtimeData.hp < 6 && iaLastSpell!=0)
            {
                ia.loseLife(ia.runtimeData.spells[0].damages);
                iaLastSpell = 0;
            }
            else if (iaLastSpell==1)
            {
                multiplier = 1f;
                if (player.runtimeData.type.ToString() == "grass")
                {
                    multiplier = 1.4f;
                }
                else if (player.runtimeData.type.ToString() == "fire")
                {
                    multiplier = 0.8f;
                }
                else if (player.runtimeData.type.ToString() == "ice")
                {
                    multiplier = 1.4f;
                }
                else if (player.runtimeData.type.ToString() == "water")
                {
                    multiplier = 0.8f;
                }
                else if (player.runtimeData.type.ToString() == "poison")
                {
                    multiplier = 1f;
                }
                player.loseLife((int)(ia.runtimeData.spells[2].damages * multiplier));
                iaLastSpell = 2;
            }
            else if (iaLastSpell==2)
            {
                multiplier = 1f;
                if (player.runtimeData.type.ToString() == "grass")
                {
                    print("caca");
                    multiplier = 1.4f;
                }
                else if (player.runtimeData.type.ToString() == "fire")
                {
                    multiplier = 0.6f;
                }
                else if (player.runtimeData.type.ToString() == "ice")
                {
                    multiplier = 0.6f;
                }
                else if (player.runtimeData.type.ToString() == "water")
                {
                    multiplier = 0.6f;
                }
                else if (player.runtimeData.type.ToString() == "poison")
                {
                    multiplier = 1f;
                }
                player.loseLife((int)(ia.runtimeData.spells[1].damages * multiplier));
                iaLastSpell = 1;
            }
            else
            {
                if (Random.Range(0,2) < 1 )
                {
                    multiplier = 1f;
                    if (player.runtimeData.type.ToString() == "grass")
                    {
                        print("caca");
                        multiplier = 1.4f;
                    }
                    else if (player.runtimeData.type.ToString() == "fire")
                    {
                        multiplier = 0.6f;
                    }
                    else if (player.runtimeData.type.ToString() == "ice")
                    {
                        multiplier = 0.6f;
                    }
                    else if (player.runtimeData.type.ToString() == "water")
                    {
                        multiplier = 0.6f;
                    }
                    else if (player.runtimeData.type.ToString() == "poison")
                    {
                        multiplier = 1f;
                    }
                    player.loseLife((int)(ia.runtimeData.spells[1].damages * multiplier));
                    iaLastSpell = 1;
                }
                else
                {
                    multiplier = 1f;
                    if (player.runtimeData.type.ToString() == "grass")
                    {
                        multiplier = 1.4f;
                    }
                    else if (player.runtimeData.type.ToString() == "fire")
                    {
                        multiplier = 0.8f;
                    }
                    else if (player.runtimeData.type.ToString() == "ice")
                    {
                        multiplier = 1.4f;
                    }
                    else if (player.runtimeData.type.ToString() == "water")
                    {
                        multiplier = 0.8f;
                    }
                    else if (player.runtimeData.type.ToString() == "poison")
                    {
                        multiplier = 1f;
                    }
                    player.loseLife((int)(ia.runtimeData.spells[2].damages * multiplier));
                    iaLastSpell = 2;
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