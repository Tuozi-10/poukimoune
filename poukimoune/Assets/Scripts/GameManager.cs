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
            if (instance != null)
            {
                currentState = GameState.Game;
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this);
            currentState = GameState.Game;
        }
        
    }
}