using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmManager : MonoBehaviour
{
    public SelectableItem.ItemType itemSelected = SelectableItem.ItemType.none;
    public GameObject shop;
    public int money = 0;
    public TextMeshProUGUI moneyText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && shop.activeSelf == false)
        {
            Debug.Log("openingShop");
            shop.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.S) && shop.activeSelf == true)
        {
            Debug.Log("closingShop");
            shop.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
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
            }
        }
    }

    public void SelectItem(SelectableItem.ItemType item)
    {
        itemSelected = item;
    }

    public void DeselectItem()
    {
        itemSelected = SelectableItem.ItemType.none;
    }

    public void UpdateMoney(int amount)
    {
        money += amount;
        moneyText.text = money.ToString();
    }
}
