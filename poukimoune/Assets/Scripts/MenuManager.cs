using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas_lose;
    [SerializeField] private GameObject canvas_win;
    [SerializeField] private Poukimoune my_pouki_life;
    [SerializeField] private Poukimoune pouki_life;
    void Update()
    {
        if (my_pouki_life.runtimeData.hp <= 0)
        {
            loadScene1();
        }

        if (pouki_life.runtimeData.hp <= 0)
        {
            loadScene2();
        }
    }



    public void loadScene1()
    {
        canvas_lose.SetActive(true);
    }
    
    public void loadScene2()
    {
        canvas_win.SetActive(true);
    }

     public void reloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
