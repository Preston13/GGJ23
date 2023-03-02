using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public SelectableItem.ItemType type = SelectableItem.ItemType.potato;
    public float timeToGrow = 30f;
    public Sprite[] growCycles;
    public bool needsWater = true;
    public bool isFertilized = false;
    public bool canHarvest = false;
    public int price = 30;
    public FarmManager manager;
    public Land land;

    [SerializeField]
    private Sprite currSprite;
    [SerializeField]
    private int currCycle = 0;
    [SerializeField]
    private float timeTillHarvest;
    private SpriteRenderer sprite;
    private Light harvestLight;

    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case SelectableItem.ItemType.potato:
                timeToGrow = 15f;
                price = 40;
                break;

            case SelectableItem.ItemType.carrot:
                timeToGrow = 10f;
                break;

            case SelectableItem.ItemType.parsnip:
                timeToGrow = 20f;
                price = 50;
                break;

        }

        timeTillHarvest = timeToGrow;
        currSprite = growCycles[currCycle];
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = currSprite;
        harvestLight = GetComponent<Light>();
        manager = FindObjectOfType<FarmManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTillHarvest > 0)
        {
            if (!needsWater)
            {
                timeTillHarvest -= Time.deltaTime;
            }
        }
        else if (!canHarvest)
        {
            harvestLight.enabled = true;
            canHarvest = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }

        for (int x = growCycles.Length; x > 0; x--)
        {
            if (timeTillHarvest <= ((x * timeToGrow) / growCycles.Length))
            {
                if (currCycle < growCycles.Length - x)
                {
                    currSprite = growCycles[growCycles.Length - x];
                    sprite.sprite = currSprite;
                    currCycle = growCycles.Length - x;
                }
            }
        }
    }

    public void Harvest()
    {
        manager.UpdateMoney(price);
        Destroy(this.gameObject);
        land.isVacant = true;
    }
}
