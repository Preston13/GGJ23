using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventory(SelectableItem item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].icon.sprite == null)
            {
                slots[i].AddItem(item);
                break;
            }
        }
    }
}
