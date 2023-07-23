using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UIContext", order = 1)]
public class UIContext : ScriptableObject
{
    [Header("Player Options")]
    [SerializeField] public Color[] hairColorOptions;
    [SerializeField] public Color[] shirtColorOptions;
    [SerializeField] public Texture[] accessoriesOptions;
    [SerializeField] public Color[] eyeColorOptions;
    [Space]
    [SerializeField] public string[] hairColorTexts;
    [SerializeField] public string[] shirtColorTexts;
    [SerializeField] public string[] accessoriesTexts;
    [SerializeField] public string[] eyeColorTexts;
    [Header("Speech Options")]
    [SerializeField] public string[] introductionsOptions;
    [SerializeField] public string[] actionsOptions;
    [SerializeField] public string[] amountOptions;
    [SerializeField] public string[] objectsOptions;


    
    #region Getters
    public int ShirtMaxCount => shirtColorOptions.Length;
    public int HairMaxCount => hairColorOptions.Length;
    public int AccessoryMaxCount => accessoriesOptions.Length;
    public int EyeMaxCount => shirtColorOptions.Length;
    public int IntroMaxCount => introductionsOptions.Length;
    public int ActionMaxCount => actionsOptions.Length;
    public int AmountMaxCount => amountOptions.Length;
    public int ObjectMaxCount => objectsOptions.Length;

    public string GetAttributeText(int index, LawType type)
    {
        string text = type switch
        {
            LawType.Shirt => hairColorTexts[index],
            LawType.Hair => hairColorTexts[index],
            LawType.Accessory => accessoriesTexts[index],
            LawType.Eye => eyeColorTexts[index],
            LawType.Action => actionsOptions[index],
            LawType.Amount => amountOptions[index],
            LawType.Keyword => objectsOptions[index],
            _ => "Law_Object",
        };

        return text;
    }
    #endregion
}
