using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;
using UnityEngine.Events;
using System;
using UnityEngine.EventSystems;


public class Event : MonoBehaviour
{
    //인덱스번호
    public static int direction = 1;
    public static int indexMove = 0;
    public static int indexAct = 0;

    // 방향버튼
    public GameObject arrowU_obj, arrowD_obj, arrowR_obj, arrowL_obj;
    //아이템
    public int key;
    public Sprite key_spr;

    //변수
    public int where_i, switchOn_i, findKey_i, doorOpen_i, pos_i, getKey_i, findswitch_i, waterCoundt_i, findGlass_i, progress_i;
    public string[] s_str, sf_str;
    //텍스트
    public string inputF_str, inputM_str, inputA_str, inputG_str;
    //인풋필드 및 행동 버튼
    public GameObject text, move_inp, use_inp, Act_btn, back_btn, go_btn, get_inp;
    public Text t_txt, E_txt;
    public InputField use_input, move_input, get_input;
    public GameObject back;
    public Sprite[] back_spr;

    public GameObject ActBtn_obj, FeelBtn_obj;


    //캐릭터
    public int char_i;
    public GameObject char_obj, body_obj, hair_obj;
    public Sprite[] char_spr;

    //이밴트
    public GameObject eventBtn_obj, dark_obj, eventTalk_obj;


    public GameObject GM;



    Color color;

    Vector2 pos;

    public GameObject fade_obj;


    public static int stage_i=0;

    public int tuto_i, tutoAct_i;
    public GameObject tutoUp_obj, tutoDown_obj, tutoFeel_obj, tutoAct_obj, tutoMove_obj, tutoGet_obj, tutoGo_obj, tutoBack_obj, tutoDelay_obj, tutoAdd_obj, tutoResolve_obj, tutoBody_obj;
    public Sprite[] tutoBack_spr;

    //doorOpen_i 문이 열림 findKey_i 급수대에 열쇠를 봄 switchOn_i 스위치를 켬 getKey_i 열쇠 얻음 findswitch_i 스위치를 봄
    //findGlass_i 유리조각을 봄
    void Start()
    {

        if (stage_i == 0)
        {
            TutorialStart();
        }
        //버튼 투명영역 비활성화
        ActBtn_obj.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        FeelBtn_obj.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        /*
        char_i = 1;
        StopCoroutine("movechar");
        StartCoroutine("movechar");

        t_txt.text = "";
        s_str[0] = "들어왔던 곳 옆에 캐비넷들이 일렬로 서있다.";
        s_str[1] = "작은 문과 그 옆에 급수대가 놓여있다.";

        sf_str[0] = "들어왔던 곳 옆에 캐비넷들이 일렬로 서있다. 아 왼쪽에 스위치가 있군";
        sf_str[1] = "낡은 스위치가 있다.음..OFF로 되어 있네";

        sf_str[4] = "작은 문과 그 옆에 급수대가 놓여있다. 그 외에 별다른 건 없다.";
        sf_str[5] = "생각보다 깔끔해 보인다. 고장난 것 같지는 않은데..";
        sf_str[6] = "나무 문은 생각보다 작아보인다. 들어가는 것에는 문제없다.";
        */
        //색초기설정
        color = fade_obj.GetComponent<Image>().color;
    }

    public void EventSnene1()
    {
        s_str[0] = "(터벅 터벅)";
        s_str[1] = "으... 엎친 데 덮친 격이네";
        s_str[2] = "주변이 좀 어두운 데 불 키는 거 없나?";

        switch (progress_i)
        {
            case 0:
                GM.GetComponent<SoundEvt>().MoveSound();
                E_txt.text = s_str[0];
                eventTalk_obj.SetActive(true);
                break;
            case 1:
                E_txt.text = s_str[1];
                break;
            case 2:
                E_txt.text = s_str[2];
                break;
            case 3:
                eventBtn_obj.SetActive(false);
                eventTalk_obj.SetActive(false);
                E_txt.text = "";
                break;
            default:
                break;
        }
        progress_i++;
    }





