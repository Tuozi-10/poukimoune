using TMPro;
using UnityEditor;
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
    
    [SerializeField] public int hp;
    [SerializeField] public pokemonType type;
    [SerializeField] public int attack;

    public EntityDataWrapper GetRuntimeData()
    {
        return new EntityDataWrapper()
        {
            hp = hp,
            type = type,
            attack = attack
        };
    }
}

// cloned data to avoid break scriptable data
public class EntityDataWrapper
{
    public int hp;
    public EntityData.pokemonType type;
    public int attack;

    public void TakeDamage(int damages)
    {
        hp -= damages;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("mort");
    }
}
