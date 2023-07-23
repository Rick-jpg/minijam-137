using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawManager : MonoBehaviour
{
    [SerializeField] UIContext uiContext;
    [SerializeField] private List<Law> lawList;

    private int maxLaws = 10;
    private int currentLaws = 0;

    public delegate void SetSentence(string sentence);
    public static SetSentence OnSetSentence;

    public void SetupLaws(int startLaws)
    {
        lawList = new List<Law>();
        string startSentence = "People that confess to their crimes shall not be allowed entrance.";
        MakeStartLaw(startSentence);

        for (int i = 0; i < startLaws; i++)
        {
            MakeNewLaw();
        }
    }

    void AddLaw(Law newLaw)
    {
        lawList.Add(newLaw);
    }
    public void MakeStartLaw(string startSentence)
    {
        OnSetSentence.Invoke(startSentence);
    }
    // makes a random law
    [ContextMenu("Make Law")]
    public void MakeNewLaw()
    {
        if (currentLaws == maxLaws) return;
        Law newLaw = new Law();

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
        newLaw.SetSentence(MakeSentence(newLaw));
        if(lawList.Contains(newLaw))
        {
            Debug.Log("Already exists");
            MakeNewLaw();
            return;
        }
        OnSetSentence?.Invoke(newLaw.GetSentence());
        AddLaw(newLaw);
        currentLaws++;

    }

    // Makes the sentence for the law book
    public string MakeSentence(Law currentLaw)
    {
        string sentence = "";

        switch (currentLaw.GetLawType())
        {
            case LawType.Shirt:
                sentence += "People wearing " + uiContext.GetAttributeText(currentLaw.GetIndex(), currentLaw.GetLawType()) + " shirt"; 
                break;

            case LawType.Hair:
                sentence += "People with " + uiContext.GetAttributeText(currentLaw.GetIndex(), currentLaw.GetLawType()) + " hair";
                break;

            case LawType.Accessory:
                sentence += "People wearing " + uiContext.GetAttributeText(currentLaw.GetIndex(), currentLaw.GetLawType()) + " accessory";
                break;

            case LawType.Eye:
                sentence += "People with " + uiContext.GetAttributeText(currentLaw.GetIndex(), currentLaw.GetLawType()) + " colored eyes";
                break;

            case LawType.Action:
                sentence += "People that have done " + uiContext.GetAttributeText(currentLaw.GetIndex(), currentLaw.GetLawType());
                break;

            case LawType.Amount:
                sentence += "People that say the number " + uiContext.GetAttributeText(currentLaw.GetIndex(), currentLaw.GetLawType());
                break;

            case LawType.Keyword:
                sentence += "People talking about " + uiContext.GetAttributeText(currentLaw.GetIndex(), currentLaw.GetLawType());
                break;

            default:
                break;
        }

        sentence += " shall not be allowed entrance.";

        return sentence;
    }

    // Returns true if the given character's traits
    public bool CheckGuilty(Person character)
    {
        Debug.Log(lawList.Count);
        // Check if the speech is an confession
        Speech confession = character.GetSpeech();
        if (confession.GetConfession() == true) return true;
        // Go through each active law and check against the person
        for (int i = 0; i < lawList.Count; i++)
        {
            var attributeIndex = lawList[i].GetLawType() switch
            {
                LawType.Shirt => character.GetShirtIndex(),
                LawType.Hair => character.GetHairIndex(),
                LawType.Accessory => character.GetAccessoryIndex(),
                LawType.Eye => character.GetEyeIndex(),
                LawType.Action => character.GetSpeech().GetActionIndex(),
                LawType.Amount => character.GetSpeech().GetAmountIndex(),
                LawType.Keyword => character.GetSpeech().GetObjectIndex(),
                _ => 0,
            };

            if (attributeIndex == lawList[i].GetIndex())
                return true;
        }

        // If no overlap, person is not guilty
        return false;
    }

    public List<Law> GetLawList() { return lawList; }
}
