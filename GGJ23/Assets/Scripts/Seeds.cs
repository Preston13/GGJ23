using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : SelectableItem
{
    public enum Type
    {
        potato,
        carrot,
        parsnips
    }
    public Type type = Type.potato;

    [SerializeField]
    private int cost = 10;

    
}
