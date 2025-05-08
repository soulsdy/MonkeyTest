using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonFire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public event Action OnFireSelect;
    public event Action OnFireDeselect;




    public void OnPointerDown(PointerEventData eventData)
    {
        OnFireSelect?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnFireDeselect?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnFireDeselect?.Invoke();
    }



}
