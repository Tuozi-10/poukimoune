using DefaultNamespace;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void Play()
    {
        GameManager.instance.CurrentState = GameManager.GameState.Game;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
