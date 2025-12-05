using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
        
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        dieScreen.SetActive(false);
    }
    
    [SerializeField] private GameObject dieScreen;
    [SerializeField] private TMP_Text dieMessage;
    
    public void OpenDieScreen(string looser)
    {
        dieScreen.SetActive(true);
        if (looser == "player")
        {
            dieMessage.text = "T MORT";
        }
        else
        {
            dieMessage.text = "Kameto le looser";
        }
    }
    
    public void ReloadScene()
    {
        Time.timeScale = 1;
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