    //살짝 웃음
    void item()
    {
    }
    void GetItem()
    {
    }

    void BasicFace()
    {
    }

    public void ArrowU()
    {
        fal();

        if (stage_i == 0)
        {
            TutorialUp();
        }
        else {
        direction = 1;
        indexMove = 0;
        indexAct = 0;
        if (switchOn_i == 1)
        {
        }
        pos_i = 1;
        back.GetComponent<Image>().sprite = back_spr[pos_i];
        back_btn.SetActive(false);
        where_i = 0;

        move_input.text = "";
        get_input.text = "";
        use_input.text = "";

        //arrowL_obj.SetActive(true);
        // arrowR_obj.SetActive(true);
        arrowU_obj.SetActive(false);
        arrowD_obj.SetActive(true);

        if (findswitch_i == 1)
        {
            indexAct = 1;
        }
        }
    }
    public void ArrowD()
    {
        fal();

        if (stage_i == 0)
        {
            TutorialDown();
        }
        else
        {
            direction = 2;
            indexMove = 0;
            indexAct = 0;
            if (switchOn_i == 1)
            {
            }
            pos_i = 2;
            back.GetComponent<Image>().sprite = back_spr[pos_i];
            back_btn.SetActive(false);
            where_i = 0;

            move_input.text = "";
            get_input.text = "";
            use_input.text = "";

            //arrowL_obj.SetActive(true);
            //arrowR_obj.SetActive(true);
            arrowU_obj.SetActive(true);
            arrowD_obj.SetActive(false);
        }
    }

    public void ArrowR()
    {
        fal();
        direction = 4;
        indexMove = 0;
        indexAct = 0;
        if (switchOn_i == 1)
        {
        }
        pos_i = 4;
        back.GetComponent<Image>().sprite = back_spr[pos_i];
        back_btn.SetActive(false);
        where_i = 0;

        move_input.text = "";
        get_input.text = "";
        use_input.text = "";

        //arrowL_obj.SetActive(true);
        //arrowR_obj.SetActive(false);
        arrowU_obj.SetActive(true);
        arrowD_obj.SetActive(true);
    }

    public void ArrowL()
    {
        fal();
        direction = 3;
        indexMove = 0;
        indexAct = 0;

        pos_i = 3;
        back.GetComponent<Image>().sprite = back_spr[pos_i];
        back_btn.SetActive(false);
        where_i = 0;

        move_input.text = "";
        get_input.text = "";
        use_input.text = "";

        //arrowL_obj.SetActive(false);
        //arrowR_obj.SetActive(true);
        arrowU_obj.SetActive(true);
        arrowD_obj.SetActive(true);
    }

    public void Feel()
    {
        if (stage_i == 0)
        {
            TutorialFeel();
        }
        else {
        indexAct = 1;
        fal();
        switch (direction)
        {
            case 1:
                if (indexAct == 1)
                {
                    findswitch_i = 1;
                }

                if (switchOn_i == 1)
                {
                    indexAct = 2;
                }
                break;
            case 2:
                if (indexMove == 1)
                {
                    if (findKey_i >= 1)
                    {
                        indexAct = 2;
                        findKey_i = 2;
                    }

                    if (getKey_i == 1)
                    {
                        indexAct = 3;
                    }
                    findGlass_i = 1;
                }
                break;

            default:
                break;
        }
            
        }
    }


    public void Move()
    {
        fal();
        move_inp.SetActive(true);
    }

    public void Act()
    {
        fal();
        Act_btn.SetActive(true);
    }

    public void Use()
    {
        fal();
        use_inp.SetActive(true);
    }


    void fal()
    {
        use_input.text = "";
        move_input.text = "";
        move_inp.SetActive(false);
        Act_btn.SetActive(false);
        use_inp.SetActive(false);
        get_inp.SetActive(false);
        go_btn.SetActive(false);
    }



