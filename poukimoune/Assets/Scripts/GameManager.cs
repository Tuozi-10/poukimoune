using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
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

        public static GameManager instance;
        private GameState currentState = GameState.Menu;
        public enum GameState
        {
            Menu,
            Game
        }
        
        public GameState CurrentState
        {
            get => currentState;
            set
            {
                currentState = value;
                SceneManager.LoadScene(GetSceneByState());
            }
        }
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this);
            currentState = GameState.Game;
        }
        
        public string GetSceneByState()
        {
            return currentState switch
            {
                GameState.Menu => "Menu",
                GameState.Game => "Game",
                _ => ""
            };
        }
    }
}