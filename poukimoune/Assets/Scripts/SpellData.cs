using UnityEngine;

[CreateAssetMenu(fileName = "SpellData", menuName = "Scriptable Objects/SpellData")]
public class SpellData : ScriptableObject
{
    public enum attackType
    {
        none,
        water,
        fire,
        grass,
        ice,
        poison
    }
    
    [field:SerializeField] public int damages { get; private set; }
    [field:SerializeField] public attackType type{ get; private set; }
    
    public SpellDataWrapper GetRuntimeData()
    {
        return new SpellDataWrapper(this);
    }
}

public class SpellDataWrapper
{
    private int damages;
    private SpellData.attackType type;
    
    public SpellDataWrapper(SpellData data)
    {
        damages = data.damages;
        type = data.type;
    }
}
