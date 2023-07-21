using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawManager : MonoBehaviour
{
    [SerializeField] UIContext uiContext;
    [SerializeField] List<Law> lawList = new();

    public void AddLaw(Law newLaw)
    {
        lawList.Add(newLaw);
    }

    // makes a random law
    public void MakeNewLaw()
    {
        Law newLaw = new();

        Array types = Enum.GetValues(typeof(LawType));
        int t = UnityEngine.Random.Range(0, types.Length);
        LawType type = (LawType)t;
        int maxCount = type switch
        {
            LawType.Shirt => uiContext.ShirtMaxCount,
            LawType.Hair => uiContext.HairMaxCount,
            LawType.Accessory => uiContext.AccessoryMaxCount,
            LawType.Eye => uiContext.EyeMaxCount,
            LawType.Action => uiContext.ActionMaxCount,
            LawType.Amount => uiContext.AmountMaxCount,
            LawType.Keyword => uiContext.ObjectMaxCount,
            _ => 1,
        };

        int randomIndex = UnityEngine.Random.Range(0, maxCount);

        newLaw.SetVariables(randomIndex, type);

        AddLaw(newLaw);
    }

    public List<Law> GetLawList() { return lawList; }
}
