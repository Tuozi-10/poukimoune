using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "SpellData", menuName = "Scriptable Objects/SpellData")]
public class SpellData : ScriptableObject
{
    // gaffe aux serialize field vers des component qui sont des références vers des objets de ta scene,
    // tu perds en généricité, et ca rend ce spell seulement utilisable par une entité, si plusieurs se le partagent,
    // elles vont avoir des sous sur le textlifebar, car elles taperont vers le meme
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
