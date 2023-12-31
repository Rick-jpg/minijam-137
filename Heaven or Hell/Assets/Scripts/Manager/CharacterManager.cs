using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VisualsManager))]
public class CharacterManager : MonoBehaviour
{
    VisualsManager visuals;

    [SerializeField] private UIContext uiContext;
    [SerializeField] private int hairCount, hairStyleCount, shirtCount, accessoryCount, skinCount, eyeCount, introCount, actionCount, amountCount, objectCount;
    [SerializeField] Animator animator;

    private Person currentPerson;
    public Person CurrentPerson { get { return currentPerson; } private set { } }
    private void OnEnable()
    {
        visuals = GetComponent<VisualsManager>();
    }

    public void GeneratePerson()
    {
        int hair = Random.Range(0, hairCount);
        int style = Random.Range(0, hairStyleCount);
        int shirt = Random.Range(0, shirtCount);
        int accessory = Random.Range(0, accessoryCount);
        int eye = Random.Range(0, eyeCount);
        int skin = Random.Range(0, skinCount);
        Speech speech = GenerateSpeech();

        Person newPerson = new Person(hair, shirt, accessory, eye, speech, skin, style);
        currentPerson = newPerson;

        // TODO: give this script reference to lawmanager somehow (Overarching manager?)
        newPerson.SetIsGuilty(GameplayManager.Instance.CheckIfPersonIsGuilty(currentPerson));
        Debug.Log(newPerson.GetGuilty());

        visuals.SetContext(newPerson);
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

    public void SetMaxCounts()
    {
        hairCount = uiContext.HairMaxCount;
        hairStyleCount = uiContext.HairStyleMaxCount;
        shirtCount = uiContext.ShirtMaxCount;
        accessoryCount = uiContext.AccessoryMaxCount;
        eyeCount = uiContext.EyeMaxCount;
        skinCount = uiContext.SkinMaxCount;
        introCount = uiContext.IntroMaxCount;
        actionCount = uiContext.ActionMaxCount;
        amountCount = uiContext.AmountMaxCount;
        objectCount = uiContext.ObjectMaxCount;
    }

    [ContextMenu("Go To Heaven")]
    public void GoToHeaven()
    {
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(1, 3));
        animator.Play("ExitHeaven");
    }
    [ContextMenu("Go To Hell")]
    public void GoToHell()
    {
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(1, 2));
        animator.Play("ExitHell");
    }
}
