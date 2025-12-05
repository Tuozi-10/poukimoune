using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Animation CameraCrash;
    [SerializeField] private GameObject lose;
    [SerializeField] private GameObject Win;
    
    public void EndUI()
    {
        lose.SetActive(true);
        CameraCrash.Play();
    }

    public void WinUI()
    {
        Win.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
