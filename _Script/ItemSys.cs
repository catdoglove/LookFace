using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSys : MonoBehaviour
{
    public int itemNum_i, itemR_i, itemL_i, slot_i, itemList_i;
    public Sprite[] item_spr, handItem_spr, ItemDetail_spr;
    public GameObject[] slot_obj;
    public GameObject[] slotHand_obj, hand_obj;
    public int[] bagSlot_i;
    public GameObject ItemMenu_obj;
    public GameObject ItemDetail_obj, ItemDetailBtn_obj, ItemDetailImg_obj;
    public GameObject GM, GM2;
    public string[] ItemName_str;
    public GameObject bag_obj, itemWindow_obj, bagZipper_obj;
    public Text itemName_txt;

    public GameObject closeZipper_obj,openZipper_obj, zipperBefore_obj, closeItemWBtn_obj, openZipperW_obj;

    public float bag_x_f, zipper_y_f, bag_y_f;
    public int bagOpen_i, zipperOpen_i, bagZipper_i, bagZipperExit_i, bagOpenCk_i, bagZipperCk_i;
    public Sprite[] zipper_spr;

    int dt_i;

    // Start is called before the first frame update
    void Start()
    {
        ItemName_str[0]= "열쇠";
        ItemName_str[1] = "나무 열쇠";
        ItemName_str[2] = "드라이버";
        ItemName_str[3] = "건전지";
        ItemName_str[4] = "투명한 캡슐";
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
            if (bagZipper_i == 0 && GM2.GetComponent<MouseOver>().bagMOver_i == 1)
            {
                bagZipper_i = 1;
                StopCoroutine("MouseOverBag");
                StartCoroutine("MouseOverBag");
            }
            else if (bagZipperExit_i == 0 && GM2.GetComponent<MouseOver>().bagMOver_i == 2)
            {
            if (bagOpenCk_i == 0)
            {
                bagZipperExit_i = 1;
                GM2.GetComponent<MouseOver>().bagMOver_i = 0;
                StopCoroutine("MouseExitBag");
                StartCoroutine("MouseExitBag");
            }
            }

        if (bagZipperCk_i==0&& bagOpenCk_i==1)
        {
            bagOpen_i = 1;
            StopCoroutine("BackBagItem");
            StartCoroutine("BackBagItem");
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
        itemName_txt.text= ItemName_str[num];
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
        //itemWindow_obj.SetActive(true);

        if (zipperOpen_i == 0)
        {
            zipperOpen_i = 1;
            StartCoroutine("OpenZipper");
        }
    }
    public void CloseBag()
    {
        //itemWindow_obj.SetActive(false);

        if (bagOpen_i == 0)
        {
            bagOpen_i = 1;
            StartCoroutine("BackBagItem");
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
            itemName_txt.text = ItemName_str[num];
        }
        else if (itemR_i == 0)
        {
            itemR_i = num;
            SetItemcheck(itemR_i);
            hand_obj[1].GetComponent<Image>().sprite = handItem_spr[num];
            hand_obj[1].SetActive(true);
            itemName_txt.text = ItemName_str[num];
        }
    }

    void offHands(int num)
    {
        if (num== itemL_i)
        {
            itemL_i = 0;
            hand_obj[0].SetActive(false);
            SetItemcheck(itemL_i);
            itemName_txt.text = "";
        }
        else if(num == itemR_i)
        {
            itemR_i = 0;
            hand_obj[1].SetActive(false);
            SetItemcheck(itemR_i);
            itemName_txt.text = "";
        }
    }

    /// <summary>
    /// 살펴보기
    /// </summary>
    public void ShowDetail()
    {
        dt_i = 0;
        if (GM.GetComponent<ItemSys>().bagSlot_i[PlayerPrefs.GetInt("setitem", 0)] == 5)
        {
            ItemDetailImg_obj.GetComponent<Image>().sprite = ItemDetail_spr[0];
            ItemDetail_obj.SetActive(true);
            itemName_txt.text = "불 꺼진 리모컨";
        }

        if (GM.GetComponent<ItemSys>().bagSlot_i[PlayerPrefs.GetInt("setitem", 0)] == 6)
        {
            ItemDetail_obj.SetActive(true);
            ItemDetailImg_obj.GetComponent<Image>().sprite = ItemDetail_spr[2];
            itemName_txt.text = "불 켜진 리모컨";
        }
    }
    public void CloseDetail()
    {
        ItemDetailImg_obj.GetComponent<Image>().sprite = ItemDetail_spr[0];
        ItemDetail_obj.SetActive(false);
    }

    public void DetailTurn()
    {
        if (dt_i == 0)
        {
            ItemDetailImg_obj.GetComponent<Image>().sprite = ItemDetail_spr[1];
                dt_i = 1;
        }
        else
        {
            ItemDetailImg_obj.GetComponent<Image>().sprite = ItemDetail_spr[0];
            if (GM.GetComponent<ItemSys>().bagSlot_i[PlayerPrefs.GetInt("setitem", 0)] == 6)
            {
                ItemDetailImg_obj.GetComponent<Image>().sprite = ItemDetail_spr[2];
            }
            dt_i = 0;
        }
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


    /// <summary>
    /// 마우스 오버하면 지퍼가 뒤로 들어갔다가 가방과 함께나온다
    /// </summary>
    /// <returns></returns>
    IEnumerator BounceBag()
    {
        while (bagOpen_i == 1)
        {
            if (bag_x_f <= -15f)
            {
                //moveX2 = 5.2f;
            }
            bag_x_f = bag_x_f - 0.05f;
            if (bag_x_f <= -5.4)
            {
                bag_x_f = -15.4f;
            }

            bag_obj.transform.position = new Vector3(bag_x_f, bag_obj.transform.position.y, bag_obj.transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// 지퍼를 연다
    /// </summary>
    /// <returns></returns>
    IEnumerator OpenZipper()
    {
        
        StopCoroutine("CloseZipper");
        RectTransform rectTran = closeZipper_obj.GetComponent<RectTransform>();
        Vector3 position = zipperBefore_obj.transform.localPosition;
        while (zipperOpen_i == 1)
        {
            if (rectTran.sizeDelta.x <= 322.5343f)
            {
                zipperOpen_i = 0;
                zipperBefore_obj.GetComponent<Image>().sprite = zipper_spr[2];
            }
            
            if (rectTran.sizeDelta.x <= 700f&& rectTran.sizeDelta.x > 325f)
            {
                zipperBefore_obj.GetComponent<Image>().sprite = zipper_spr[1];
            }
            if (rectTran.sizeDelta.x < 450f)
            {
                zipperBefore_obj.GetComponent<Image>().sprite = zipper_spr[2];
            }
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectTran.sizeDelta.x - 9.5f);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTran.sizeDelta.y - 15.14f);

            if (position.y < 199.97f)
            {
                position.y = position.y + 7.58f;
                zipperBefore_obj.transform.localPosition = position;
            }

            yield return new WaitForSeconds(0.001f);
        }
        bagOpen_i = 1;
        StartCoroutine("ShowBagItem");
    }


    /// <summary>
    /// 지퍼를 닫는다
    /// </summary>
    /// <returns></returns>
    IEnumerator CloseZipper()
    {
        StopCoroutine("OpenZipper");
        RectTransform rectTran = closeZipper_obj.GetComponent<RectTransform>();
        Vector3 position = zipperBefore_obj.transform.localPosition;
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 472.8093f);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 753.6f);
        
        while (zipperOpen_i == 1)
        {
            if (rectTran.sizeDelta.x >= 949.9f)
            {
                zipperOpen_i = 0;
                zipperBefore_obj.GetComponent<Image>().sprite = zipper_spr[0];
            }

            if (rectTran.sizeDelta.x <= 700f && rectTran.sizeDelta.x > 450f)
            {
                zipperBefore_obj.GetComponent<Image>().sprite = zipper_spr[1];
            }
            if (rectTran.sizeDelta.x < 450f)
            {
                zipperBefore_obj.GetComponent<Image>().sprite = zipper_spr[2];
            }
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectTran.sizeDelta.x + 9.5f);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTran.sizeDelta.y + 15.14f);

            if (position.y > -179.21f)
            {
                position.y = position.y - 7.58f;
                zipperBefore_obj.transform.localPosition = position;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    /// <summary>
    /// 아이템창이 나온다.
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowBagItem()
    {
        StopCoroutine("BackBagItem");
        bagOpenCk_i = 1;
        itemWindow_obj.SetActive(true);
        openZipperW_obj.SetActive(true);
        closeItemWBtn_obj.SetActive(true);
        Vector3 position = itemWindow_obj.transform.localPosition;
        while (bagOpen_i == 1)
        {
            //-212.3
                //139.4
            if (position.x < 139.4f)
            {
                position.x = position.x + 6.79f;
                itemWindow_obj.transform.localPosition = position;
            }
            else
            {
                bagOpen_i = 0;
            }
            print(Time.time);
            yield return new WaitForSeconds(0.001f);
            print(Time.time);
        }
        //closeItemWBtn_obj.SetActive(true);
        
    }

    /// <summary>
    /// 아이템창이 들어간다
    /// </summary>
    /// <returns></returns>
    IEnumerator BackBagItem()
    {

        StopCoroutine("ShowBagItem");
        bagOpenCk_i = 0;
        itemWindow_obj.SetActive(true);
        openZipperW_obj.SetActive(true);
        Vector3 position = itemWindow_obj.transform.localPosition;
        while (bagOpen_i == 1)
        {
            if (position.x > -212.3f)
            {
                position.x = position.x - 6.79f;
                itemWindow_obj.transform.localPosition = position;
            }
            else
            {
                bagOpen_i = 0;
            }
            yield return new WaitForSeconds(0.001f);
        }
        closeItemWBtn_obj.SetActive(false);
        itemWindow_obj.SetActive(false);
        openZipperW_obj.SetActive(false);
        zipperOpen_i = 1;
        StartCoroutine("CloseZipper");
    }



    /// <summary>
    /// 화면왼쪽에 마우스 오버하면 가방이 들어갔다가 나온다.
    /// </summary>
    /// <returns></returns>
    IEnumerator MouseOverBag()
    {
        bagZipperCk_i = 1;
        bagZipperExit_i = 0;
        StopCoroutine("MouseExitBag");
        Vector3 position = bag_obj.transform.localPosition;
        Vector3 position2 = bagZipper_obj.transform.localPosition;
        while (bagZipper_i == 1)
        {
            //-917
            //-828.38
            //-830.82
            //-100.07
            //-46.52005
            //-116.2


            if (position2.x > -100.07f)
            {
                position2.x = position2.x - 3.79f;
                bagZipper_obj.transform.localPosition = position2;
            }
            else if (position.x < -20.82)
            {
                if (position2.x != -100.07f)
                {
                    position2.x = -100.07f;
                    bagZipper_obj.transform.localPosition = position2;
                }
                position.x = position.x + 2.79f;
                bag_obj.transform.localPosition = position;

            }
            else
            {
                bagZipper_i = 0;
                position.x = -20.82f;
                bag_obj.transform.localPosition = position;
            }
            yield return new WaitForSeconds(0.001f);
        }
        //closeItemWBtn_obj.SetActive(true);

    }


    IEnumerator MouseExitBag()
    {
        bagZipperCk_i = 0;
        bagZipper_i = 0;
        StopCoroutine("MouseOverBag");
        Vector3 position = bag_obj.transform.localPosition;
        Vector3 position2 = bagZipper_obj.transform.localPosition;
        while (bagZipperExit_i == 1)
        {
            //-917
            //-828.38
            //-830.82
            //-100.07
            //-46.52005
            //-116.2


            if (position.x > -116.2)
            {
                position.x = position.x - 3.79f;
                bag_obj.transform.localPosition = position;
            }
            else if (position2.x < -46.52f)
            {
                if (position.x != -116.2f)
                {
                    position.x = -116.2f;
                    bag_obj.transform.localPosition = position;
                }

                position2.x = position2.x + 2.79f;
                bagZipper_obj.transform.localPosition = position2;
            }
            else
            {

                position2.x = -46.52f;
                bagZipper_obj.transform.localPosition = position2;
                bagZipperExit_i = 0;
            }
            
            yield return new WaitForSeconds(0.001f);
        }
        if (bagOpenCk_i == 1)
        {
            bagOpen_i = 1;
            StopCoroutine("BackBagItem");
            StartCoroutine("BackBagItem");
        }
    }
}
