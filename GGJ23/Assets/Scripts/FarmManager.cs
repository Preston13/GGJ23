using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public SelectableItem.ItemType itemSelected = SelectableItem.ItemType.none;

    public void SelectItem(SelectableItem.ItemType item)
    {
        itemSelected = item;
    }

    public void DeselectItem()
    {
        itemSelected = SelectableItem.ItemType.none;
    }
}
