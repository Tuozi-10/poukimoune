using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Button = UnityEngine.UI.Button;

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
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private Poukimoune EnemyPokimon;

        [SerializeField] private Button bouton1;
        [SerializeField] private Button bouton2;
        [SerializeField] private Button bouton3;
        [SerializeField] private TMP_Text tourText;
        
        [SerializeField] private UIManager UI;
        
        public void EndTurn()
        {
            switch (m_currentTurn )
            {
                case Turn.player: 
                    Check();
                    m_currentTurn = Turn.IA;
                    StartCoroutine(SetIATurn());
                    break;
                case Turn.IA:
                    Check();
                    m_currentTurn = Turn.player; 
                    SetPlayerTurn();
                    break;
            }
        }

        // PLAYER
        public void SetPlayerTurn()
        {
            tourText.text = "Toi joue";
            bouton1.interactable = true;
            bouton2.interactable = true;
            bouton3.interactable = true;
        }
        
        // IA
        
        public IEnumerator SetIATurn()
        {
            tourText.text = "Toi Pas Toi joue Pas";
            bouton1.interactable = false;
            bouton2.interactable = false;
            bouton3.interactable = false;
            yield return new WaitForSeconds(1);
            EnemyPokimon.AttackAnimation();
            SetIADisplay();
            DetermineIAAction();
            yield return new WaitForSeconds(1); 
            EndTurn();
        }

        public void DetermineIAAction()
        {
            if (EnemyPokimon.runtimeData.hp < 5) //si IA moins de 5pv
            {
                if (playerPokimon.runtimeData.hp < 5) // si joueur mois de 5 pv --> attaque
                {
                    playerPokimon.runtimeData.hp -= EnemyPokimon.runtimeData.spells[0].damages;
                }
                else //si joueur + de 5pv --> soigne
                {
                    EnemyPokimon.runtimeData.hp -= EnemyPokimon.runtimeData.spells[1].damages;
                    if (EnemyPokimon.runtimeData.hp > EnemyPokimon.runtimeData.hpToto)
                    {
                        EnemyPokimon.runtimeData.hp = EnemyPokimon.runtimeData.hpToto;
                    }
                }
            }
            else 
            {
                int n = Random.Range(0, 3);
                if (n == 1)
                {
                    EnemyPokimon.runtimeData.hp -= EnemyPokimon.runtimeData.spells[n].damages;
                }
                else
                {
                    playerPokimon.runtimeData.hp -= EnemyPokimon.runtimeData.spells[n].damages;
                }

            } 

            Debug.Log("player hp : "+playerPokimon.runtimeData.hp +"/"+playerPokimon.runtimeData.hpToto + "   enemie hp : "+EnemyPokimon.runtimeData.hp +"/"+EnemyPokimon.runtimeData.hpToto);
        }
        
        public void SetIADisplay()
        {
            // désactive boutons
        }

        private void Check()
        {
            if (playerPokimon.runtimeData.hp < 0)
            {
                UI.EndUI();
                Stop();
            }

            if (EnemyPokimon.runtimeData.hp < 0)
            {
                UI.WinUI();
                Stop();
                Debug.Log("1");
            }
        }

        private void Stop()
        {
            Debug.Log("2");
            bouton1.interactable = false;
            bouton2.interactable = false;
            bouton3.interactable = false;
            tourText.text = "";
            
        }

    }
}