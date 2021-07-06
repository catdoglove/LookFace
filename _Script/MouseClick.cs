using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MouseClick : MonoBehaviour, IPointerClickHandler
{
    public string str;
    public int sub_i;
    public GameObject GM;
    public GameObject menu_obj;
    public Vector2 wldObjectPos;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Mouse Click Button : Left");
            str = this.name;
            sub_i=int.Parse(str.Substring(2, 1));
            GM.GetComponent<ItemSys>().ItemnameBtn(sub_i);
            menu_obj.SetActive(false);
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("Mouse Click Button : Middle");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            menu_obj.SetActive(true);
            Debug.Log("Mouse Click Button : Right");
            str = this.name;
            sub_i = int.Parse(str.Substring(2, 1));
            PlayerPrefs.SetInt("setitem",sub_i);

            wldObjectPos = Camera.main.ScreenToWorldPoint(new Vector2(eventData.position.x, eventData.position.y));
            menu_obj.transform.position = new Vector3(wldObjectPos.x, wldObjectPos.y, 0f);
        }
        Debug.Log("Mouse Position : " + eventData.position); Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }


}


