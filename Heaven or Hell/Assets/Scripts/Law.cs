using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Law
{
    [SerializeField] private int index;
    [SerializeField] private LawType lawType;

}

public enum LawType
{
    Shirt,
    Hair,
    Accessory,
    Eye

}
