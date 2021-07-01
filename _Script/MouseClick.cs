using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MouseClick : MonoBehaviour, IPointerClickHandler
{
    public string str;
    public int sub_i;
    public GameObject GM;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Mouse Click Button : Left");
            str = this.name;
            sub_i=int.Parse(str.Substring(2, 1));
            GM.GetComponent<ItemSys>().PickItem(sub_i);
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("Mouse Click Button : Middle");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Mouse Click Button : Right");
            str = this.name;
            sub_i = int.Parse(str.Substring(2, 1));
        }
        Debug.Log("Mouse Position : " + eventData.position); Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }
}


