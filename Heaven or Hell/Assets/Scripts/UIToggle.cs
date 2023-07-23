using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIToggle : MonoBehaviour
{
    bool hasBeenActivated;
    [SerializeField] private GameObject toggledGameObject;

    private void OnEnable()
    {
        GameplayManager.OnShowLawCreated += ShowBook;
    }

    private void OnDisable()
    {
        GameplayManager.OnShowLawCreated -= ShowBook;
    }

    private void Start()
    {
        toggledGameObject.SetActive(hasBeenActivated);
    }
    public void ToggleActivity()
    {
        hasBeenActivated = !hasBeenActivated;
        toggledGameObject.SetActive(hasBeenActivated);
    }

    public void ShowBook()
    {
        hasBeenActivated = true;
        toggledGameObject.SetActive(hasBeenActivated);
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(1, 0));
    }

}
