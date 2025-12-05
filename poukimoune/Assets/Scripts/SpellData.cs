using UnityEngine;

[CreateAssetMenu(fileName = "SpellData", menuName = "Scriptable Objects/SpellData")]
public class SpellData : ScriptableObject
{

    public enum SpellType
    {
        normal,
        water,
        fire,
        grass,
        insect,
        poison,
        ground 
    }
    
    
    [field:SerializeField]
    public int damages { get; private set; }
    
    [field:SerializeField] public SpellType type{ get; private set; }
    
    [field:SerializeField]
    public int health { get; private set; }
    
    public SpellDataWrapper GetRuntimeData()
    {
        return new SpellDataWrapper(this);
    }
}

public class SpellDataWrapper
{
    private int damages;
    private int health;
    
    public SpellDataWrapper(SpellData data)
    {
        damages = data.damages;
        health = data.health;
    }
}
