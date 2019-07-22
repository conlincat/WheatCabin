﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnMouseOver : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

    public bool isMouseOver=false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    private void Update()
    {
        print(isMouseOver);
    }
}
