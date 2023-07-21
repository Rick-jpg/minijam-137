using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Law
{
    [SerializeField] private int index;
    [SerializeField] private LawType lawType;

    public int GetIndex()
    {
        return index;
    }

    public LawType GetLawType()
    {
        return lawType;
    }

    // Set the variables
    public void SetVariables(int index, LawType type) { this.index = index; this.lawType = type; }
}

public enum LawType
{
    Shirt,
    Hair,
    Accessory,
    Eye,

    Action,
    Amount,
    Keyword
}
