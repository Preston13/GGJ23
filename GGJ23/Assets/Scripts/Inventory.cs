using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    InventorySlot[] slots;
    [SerializeField]
    SelectableItem item;

    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            UpdateInventory();
        }
    }

    void UpdateInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].icon.sprite == null)
            {
                slots[i].AddItem(item);
            }
        }
    }
}
