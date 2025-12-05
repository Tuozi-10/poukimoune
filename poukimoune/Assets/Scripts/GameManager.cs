using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        // TODO AJOUTER STATE MACHINE GAME/MENU
        // QUAND ON CHANGE L'ETAT -> getter setter -> changer la scene
        // IN MENU
        //  -> BOUTON PLAY / QUITTER
        // IN GAME 
        //  -> AFFICHER UN ENNEMI
        //  -> AFFICHER UNE BARRE DE VIE DESSUS + PV EN TXT + LVL 
        //  -> CREER SCRIPTABLE DATA SPELLDATA ( dommages, elements, ...)
        //  -> AFFICHER UNE LISTE DE SORTS JOUEUR
        //  -> STATE MACHINE TOUR EN COURS -> PLAYER PUIS IA

        public static GameManager instance;

        public enum GameState
        {
            Menu,
            Game
        }

        private GameState _currentState = GameState.Menu;
        
        public GameState currentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                SceneManager.LoadScene(GetSceneByState());
            }
        }

        public int allyHP;
        public int enemyHP;
        public int allyMaxHP;
        public int enemyMaxHP;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            if (instance != null) Destroy(this);
            else instance = this;
        }

        private void Start()
        {
            if (allyMaxHP % 3 != 0 || enemyMaxHP % 3 != 0)
            {
                Debug.LogError("Max HP needs to be a multiple of 3 !");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                currentState = GameState.Menu;
            }
        }

        private string GetSceneByState()
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