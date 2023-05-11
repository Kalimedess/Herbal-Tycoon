using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    Image Target;
    public Color32 BasicColor;
    public Color32 OnEnterColor;


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Target.color = OnEnterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Target.color = BasicColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    void Start()
    {
        Target = GetComponent<Image>();
        Target.color = BasicColor;
    }
}

