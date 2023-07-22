using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIContext : MonoBehaviour
{
    [Header("Player Options")]
    [SerializeField] private Color[] hairColorOptions;
    [SerializeField] private Color[] shirtColorOptions;
    [SerializeField] private Texture[] accessoriesOptions;
    [SerializeField] private Color[] eyeColorOptions;
    [Space]
    [SerializeField] string[] hairColorTexts;
    [SerializeField] string[] shirtColorTexts;
    [SerializeField] string[] accessoriesTexts;
    [SerializeField] string[] eyeColorTexts;
    [Header("Speech Options")]
    [SerializeField] private string[] introductionsOptions;
    [SerializeField] private string[] actionsOptions;
    [SerializeField] private string[] amountOptions;
    [SerializeField] private string[] objectsOptions;


    private Color chosenHairColor, chosenShirtColor, chosenEyeColor;
    private Texture chosenAccessory;
    private string chosenIntroduction, chosenAction, chosenAmount, chosenObject;

    [SerializeField] private RawImage UIHair, UIShirt, UIAccessory, UIEye;
    [SerializeField] private TMP_Text speechText;



    public void SetContext(Person createdPerson)
    {
        SetVariablesPlayer(createdPerson);

        SetUI();
    }

    void SetVariablesPlayer(Person createdPerson)
    {
        chosenHairColor = hairColorOptions[createdPerson.GetHairIndex()];
        chosenShirtColor = shirtColorOptions[createdPerson.GetShirtIndex()];
        chosenAccessory = accessoriesOptions[createdPerson.GetAccessoryIndex()];
        chosenEyeColor = eyeColorOptions[createdPerson.GetEyeIndex()];
        SetVariablesSpeech(createdPerson.GetSpeech());
    }

    void SetVariablesSpeech(Speech speech)
    {
        chosenIntroduction = introductionsOptions[speech.GetIntroductionIndex()];
        chosenAction = actionsOptions[speech.GetActionIndex()];
        chosenAmount = amountOptions[speech.GetAmountIndex()];
        chosenObject = objectsOptions[speech.GetObjectIndex()];
    }

    void SetUI()
    {
        UIHair.color = chosenHairColor;
        UIShirt.color = chosenShirtColor;
        UIAccessory.texture = chosenAccessory;
        UIEye.color = chosenEyeColor;

        string speechSentence = CreateSentence();
        speechText.SetText(speechSentence);
    }

    string CreateSentence()
    {
        return $"{chosenIntroduction} {chosenAction} {chosenAmount} {chosenObject}.";
    }
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
