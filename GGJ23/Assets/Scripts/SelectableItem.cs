using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class SelectableItem : ScriptableObject
{
    public enum ItemType
    {
        none,
        potatoSeeds,
        carrotSeeds,
        parsnipSeeds,
        sprinkler
    }
    public ItemType type = ItemType.potatoSeeds;
    public Sprite icon;
    public FarmManager manager;

    public void SelectItem()
    {
        Debug.Log(type.ToString() + " selected");

        manager.SelectItem(type);
    }

    public virtual void UseItem()
    {
        manager.SelectItem(type);
    }
}
