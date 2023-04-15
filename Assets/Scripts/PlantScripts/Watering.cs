using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Watering : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private RectTransform _transform;
    [SerializeField] private Vector2 initialPosition;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image image;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private ParticleSystem waterParticle;
    [SerializeField] private Sprite wateringCanSprite;
    [SerializeField] private Sprite wateringCanActiveSprite;
    

    void Start()
    {
        _transform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        image = GetComponent<Image>();
        waterParticle = GetComponentInChildren<ParticleSystem>();
        image.sprite = wateringCanSprite;
        waterParticle.Stop();
        initialPosition = _transform.anchoredPosition;
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.sprite = wateringCanActiveSprite;
        waterParticle.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.sprite = wateringCanSprite;
        waterParticle.Stop();
        _transform.anchoredPosition = initialPosition;
    }
    
}
