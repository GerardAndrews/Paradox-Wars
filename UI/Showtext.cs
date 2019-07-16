using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Showtext : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text unitInfoText;
	
    public void OnPointerEnter(PointerEventData data)
    {
        unitInfoText.gameObject.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
    }

    public void OnPointerExit(PointerEventData data)
    {
        unitInfoText.gameObject.SetActive(false);
        Debug.Log("Mouse is not over GameObject.");
    }
}
