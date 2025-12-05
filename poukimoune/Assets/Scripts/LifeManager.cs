using System.Net.Mime;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LifeBarTextPlayer;
    [SerializeField] TextMeshProUGUI LifeBarTextEnemy;
    [SerializeField] private Poukimoune otherPokimon;
    [SerializeField] private Poukimoune playerPokimon;
    
    void Update()
    {
        LifeBarTextEnemy.text = otherPokimon.runtimeData.hp.ToString();
        LifeBarTextPlayer.text = playerPokimon.runtimeData.hp.ToString();
    }
}
