using System;
using System.Collections;
using UnityEngine;
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
        
        public GameObject spell_button;
        
        private int currentSpellIA = 0;
        private bool state_item = true ;
        private bool low = false ;
        
        
        [SerializeField] private SpellManager spellManager;
        [SerializeField] private Poukimoune poukimoune;
        [SerializeField] private Poukimoune mypokimoune;
        
        public WaitForSeconds WaitForSeconds2 = new WaitForSeconds(2);
        
        
        
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
            
            
        }
        
        // IA
        
        public void SetIATurn()
        {
            SetIADisplay();
            DetermineIAAction();
            EndTurn();
        }

        public void DetermineIAAction()
        {

            
            // y'a plusieurs problemes ici
            // tu peux potentiellement appeller l'item et deux sorts, si les deux pokémon ont plus beaucoup de vie
            // low devrait problablement etre appellé avant l'item, sinon tu sais pas si il est low tant qu'il a pas joué au moins un tour
            // low comme nom c'est pas tres claire
            // t'as des magic numbers ( 10 ), ca pourrait etre un const ( const int palierLowLife par exemple )
            // je dirais qu'il faudrait des return dans tes deux if qui suivent, sinon le mob va encore jouer apres s'etre soigné et/ou avoir jouer le spell1
            // ton random.range à la fin ( 1,3 ), c'est un minInclusesive, maxExclusif, du coup t'auras jamais 3
            // de maniere générale, on fait plutot commencer à 0 les rand/tableaux etc, y'a qu'en PHP oû c'est toléré de commencer à 1
            // car c'est d'la merde
            // Attention à la nomenclature, tu as turn_on, donc minuscule et séparé par _,
            // et ailleurs c'est TurnOn ( exemple ) comme nomenclature, du coup maj et séparé par maj

            if (poukimoune.runtimeData.hp <= 10 & state_item & low != true)
            {
                spellManager.CallItemIA();
                state_item = false;
                
            }

            if (mypokimoune.runtimeData.hp <= 10)
            {
                low = true;
                spellManager.CallSpell1IA();
            }
            
            currentSpellIA = Random.Range(1, 3);
            switch (currentSpellIA)
            {
                case 1:
                    spellManager.CallSpell1IA();
                    break;
                case 2:
                    spellManager.CallSpell2IA();
                    break;
                case 3:
                    spellManager.CallSpell3IA();
                    break;
                
                
            }
        }

    
        
        public void SetIADisplay()
        {
            StartCoroutine(turn_on());

        }

        public IEnumerator turn_on()
        
        {
            
            spell_button.SetActive(false);
            
            yield return new WaitForSeconds(1f);
            
            spell_button.SetActive(true);
            
            
            
        }
    }
}