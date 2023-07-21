using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private UIContext uiContext;
    [SerializeField] private int hairCount, shirtCount, accessoryCount, eyeCount, introCount, actionCount, amountCount, objectCount;

    private Person currentPerson;
    // Start is called before the first frame update
    void Start()
    {
        SetMaxCounts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneratePerson()
    {
        int hair = Random.Range(0, hairCount);
        int shirt = Random.Range(0, shirtCount);
        int accessory = Random.Range(0, accessoryCount);
        int eye = Random.Range(0, eyeCount);
        Speech speech = GenerateSpeech();

        Person newPerson = new Person(hair, shirt, accessory, eye, speech);
        currentPerson = newPerson;

        uiContext.SetContext(newPerson);
    }

    Speech GenerateSpeech()
    {
        int introSpeech = Random.Range(0, introCount);
        int actionSpeech = Random.Range(0, actionCount);
        int amountSpeech = Random.Range(0, amountCount);
        int objectSpeech = Random.Range(0, objectCount);

        Speech newSpeech = new Speech(introSpeech, actionSpeech, amountSpeech, objectSpeech);
        return newSpeech;
    }

    void SetMaxCounts()
    {
        hairCount = uiContext.HairMaxCount;
        shirtCount = uiContext.ShirtMaxCount;
        accessoryCount = uiContext.AccessoryMaxCount;
        eyeCount = uiContext.EyeMaxCount;
        introCount = uiContext.IntroMaxCount;
        actionCount = uiContext.ActionMaxCount;
        amountCount = uiContext.AmountMaxCount;
        objectCount = uiContext.ObjectMaxCount;
    }
}
