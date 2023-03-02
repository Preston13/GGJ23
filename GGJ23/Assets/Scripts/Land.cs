using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public bool isVacant = true;
    public Plant plant;
    public FarmManager manager;

    public void Plant()
    {
        if (isVacant && (manager.itemSelected == SelectableItem.ItemType.potato || manager.itemSelected == SelectableItem.ItemType.carrot || manager.itemSelected == SelectableItem.ItemType.parsnip))
        {
            plant.type = manager.itemSelected;
            plant.land = this;
            Instantiate<Plant>(plant, this.transform.position, Quaternion.identity);
            isVacant = false;
            manager.slotSelected.RemoveItem();
            manager.DeselectItem();
        }
    }
}
