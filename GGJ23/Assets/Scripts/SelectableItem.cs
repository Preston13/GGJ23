using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class SelectableItem : ScriptableObject
{
    public enum ItemType
    {
        none,
        potato,
        carrot,
        parsnip,
        sprinkler,
        wateringCan
    }
    public ItemType type = ItemType.potato;
    public Sprite icon;
    public Texture2D cursor;
    public FarmManager manager;
    public int cost;

    public void SelectItem()
    {

        //manager.SelectItem(type);
    }

    public virtual void UseItem()
    {
        //manager.SelectItem(type);
    }
}