    public void MoveOk()
    {
        if (stage_i == 0)
        {
            inputM_str = move_input.text;
            TutorialMove();
        }
        else
        {
            indexAct = 9;
            inputM_str = move_input.text;
            switch (direction)
            {
                case 1:
                    if (inputM_str.Equals("스위치") || inputM_str.Equals("낡은스위치") || inputM_str.Equals("낡은 스위치"))
                    {
                        t_txt.text = "스위치 앞에 섰다.";
                        move_input.text = "";
                        fal();

                        back_btn.SetActive(true);
                        indexMove = 1;


                        if (switchOn_i == 1)
                        {
                        }
                    }
                    else
                    {
                        //오타가 난 경우 확인할 수 있도록
                        t_txt.text = "그런 곳으로는 갈수 없어.";
                    }
                    break;
                case 2:
                    if (inputM_str.Equals("급수대"))
                    {
                        move_input.text = "";
                        fal();
                        back_btn.SetActive(true);
                        indexMove = 1;

                        if (getKey_i == 1)
                        {
                        }
                    }
                    else
                    {
                        if (inputM_str.Equals("문") || inputM_str.Equals("작은문") || inputM_str.Equals("작은 문"))
                        {
                            move_input.text = "";
                            fal();
                            back_btn.SetActive(true);
                            indexMove = 3;
                            if (doorOpen_i == 1)
                            {
                                go_btn.SetActive(true);
                            }

                            indexMove = 3;
                        }
                        else
                        {
                            //오타가 난 경우 확인할 수 있도록
                            t_txt.text = "그런 곳으로는 갈수 없어.";
                        }
                    }

                    break;

                default:
                    break;
            }
        }
    }

    public void Back()
    {
        //where_i = 0;
        indexMove = 0;
        indexAct = 0;
        back_btn.SetActive(false);
        move_inp.SetActive(false);
        Act_btn.SetActive(false);
        use_inp.SetActive(false);
        get_inp.SetActive(false);
        go_btn.SetActive(false);
        t_txt.text = "다시 제자리로 돌아왔다.";
        BasicFace();
    }

