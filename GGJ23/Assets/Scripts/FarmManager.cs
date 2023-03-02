using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmManager : MonoBehaviour
{
    public SelectableItem.ItemType itemSelected = SelectableItem.ItemType.none;
    public InventorySlot slotSelected;
    public Shop shop;
    public int money = 0;
    public TextMeshProUGUI moneyText;
    public Plant plant;

    private void Start()
    {
        moneyText.text = money.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            shop.ShopToggle();
        }

        if (Input.GetMouseButtonDown(0) && !shop.isOpen)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.GetComponent<Plant>().needsWater && itemSelected == SelectableItem.ItemType.wateringCan)
                {
                    hit.transform.gameObject.GetComponent<Plant>().needsWater = false;
                }
                if (hit.transform.gameObject.GetComponent<Plant>().canHarvest)
                {
                    hit.transform.gameObject.GetComponent<Plant>().Harvest();
                }
                /*if (hit.transform.gameObject.GetComponent<Land>().isVacant && (itemSelected == SelectableItem.ItemType.potatoSeeds || itemSelected == SelectableItem.ItemType.carrotSeeds || itemSelected == SelectableItem.ItemType.parsnipSeeds))
                {
                    Debug.Log("plant");
                    Instantiate<Plant>(plant, hit.transform);
                }*/
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (itemSelected != SelectableItem.ItemType.none)
            {
                DeselectItem();
            }
        }
    }

    public void SelectItem(InventorySlot slot)
    {
        slotSelected = slot;
        itemSelected = slotSelected.item.type;
        Cursor.SetCursor(slotSelected.item.cursor, slotSelected.item.icon.bounds.center, CursorMode.Auto);
    }

    public void DeselectItem()
    {
        itemSelected = SelectableItem.ItemType.none;
        slotSelected = null;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void UpdateMoney(int amount)
    {
        money += amount;
        moneyText.text = money.ToString();
    }
}
