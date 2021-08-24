using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InputClick : MonoBehaviour, IPointerClickHandler
{

    public GameObject GM;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GM.GetComponent<DialogSys>().dialog_txt.text = GM.GetComponent<DialogSys>().d_str;
        }
    }


}

