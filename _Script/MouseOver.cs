using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int bagMOver_i=0;
    public void OnPointerEnter(PointerEventData eventData)
    {
        bagMOver_i = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        bagMOver_i = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
