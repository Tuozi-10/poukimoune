using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]
public class EntityData : ScriptableObject
{
    [field: SerializeField] public int hpInitial { get; private set; }
    [field: SerializeField] public int lvlInitial { get; private set; }
    [field: SerializeField] public pokemonType typeInitial { get; private set; }

    public enum pokemonType
    {
        none,
        water,
        fire,
        grass,
        insect,
        poison
    }

    public EntityDataWrapper GetRuntimeData()
    {
        return new EntityDataWrapper(this);
    }
}

// cloned data to avoid break scriptable data
public class EntityDataWrapper
{
    public int hp;
    public int hpMax;
    public int level;
    public EntityData.pokemonType type;
    
    public EntityDataWrapper(EntityData data)
    {
        hp = data.hpInitial;
        hpMax = data.hpInitial;
        level = data.lvlInitial;
        type = data.typeInitial;
    }
    
    public void LoseLife(int damage, Image lifeBar, TMP_Text lifeText)
    {
        hp -= damage;
        lifeBar.fillAmount = (float)hp/hpMax;
        lifeText.text = "HP: " + hp + "/" + hpMax;
    }
}
