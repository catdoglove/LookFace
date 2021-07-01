using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSys : MonoBehaviour
{
    public int itemNum_i, itemR_i, itemL_i, slot_i;
    public Sprite[] item_spr;
    public GameObject[] slot_obj;
    public GameObject[] slotHand_obj;
    public int[] bagSlot_i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PickItem(int num_i)
    {

        Debug.Log(num_i);
        slotHand_obj[0].GetComponent<Image>().sprite = item_spr[num_i];
        slotHand_obj[0].SetActive(true);
    }

    public void SetItem()
    {

    }
    public void GetItem()
    {

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

        slot_obj[slot_i].GetComponent<Image>().sprite = item_spr[bagSlot_i[slot_i]];

    }

    //아이템을 손에 들고 있는지 체크하고 표시
    public void SetItemcheck()
    {
        if (itemR_i == 0 || itemL_i == 0)
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
