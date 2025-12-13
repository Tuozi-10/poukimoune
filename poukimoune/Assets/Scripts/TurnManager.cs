using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        
        //
        // je suis pas trop sur de pourquoi tu mets des // partout, mais n'hésite pas à utiliser des régions,
        // comme ca tu pourras marquer une séparation, replier la zone, et avoir un joli titre
        // par exemple:
        #region Serialized Fields
        
        [SerializeField] private GameObject playerButtons;
        [SerializeField] private Poukimoune otherPokimon;
        [SerializeField] private Poukimoune playerPokimon;

        [SerializeField] private SpellManager spellManager;

        #endregion

        private const float DurationBeforeIaCanPlay = 0.7f;
        
        //
        
        public enum Turn
        {
            player,
            IA
        }
        public Turn m_currentTurn = Turn.player;
        
        //
        
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
            playerButtons.SetActive(true);
        }
        
        // IA
        
        public void SetIATurn()
        {
            SetIADisplay();
            StartCoroutine(WaitForNextAttack());
        }

        public IEnumerator WaitForNextAttack()
        {
            // De manière générale, on essaie d'éviter les "magic number", quand un projet commence à prendre de la durée,
            // tu vas te retrouver avec plein de valeurs arbitraires, et ne plus savoir apres 3 mois au soleil ce que represente 0.7f par exemple
            // C'est valable pour les autres magics numbers dessous, n'hésite pas à mettre des const en haut de ton script
            yield return new WaitForSeconds(DurationBeforeIaCanPlay);
            DetermineIAAction();
            
        }
        
        //

        public void DetermineIAAction()
        {
            // pense à clean tes logs quand tu livreras des versions "finales", ca consomme pas mal en perf
            
            // De maniere générale, cette fonction fait trop de choses
            // tu pourrais la rendre plus lisible/compréhensible en suivant l'exemple de la fonction dessous:
            
            
            Debug.Log(otherPokimon.runtimeData.hp);
            if (otherPokimon.runtimeData.hp > (float)otherPokimon.runtimeData.hpToto / 3)
            {
                // pareil, magic numbers
                if (Random.value > 0.5f)
                {
                    spellManager.CallSpellEnemy2();
                }
                else
                {
                    spellManager.CallSpellEnemy3();
                }
            }
            else if (otherPokimon.runtimeData.hp > (float)otherPokimon.runtimeData.hpToto / 5)
            {
                if (Random.value < 0.33f)
                {
                    spellManager.CallSpellEnemy2();
                }
                else if (Random.value > 0.75f)
                {
                    spellManager.CallSpellEnemy3();
                }
                else
                {
                    spellManager.CallSpellEnemy1();
                }
            }
            else if (otherPokimon.runtimeData.hp >= playerPokimon.runtimeData.hp)
            {
                spellManager.CallSpellEnemy1();
            }
            else
            {
                if (Random.value > 0.75f)
                {
                    spellManager.CallSpellEnemy2();
                }
                else
                {
                    spellManager.CallSpellEnemy1();
                }
            }
        }
        
        public void ManageIAAction2()
        {
            if (otherPokimon.runtimeData.hp > (float)otherPokimon.runtimeData.hpToto / 3)
            {
                ManageIAAdvantagedBehavior();
            }
            else if (otherPokimon.runtimeData.hp > (float)otherPokimon.runtimeData.hpToto / 5)
            {
               ManageIALoosingBehavior();
            }
            else if (otherPokimon.runtimeData.hp >= playerPokimon.runtimeData.hp)
            {
                ManageIAAdvantagedBehavior();
            }
            else
            {
                ManageIADefaultBehavior();
            }
        }

        private void ManageIAAdvantagedBehavior()
        {
            if (Random.value > 0.5f)
            {
                spellManager.CallSpellEnemy2();
            }
            else
            {
                spellManager.CallSpellEnemy3();
            }
        }

        private void ManageIALoosingBehavior()
        {
            if (Random.value < 0.33f)
            {
                spellManager.CallSpellEnemy2();
            }
            else if (Random.value > 0.75f)
            {
                spellManager.CallSpellEnemy3();
            }
            else
            {
                spellManager.CallSpellEnemy1();
            }
        }

        private void ManageIADefaultBehavior()
        {
            if (Random.value > 0.75f)
            {
                spellManager.CallSpellEnemy2();
            }
            else
            {
                spellManager.CallSpellEnemy1();
            }
        }
        
        //
        
        public void SetIADisplay()
        {
            playerButtons.SetActive(false);
        }
    }
    
}