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
    public GameObject menu_obj, menuSub_obj;
    public Sprite[] menu_spr;
    public Vector2 wldObjectPos;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            str = this.name;
            sub_i=int.Parse(str.Substring(2, 1));
            GM.GetComponent<ItemSys>().ItemnameBtn(sub_i);
            menu_obj.SetActive(false);
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            GM.GetComponent<ItemSys>().ItemDetailBtn_obj.GetComponent<Button>().interactable = false;
            menu_obj.SetActive(true);
            str = this.name;
            sub_i = int.Parse(str.Substring(2, 1));
            PlayerPrefs.SetInt("setitem",sub_i);
            if (GM.GetComponent<ItemSys>().bagSlot_i[sub_i] == 5|| GM.GetComponent<ItemSys>().bagSlot_i[sub_i] == 6)
            {
                GM.GetComponent<ItemSys>().ItemDetailBtn_obj.GetComponent<Button>().interactable = true;
            }
            else
            {
                GM.GetComponent<ItemSys>().ItemDetailBtn_obj.GetComponent<Button>().interactable = false;
            }

            
            if (GM.GetComponent<ItemSys>().slotHand_obj[sub_i].activeSelf == false)
            {
                menuSub_obj.GetComponent<Image>().sprite = menu_spr[1];
            }
            else
            {
                menuSub_obj.GetComponent<Image>().sprite = menu_spr[0];
            }

            wldObjectPos = Camera.main.ScreenToWorldPoint(new Vector2(eventData.position.x, eventData.position.y));
            menu_obj.transform.position = new Vector3(wldObjectPos.x, wldObjectPos.y, 0f);
        }
        Debug.Log("Mouse Position : " + eventData.position); Debug.Log("Mouse Click Count : " + eventData.clickCount);
    }


}


