using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public enum Type
    {
        potato,
        carrot,
        parsnips
    }
    public Type type = Type.potato;
    public float timeToGrow = 30f;
    public Sprite[] growCycles;
    public bool needsWater = true;
    public bool isFertilized = false;
    public bool canHarvest = false;
    public int price = 30;

    [SerializeField]
    private Sprite currSprite;
    [SerializeField]
    private int currCycle = 0;
    [SerializeField]
    private float timeTillHarvest;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        timeTillHarvest = timeToGrow;
        currSprite = growCycles[currCycle];
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = currSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTillHarvest > 0)
        {
            timeTillHarvest -= Time.deltaTime;
            int timeChange = (int) (timeToGrow / timeTillHarvest);
        }
        else
        {
            canHarvest = true;
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
}
