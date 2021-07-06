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
    public GameObject ItemDetail_obj, ItemDetailBtn_obj;
    public GameObject GM;
    public string[] ItemName_str;
    public GameObject bag_obj, itemWindow_obj;
    public Text itemName_txt;

    public GameObject closeZipper_obj,openZipper_obj;

    // Start is called before the first frame update
    void Start()
    {
        ItemName_str[0]= "열쇠";
        ItemName_str[1] = "나무 열쇠";
        ItemName_str[2] = "드라이버";
        ItemName_str[3] = "건전지";
        ItemName_str[4] = "캡슐";
        ItemName_str[5] = "불 꺼진 리모컨";
        ItemName_str[6] = "불 켜진 리모컨";
        ItemName_str[7] = "";
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

        if (slotHand_obj[num_i].activeSelf == false)
        {
            slot_i = num_i;
            SetHands(bagSlot_i[num_i]);
        }
        else
        {
            slot_i = num_i;
            offHands(bagSlot_i[num_i]);
        }
    }

    /// <summary>
    /// 집어들기
    /// </summary>
    public void PickItemBtn()
    {
        int pick=PlayerPrefs.GetInt("setitem", 0);
        if (slotHand_obj[pick].activeSelf ==false)
        {
            slot_i = pick;
            SetHands(bagSlot_i[pick]);
        }
        else
        {
            slot_i = pick;
            offHands(bagSlot_i[pick]);
        }
    }

    /// <summary>
    /// 아이템 이름 확인
    /// </summary>
    /// <param name="num_i"></param>
    public void ItemnameBtn(int num_i)
    {
        itemName_txt.text = ItemName_str[bagSlot_i[num_i]];
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
    public void ShowBag()
    {
        bag_obj.SetActive(true);
    }

    public void OpenBag()
    {
        itemWindow_obj.SetActive(true);
    }
    public void CloseBag()
    {
        itemWindow_obj.SetActive(false);
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

    void offHands(int num)
    {
        if (num== itemL_i)
        {
            itemL_i = 0;
            hand_obj[0].SetActive(false);
            SetItemcheck(itemL_i);
        }
        else if(num == itemR_i)
        {
            itemR_i = 0;
            hand_obj[1].SetActive(false);
            SetItemcheck(itemR_i);
        }
    }

    /// <summary>
    /// 살펴보기
    /// </summary>
    public void ShowDetail()
    {
        if (PlayerPrefs.GetInt("setitem", 0) == 5)
        {

            ItemDetail_obj.SetActive(true);
        }
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
