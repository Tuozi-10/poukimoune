using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Poukimoune playerPokimon;
    [SerializeField] private Poukimoune otherPokimon;
    [SerializeField] private GameObject gameOverMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
// hésite pas à retirer les fonctions de monobehavior que tu n'utilises pas, si tu les as, même vides,
// unity va les enregistrer pour les appeller, et c'est dommage d'appeller des fonctions vides
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    
    
}
