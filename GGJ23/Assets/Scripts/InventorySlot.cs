using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public SelectableItem item;

    private Button slotButton;
    private int itemCount = 0;
    private FarmManager manager;

    private void Start()
    {
        slotButton = GetComponentInChildren<Button>();
        manager = FindObjectOfType<FarmManager>();
    }

    public void AddItem(SelectableItem newItem)
    {
        if (manager.money >= newItem.cost)
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
            slotButton.interactable = true;
            itemCount++;
            manager.UpdateMoney(-item.cost);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void RemoveItem()
    {
        itemCount--;

        if (itemCount <= 0)
        {
            icon.sprite = null;
            icon.enabled = false;
            slotButton.interactable = false;
        }
    }

    public void UseItem()
    {
        if (item != null)
        {
            manager.SelectItem(this);
        }
    }    
}
