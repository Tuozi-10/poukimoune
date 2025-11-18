using UnityEngine;

[CreateAssetMenu(fileName = "SpellData", menuName = "Scriptable Objects/SpellData")]
public class SpellData : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private int damage;
    [SerializeField] private AttackType type;
    
    public enum AttackType
    {
        none,
        water,
        fire,
        grass,
        insect,
        poison
    }
    public SpellDataWrapper GetRuntimeData()
    {
        return new SpellDataWrapper()
        {
            name = name,
            damage = damage,
            type = type
        };
    }
    
}

public class SpellDataWrapper
{
    public string name;
    public int damage;
    public SpellData.AttackType type;
}
