using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtpnHoverScript : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(0, 0));
    }
}
