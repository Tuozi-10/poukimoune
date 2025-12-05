using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace DefaultNamespace
{
    
    public class GameManager : MonoBehaviour
    {
        private Image image;
        // TODO AJOUTER STATE MACHINE GAME/MENU
        // QUAND ON CHANGE LETAT -> getter setter -> changer la scene
        // IN MENU
        //  -> BOUTON PLAY / QUITTER
        // IN GAME 
        //  -> AFFICHER UN ENNEMI
        //  -> AFFICHER UNE BARRE DE VIE DESSUS + PV EN TXT + LVL 
        //  -> CREER SCRIPTABLE DATA SPELLDATA ( dommages, elements, ...)
        //  -> AFFICHER UNE LISTE DE SORTS JOUEUR
        //  -> STATE MACHINE TOUR EN COURS -> PLAYER PUIS IA
        
        [SerializeField] private Poukimoune otherPokimon;
        [SerializeField] private Poukimoune playerPokimon;
        [SerializeField] private GameObject EndMenu;
        
        public enum GameState
        {
            Menu,
            Game
        }

        private GameState m_currentState = GameState.Menu;

        public GameState currentState
        {
            get => m_currentState;
            set
            {
                m_currentState = value;
                SceneManager.LoadScene(GetSceneByState());
            }
        }
        
        public string GetSceneByState()
        {
            return m_currentState switch
            {
                GameState.Menu => "Menu",
                GameState.Game => "Game",
                _ => ""
            };
        }
        
        public static GameManager instance;
        
        private void Awake()
        {
            EndMenu.SetActive(false);
            
        }

        public void Update()
        {
            if (playerPokimon.runtimeData.hp <= 0 || otherPokimon.runtimeData.hp <= 0)
            {
                EndMenu.SetActive(true);
            }
        }

        public void Retry()
        {
            SceneManager.LoadScene("Game");
        }
    }
}