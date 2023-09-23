using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIStartDriftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action<bool> OnStartDriftButtonTaped; 

    public void OnPointerDown(PointerEventData eventData)
    {
        OnStartDriftButtonTaped?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnStartDriftButtonTaped?.Invoke(false);
    }
}
