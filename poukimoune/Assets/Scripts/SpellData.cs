using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "SpellData", menuName = "Scriptable Objects/SpellData")]
public class SpellData : ScriptableObject
{
    [SerializeField] TextMeshProUGUI TextLifeBar;
    [field:SerializeField]
    public int damages { get; private set; } 
    
    public SpellDataWrapper GetRuntimeData()
    {
        return new SpellDataWrapper(this);
    }
}

public class SpellDataWrapper
{
    private int damages;
    
    public SpellDataWrapper(SpellData data)
    {
        damages = data.damages;
    }
}
