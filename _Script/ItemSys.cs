using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSys : MonoBehaviour
{
    public int itemNum_i, itemR_i, itemL_i, slot_i, itemList_i;
    public Sprite[] item_spr, handItem_spr;
    public GameObject[] slot_obj;
    public GameObject[] slotHand_obj, hand_obj;
    public int[] bagSlot_i;
    public GameObject ItemMenu_obj;
    public GameObject ItemDetail_obj;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // 마우스 입력을 받았 을 때
        if (Input.GetMouseButtonUp(0))
        {
            ItemMenu_obj.SetActive(false);
        }
    }


    public void PickItem(int num_i)
    {
        Debug.Log(num_i);
       SetHands(bagSlot_i[num_i]);
        slot_i = num_i;
    }

    public void PickItemBtn()
    {
        int pick=PlayerPrefs.GetInt("setitem", 0);
        slot_i = pick;
        SetHands(bagSlot_i[pick]);
    }

    public void SetItem()
    {

    }
    public void GetItem(int num)
    {
        if (itemList_i < 4)
        {
            bagSlot_i[itemList_i] = num;
            slot_i=itemList_i;
            SetItemImage();
            itemList_i++;
            SetHands(num);
        }
    }

    void SetHands(int num)
    {
        if (itemL_i == 0)
        {
            itemL_i = num;
            SetItemcheck(itemL_i);
            hand_obj[0].GetComponent<Image>().sprite = handItem_spr[num];
            hand_obj[0].SetActive(true);
        }
        else if (itemR_i == 0)
        {
            itemR_i = num;
            SetItemcheck(itemR_i);
            hand_obj[1].GetComponent<Image>().sprite = handItem_spr[num];
            hand_obj[1].SetActive(true);
        }
    }

    public void ShowDetail()
    {
        ItemDetail_obj.SetActive(true);
    }
    public void CloseDetail()
    {
        ItemDetail_obj.SetActive(false);
    }

    public void SetRightItem()
    {
        itemR_i = itemNum_i;
    }
    public void SetLeftItem()
    {
        itemL_i = itemNum_i;
    }

    public void OffItem()
    {
        if (itemNum_i == itemR_i)
        {
            itemR_i = 0;
        }
        if (itemNum_i == itemL_i)
        {
            itemL_i = 0;
        }
    }


    public void SetItemImage()
    {
        //slot_obj[slot_i].GetComponent<Image>().sprite = item_spr[bagSlot_i[slot_i]];
        //slot_obj[slot_i].SetActive(true);
    }

    /// <summary>
    /// 아이템을 손에 들고 있는지 체크하고 표시
    /// </summary>
    /// <param name="ck"></param>
    public void SetItemcheck(int ck)
    {
        if (ck == 0)
        {
            slotHand_obj[slot_i].SetActive(false);
        }
        else
        {
            slotHand_obj[slot_i].SetActive(true);
        }
    }

    public void ThrowItem()
    {
        slot_obj[slot_i].SetActive(false);
        slotHand_obj[slot_i].SetActive(false);
    }
}
