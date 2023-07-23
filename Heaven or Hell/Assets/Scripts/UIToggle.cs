using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    bool hasBeenActivated;
    [SerializeField] private GameObject toggledGameObject;
    [SerializeField] Image feedbackBorder;
    bool hasSetBorder = false;

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
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(1, 0));

        if (!hasSetBorder)
        {
            feedbackBorder.enabled = false;
        }
    }

    public void ShowBook()
    {
        hasBeenActivated = true;
        toggledGameObject.SetActive(hasBeenActivated);
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(1, 0));
    }

}
