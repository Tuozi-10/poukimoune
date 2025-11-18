using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]
public class EntityData : ScriptableObject
{
    public enum pokemonType
    {
        none,
        water,
        fire,
        grass,
        insect,
        poison
    }
    
    [field:SerializeField] public int hp { get; private set; }
    [field:SerializeField] public pokemonType type{ get; private set; }
    [field:SerializeField] public int attack { get; private set; }

    public EntityDataWrapper GetRuntimeData()
    {
        return new EntityDataWrapper(this);
    }
}

// cloned data to avoid break scriptable data
public class EntityDataWrapper
{
    public int hp;
    public int hpToto;
    public EntityData.pokemonType type;
    public int attack;

    public EntityDataWrapper(EntityData data)
    {
        hpToto = hp = data.hp;
        type = data.type;
        attack = data.attack;
    }
}