    public void ActOK()
    {

        if (stage_i == 0)
        {
            inputA_str = use_input.text;
            TutorialAct();
        }
        else
        {
            indexAct = 99;
            t_txt.text = "그런 것은 없어.";
            switch (direction)
            {
                case 1:
                    if (indexMove == 1)
                    {
                        inputA_str = use_input.text;
                        if (inputA_str.Equals("스위치") || inputA_str.Equals("낡은스위치") || inputA_str.Equals("낡은 스위치"))
                        {
                            if (switchOn_i == 1)
                            {
                                //액션을 취할것이 없을 때 10개 정도 이제 할것은 없다 이제 만질 것은 없다.
                                t_txt.text = "그건 이미 했어.";
                            }
                            else
                            {
                                item();
                                use_input.text = "";

                                Debug.Log("a");
                                indexAct = 10;

                                switchOn_i = 1;
                                dark_obj.SetActive(false);
                                GM.GetComponent<SoundEvt>().SwitchSound();

                                arrowD_obj.SetActive(true);
                            }
                            Act_btn.SetActive(false);
                            use_inp.SetActive(false);
                        }
                    }
                    break;
                case 2:
                    if (indexMove == 1)
                    {
                        inputA_str = use_input.text;
                        if (inputA_str.Equals("급수대"))
                        {

                            if (findGlass_i == 0)
                            {
                                indexAct = 10;
                                findGlass_i = 1;
                            }
                            else
                            {
                                if (findKey_i == 1)
                                {
                                    //액션을 취할것이 없을 때 10개 정도 이제 할것은 없다 이제 만질 것은 없다.
                                    t_txt.text = "그건 이미 했어.";

                                    if (getKey_i == 1)
                                    {

                                    }
                                    else
                                    {
                                        if (findKey_i != 2)
                                        {
                                            findKey_i = 1;
                                        }
                                    }
                                }
                                else
                                {
                                    item();


                                    if (getKey_i == 1)
                                    {

                                    }
                                    else
                                    {
                                        if (findKey_i != 2)
                                        {
                                            findKey_i = 1;
                                        }
                                    }
                                }
                                indexAct = 11;
                            }
                            use_input.text = "";
                            waterCoundt_i++;
                            if (waterCoundt_i >= 5)
                            {
                                indexAct = 12;
                            }
                            Act_btn.SetActive(false);
                            use_inp.SetActive(false);
                        }

                    }
                    else
                    {
                        if (indexMove == 3)
                        {
                            inputA_str = use_input.text;
                            if (inputA_str.Equals("열쇠") || inputA_str.Equals("나무 열쇠") || inputA_str.Equals("나무열쇠"))
                            {
                                if (doorOpen_i == 1)
                                {
                                    //액션을 취할것이 없을 때 10개 정도 이제 할것은 없다 이제 만질 것은 없다.
                                }
                                else
                                {
                                    item();
                                    use_input.text = "";
                                    GM.GetComponent<SoundEvt>().DoorSound();
                                    //GM.GetComponent<SoundEvt>().BrokenSound();

                                    doorOpen_i = 1;
                                    go_btn.SetActive(true);
                                    indexAct = 10;
                                    Act_btn.SetActive(false);
                                    use_inp.SetActive(false);
                                    //itemR_obj.SetActive(false);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void Get()
    {
        fal();
        get_inp.SetActive(true);
    }
    public void GetOk()
    {
        if (stage_i == 0)
        {
            inputG_str = get_input.text;
            TutorialGet();
        }
        else
        {
            switch (direction)
            {
                case 1:
                    if (indexMove == 1)
                    {
                        t_txt.text = "그런 것은 없어.";
                    }
                    break;
                case 2:
                    if (indexMove == 1)
                    {
                        inputG_str = get_input.text;
                        int ckKey = 0;
                        if (inputG_str.Equals("열쇠") || inputG_str.Equals("나무 열쇠") || inputG_str.Equals("나무열쇠"))
                        {
                            ckKey = 1;
                        }
                        if (findKey_i == 2 && ckKey == 1)
                        {
                            if (getKey_i == 1)
                            {
                                //액션을 취할것이 없을 때 10개 정도 이제 할것은 없다 이제 만질 것은 없다.
                                t_txt.text = "그건 이미 했어.";
                            }
                            else
                            {

                                item();
                                t_txt.text = "나무 열쇠를 얻었다.";
                                get_input.text = "";
                                getKey_i = 1;

                                for (int i = 0; i <= 3; i++)
                                {
                                    Debug.Log(GM.GetComponent<ItemSys>().bagSlot_i[i]);
                                    if (GM.GetComponent<ItemSys>().bagSlot_i[i] == 0)
                                    {
                                        GM.GetComponent<ItemSys>().bagSlot_i[i] = 1;
                                        GM.GetComponent<ItemSys>().slot_obj[i].SetActive(true);
                                        GM.GetComponent<ItemSys>().slot_obj[i].GetComponent<Image>().sprite = GM.GetComponent<ItemSys>().item_spr[1];
                                        if (GM.GetComponent<ItemSys>().itemL_i == 0)
                                        {
                                            GM.GetComponent<ItemSys>().hand_obj[0].GetComponent<Image>().sprite = GM.GetComponent<ItemSys>().handItem_spr[1];
                                            GM.GetComponent<ItemSys>().hand_obj[0].SetActive(true);
                                            GM.GetComponent<ItemSys>().slotHand_obj[i].SetActive(true);
                                            GM.GetComponent<ItemSys>().itemL_i = 1;
                                        }
                                        else if (GM.GetComponent<ItemSys>().itemR_i == 0)
                                        {
                                            GM.GetComponent<ItemSys>().hand_obj[1].GetComponent<Image>().sprite = GM.GetComponent<ItemSys>().handItem_spr[1];
                                            GM.GetComponent<ItemSys>().hand_obj[1].SetActive(true);
                                            GM.GetComponent<ItemSys>().slotHand_obj[i].SetActive(true);
                                            GM.GetComponent<ItemSys>().itemR_i = 1;
                                        }
                                        i = 4;
                                    }
                                }



                                //handR_obj.SetActive(true);
                                //itemR_obj.GetComponent<Image>().sprite = key_spr;
                            }
                            Act_btn.SetActive(false);
                            get_inp.SetActive(false);
                        }
                        else
                        {
                            //오타가 난 경우 확인할 수 있도록
                            t_txt.text = "그런 것은 없어.";
                        }
                    }
                    else
                    {
                        t_txt.text = "그런 것은 없어.";
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void Go()
    {
        if (stage_i == 0)
        {
            TutorialGo();
        }
        else
        {
        }
    }


    IEnumerator imgFadeOut()
    {
        for (float i = 0f; i < 1f; i += 0.05f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(1f, 0f, i);
            fade_obj.GetComponent<Image>().color = color;

            yield return null;
        }
        fade_obj.SetActive(false);
    }

    //캐락터 움작임
    IEnumerator movechar()
    {
        int sc = 0;
        while (char_i == 1)
        {
            if (sc == 0)
            {
                char_obj.GetComponent<Image>().sprite = char_spr[sc];
                sc = 1;
            }
            else
            {
                char_obj.GetComponent<Image>().sprite = char_spr[sc];
                sc = 0;
            }
            yield return new WaitForSeconds(0.6f);
        }
    }


    public void Tutorial()
    {
        /*
T : ‘누구나 무엇이든 구매할 수 있다!’ ?0?마켓 사이트가 열려있다.
FEEL버튼만 활성화 (투명도 + 무채색으로 비활성화 표현)
T :‘누구나 무엇이든 구매할 수 있다!’ ?0?마켓 사이트가 열려있다.
아! 그래 주문해야지. 분명.. 거울이라고 했었지 아마?
ACT버튼만 활성화
ACT 사용 ‘거울’ 타이핑
T : 주문이 완료 되었다. 이제 오는 걸 기다리면 되겠지.
컴퓨터 꺼지고
방향버튼↑만 활성화
버튼 누르면
T : 이제 집으로 가야겠다. 으.. 어서 문을 열고 나가자.
MOVE만 문 타이핑
T : 문 앞에 섰다. ...아! 가방을 가져오는 걸 깜빡했어.
방향버튼↓만 활성화
T : 내가 앉았던 자리다. 아마 평생 여기서 일하겠지..
FEEL만 활성화
T : 내가 앉았던 자리다. 구석에 놓아 뒀던 가방이 보인다 ..많이 낡았네
GET만 활성화 ‘가방’ 타이핑 확득
T : 낡은 가방을 얻었다.
방향버튼↑만 활성화
T : 이제 집으로 가야겠다. 으.. 어서 문을 열고 나가자.
MOVE만 문 타이핑
T : 문 앞에 섰다.
GO버튼이 활성화되어서 나가짐
밖으로 나가는 모션과 함께 밝게되고 어두워짐
         */
    }

    public void TutorialStart()
    {
        t_txt.text = "‘누구나 무엇이든 구매할 수 있다!’ ?0?마켓 사이트가 열려있다.";
        char_obj.SetActive(false);
        tutoBody_obj.SetActive(true);
        tutoBack_obj.SetActive(true);
        tutoAct_obj.GetComponent<Button>().interactable = false;
        tutoMove_obj.GetComponent<Button>().interactable = false;
        tutoGet_obj.GetComponent<Button>().interactable = false;
        tutoAdd_obj.GetComponent<Button>().interactable = false;
        tutoResolve_obj.GetComponent<Button>().interactable = false;
    }

    void TutorialFeel()
    {
        TutoFalse();
        switch (tuto_i)
        {
            case 0:
                t_txt.text = "‘누구나 무엇이든 구매할 수 있다!’ ?0?마켓 사이트가 열려있다. 아!그래 주문해야지.분명..거울이라고 했었지 아마?";
                
                tutoAct_obj.GetComponent<Button>().interactable = true;
                break;
            case 1:
                t_txt.text = "내가 앉았던 자리다. 구석에 놓아 뒀던 가방이 보인다 ..많이 낡았네";
                tutoGet_obj.GetComponent<Button>().interactable = true;
                break;
            default:
                break;
        }
        tuto_i++;
    }
    void TutorialAct()
    {
        if (inputA_str.Equals("거울"))
        {
            TutoFalse();
            tutoBack_obj.GetComponent<Image>().sprite = tutoBack_spr[0];
            t_txt.text = "텍스트 필요";
            tutoDelay_obj.SetActive(true);
        }
    }
    public void TutoDelay()
    {
        back.GetComponent<Image>().sprite = tutoBack_spr[2];
        TutoFalse();
        tutoBack_obj.SetActive(false);
        tutoDelay_obj.SetActive(false);
        t_txt.text = "주문이 완료 되었다. 이제 오는 걸 기다리면 되겠지.";
        tutoUp_obj.SetActive(true);
    }
    void TutorialUp()
    {
        back.GetComponent<Image>().sprite = tutoBack_spr[1];
        TutoFalse();
        t_txt.text = "이제 집으로 가야겠다. 으.. 어서 문을 열고 나가자.";
        tutoMove_obj.GetComponent<Button>().interactable = true;
    }
    void TutorialMove()
    {
        TutoFalse();
        switch (tutoAct_i)
        {
            case 0:
                t_txt.text = "문 앞에 섰다. ...아! 가방을 가져오는 걸 깜빡했어.";
                
                tutoDown_obj.SetActive(true);
                break;
            case 1:
                t_txt.text = "문 앞에 섰다.";
                tutoGo_obj.SetActive(true);
                break;
        }
        tutoAct_i++;
    }
    void TutorialDown()
    {
        back.GetComponent<Image>().sprite = tutoBack_spr[2];
        TutoFalse();
        t_txt.text = "내가 앉았던 자리다. 아마 평생 여기서 일하겠지..";
        tutoFeel_obj.GetComponent<Button>().interactable = true;
    }
    void TutorialGet()
    {
        TutoFalse();
        t_txt.text = "낡은 가방을 얻었다.";
        tutoUp_obj.SetActive(true);
    }
    void TutorialGo()
    {
        direction = 1;
        indexMove = 0;
        indexAct = 0;
        stage_i = 1;
        tutoUp_obj.SetActive(false);
        tutoDown_obj.SetActive(false);
        tutoFeel_obj.GetComponent<Button>().interactable = true;
        tutoAct_obj.GetComponent<Button>().interactable = true;
        tutoMove_obj.GetComponent<Button>().interactable = true;
        tutoGet_obj.GetComponent<Button>().interactable = true;
        tutoAdd_obj.GetComponent<Button>().interactable = true;
        tutoResolve_obj.GetComponent<Button>().interactable = true;
        tutoGo_obj.SetActive(false);
        char_obj.SetActive(true);
        tutoBody_obj.SetActive(false);
        back.GetComponent<Image>().sprite = back_spr[1];
        dark_obj.SetActive(true);
    }

    void TutoFalse()
    {
        fal();
        tutoUp_obj.SetActive(false);
        tutoDown_obj.SetActive(false);
        tutoFeel_obj.GetComponent<Button>().interactable = false;
        tutoAct_obj.GetComponent<Button>().interactable = false;
        tutoMove_obj.GetComponent<Button>().interactable = false;
        tutoGet_obj.GetComponent<Button>().interactable = false;
        tutoGo_obj.SetActive(false);
        tutoDelay_obj.SetActive(false);
    }
}
