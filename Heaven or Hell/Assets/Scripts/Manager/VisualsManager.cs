using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualsManager : MonoBehaviour
{
    [SerializeField] UIContext uiContext;

    private Color chosenHairColor, chosenShirtColor, chosenEyeColor, chosenSkinColor;
    private Texture chosenAccessory, chosenHairStyle;
    private string chosenIntroduction, chosenAction, chosenAmount, chosenObject;

    [SerializeField] private RawImage UIHair, UIShirt, UIAccessory, UIEye, UISkin;
    [SerializeField] private TMP_Text speechText;

    string CreateSentence()
    {
        return $"{chosenIntroduction} {chosenAction} {chosenAmount} {chosenObject}.";
    }

    public void SetContext(Person createdPerson)
    {
        SetVariablesPlayer(createdPerson);

        SetUI();
    }

    void SetVariablesPlayer(Person createdPerson)
    {
        chosenHairColor = uiContext.hairColorOptions[createdPerson.GetHairIndex()];
        chosenHairStyle = uiContext.hairStyleOptions[createdPerson.GetHairStyleIndex()];
        chosenShirtColor = uiContext.shirtColorOptions[createdPerson.GetShirtIndex()];
        chosenAccessory = uiContext.accessoriesOptions[createdPerson.GetAccessoryIndex()];
        chosenEyeColor = uiContext.eyeColorOptions[createdPerson.GetEyeIndex()];
        chosenSkinColor = uiContext.skinColorOptions[createdPerson.GetSkinIndex()];
        SetVariablesSpeech(createdPerson.GetSpeech());
    }

    void SetVariablesSpeech(Speech speech)
    {
        chosenIntroduction = uiContext.introductionsOptions[speech.GetIntroductionIndex()];
        chosenAction = uiContext.actionsOptions[speech.GetActionIndex()];
        chosenAmount = uiContext.amountOptions[speech.GetAmountIndex()];
        chosenObject = uiContext.objectsOptions[speech.GetObjectIndex()];
    }

    void SetUI()
    {
        UIHair.color = chosenHairColor;
        UIHair.texture = chosenHairStyle;
        UIShirt.color = chosenShirtColor;
        UIAccessory.texture = chosenAccessory;
        UIEye.color = chosenEyeColor;
        UISkin.color = chosenSkinColor;

        string speechSentence = CreateSentence();
        speechText.SetText(speechSentence);
    }
}
