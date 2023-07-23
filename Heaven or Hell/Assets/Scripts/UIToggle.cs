using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIToggle : MonoBehaviour
{
    bool hasBeenActivated;
    [SerializeField] private GameObject toggledGameObject;

    private void Start()
    {
        toggledGameObject.SetActive(hasBeenActivated);
    }
    public void ToggleActivity()
    {
        hasBeenActivated = !hasBeenActivated;
        toggledGameObject.SetActive(hasBeenActivated);
    }

}
