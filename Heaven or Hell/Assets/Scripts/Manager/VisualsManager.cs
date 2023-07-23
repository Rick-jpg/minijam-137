using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualsManager : MonoBehaviour
{
    UIContext uiContext;

    private Color chosenHairColor, chosenShirtColor, chosenEyeColor;
    private Texture chosenAccessory;
    private string chosenIntroduction, chosenAction, chosenAmount, chosenObject;

    [SerializeField] private RawImage UIHair, UIShirt, UIAccessory, UIEye;
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
        chosenShirtColor = uiContext.shirtColorOptions[createdPerson.GetShirtIndex()];
        chosenAccessory = uiContext.accessoriesOptions[createdPerson.GetAccessoryIndex()];
        chosenEyeColor = uiContext.eyeColorOptions[createdPerson.GetEyeIndex()];
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
        UIShirt.color = chosenShirtColor;
        UIAccessory.texture = chosenAccessory;
        UIEye.color = chosenEyeColor;

        string speechSentence = CreateSentence();
        speechText.SetText(speechSentence);
    }
}
