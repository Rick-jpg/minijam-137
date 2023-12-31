using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech
{
    [SerializeField] private int introductionIndex;
    [SerializeField] private int actionIndex;
    [SerializeField] private int amountIndex;
    [SerializeField] private int objectIndex;
    private bool isAnConfession;

    public Speech(int introductionIndex, int actionIndex, int amountIndex, int objectIndex)
    {
        this.introductionIndex = introductionIndex;
        this.actionIndex = actionIndex;
        this.amountIndex = amountIndex;
        this.objectIndex = objectIndex;

        if(introductionIndex == 0)
        {
            this.isAnConfession = true;
        }
        else
        {
            this.isAnConfession= false;
        }
    }

    public int GetIntroductionIndex()
    {
        return introductionIndex;
    }

    public int GetActionIndex()
    {
        return actionIndex;
    }

    public int GetAmountIndex()
    {
        return amountIndex;
    }

    public int GetObjectIndex()
    {
        return objectIndex;
    }

    public bool GetConfession()
    {
        return isAnConfession;
    }
}
