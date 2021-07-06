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
    public int getBattery_i, getDr_i, getcap_i, getReoff_i, getReOn_i;
    //텍스트
    public string inputF_str, inputM_str, inputA_str, inputG_str, inputSum_str, inputDis_str;
    //인풋필드 및 행동 버튼
    public GameObject text, move_inp, use_inp, Act_btn, back_btn, go_btn, get_inp, Sum_inp, Sum2_inp, Dis_inp, Sum_obj;
    public Text t_txt, E_txt;
    public InputField use_input, move_input, get_input, sum1_input, sum2_input, dis_input;
    public GameObject back;
    public Sprite[] back_spr, back2_spr;

    public GameObject ActBtn_obj, FeelBtn_obj;


    //캐릭터
    public int char_i;
    public GameObject char_obj, body_obj, hair_obj;
    public Sprite[] char_spr;

    //이밴트
    public GameObject eventBtn_obj, dark_obj, eventTalk_obj;

    public GameObject GM;

    public CameraFilterPack_TV_ARCADE testcamera;

    public CameraFilterPack_Blizzard testcamera2;

    Color color;

    Vector2 pos;

    public GameObject fade_obj;


    public static int stage_i=0;

    public int tuto_i, tutoAct_i;
    public int tutoPro_i=0;
    public GameObject tutoUp_obj, tutoDown_obj, tutoFeel_obj, tutoAct_obj, tutoMove_obj, tutoGet_obj, tutoGo_obj, tutoBack_obj, tutoDelay_obj, tutoAdd_obj, tutoResolve_obj, tutoBody_obj;
    public Sprite[] tutoBack_spr;

    public GameObject tutohand;

    //doorOpen_i 문이 열림 findKey_i 급수대에 열쇠를 봄 switchOn_i 스위치를 켬 getKey_i 열쇠 얻음 findswitch_i 스위치를 봄
    //findGlass_i 유리조각을 봄
    private void Update()
    {

    }
    void Start()
    {
        testcamera.Fade = 0.2f;
        testcamera2._Fade = 0f;
        
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
        else
        {
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
            sum1_input.text = "";
            sum2_input.text = "";
            dis_input.text = "";

            //arrowL_obj.SetActive(true);
            // arrowR_obj.SetActive(true);
            arrowU_obj.SetActive(false);
            arrowD_obj.SetActive(true);

            if (findswitch_i == 1)
            {
                indexAct = 1;
            }
            if (stage_i == 2)
            {
                indexAct = 0;
                back.GetComponent<Image>().sprite = back2_spr[pos_i];
                arrowL_obj.SetActive(true);
                arrowR_obj.SetActive(true);
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

            if (stage_i == 2)
            {
                indexAct = 1;
                back.GetComponent<Image>().sprite = back2_spr[pos_i];
                arrowL_obj.SetActive(true);
                arrowR_obj.SetActive(true);
            }
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
        if (stage_i == 2)
        {
            indexAct = 1;
            back.GetComponent<Image>().sprite = back2_spr[pos_i];
            arrowL_obj.SetActive(true);
            arrowR_obj.SetActive(false);
        }
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
        if (stage_i == 2)
        {
            indexAct = 1;
            back.GetComponent<Image>().sprite = back2_spr[pos_i];
            arrowL_obj.SetActive(false);
            arrowR_obj.SetActive(true);
        }
    }

    public void Feel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (stage_i == 0)
        {
            TutorialFeel();
        }
        else {
        fal();
            Debug.Log(switchOn_i);

            if (stage_i == 2)
            {
                switch (direction)
                {
                    case 1:
                        indexAct = 1;
                        break;
                    case 2:
                        indexAct = 1;
                        break;
                    case 3:
                        indexAct = 1;
                        if (getcap_i==1&& indexMove==1)
                        {
                            indexAct = 2;
                        }
                        break;
                    case 4:
                        indexAct = 1;
                        if (getBattery_i == 1 && indexMove == 1)
                        {
                            indexAct = 2;
                        }
                        break;

                    default:
                        break;
                }
                }
            else { 
            switch (direction)
            {
                case 1:
                if (indexAct == 1)
                {
                    findswitch_i = 1;
                }
                    if (indexMove == 1)
                    {
                        if (switchOn_i == 1)
                        {
                            indexAct = 2;
                        }
                        else
                        {

                            indexAct = 1;
                        }
                    }else if (indexMove == 0)
                    {
                        if (switchOn_i == 1)
                        {
                            indexAct = 1;
                        }
                        else
                        {

                            indexAct = 2;
                        }
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

        Debug.Log(indexAct);
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
    public void Dis()
    {
        fal();
        Dis_inp.SetActive(true);
    }
    public void Sum()
    {
        fal();
        Sum_obj.SetActive(true);
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
        Sum_obj.SetActive(false);
        Dis_inp.SetActive(false);
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

            if (stage_i == 2)
            {
                switch (direction)
                {
                    case 1:
                        if (inputM_str.Equals("문양") || inputM_str.Equals("커다란문양") || inputM_str.Equals("커다란 문양"))
                        {
                            indexMove = 1;
                            move_input.text = "";
                            fal();
                            back_btn.SetActive(true);
                        }
                            break;
                    case 2:
                        if (inputM_str.Equals("문"))
                        {
                            indexMove = 0;
                            move_input.text = "";
                            fal();
                            back_btn.SetActive(true);
                        }
                        break;
                    case 3:
                        if (inputM_str.Equals("책상"))
                        {
                            indexMove = 1;
                            move_input.text = "";
                            fal();
                            back_btn.SetActive(true);
                            indexMove = 1;
                        }
                        break;
                    case 4:
                        if (inputM_str.Equals("선반") || inputM_str.Equals("커다란선반") || inputM_str.Equals("커다란 선반"))
                        {
                            indexMove = 1;
                            move_input.text = "";
                            fal();
                            back_btn.SetActive(true);
                            indexMove = 1;
                        }
                            break;

                    default:
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case 1:
                        if (inputM_str.Equals("붉은 빛") || inputM_str.Equals("붉은빛"))
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
                            if (inputM_str.Equals("문") || inputM_str.Equals("갈색문") || inputM_str.Equals("갈색 문"))
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

    public void SumOK()
    {
        switch (direction)
        {
            case 1:
                t_txt.text = "그런 것은 할 수 없어.";
                break;
            case 2:
                t_txt.text = "그런 것은 할 수 없어.";
                break;
            case 3:
                if (indexMove == 1 && getcap_i==0)
                {
                    int cdck = 0;
                    inputSum_str = sum1_input.text;
                    if (inputSum_str.Equals("철제 상자") || inputSum_str.Equals("철제상자"))
                    {
                        cdck++;
                        inputSum_str = sum2_input.text;
                        if (inputSum_str.Equals("드라이버"))
                        {
                            cdck++;
                        }
                    }
                    if (cdck<2)
                    {
                        cdck = 0;
                    }
                    inputSum_str = sum1_input.text;
                    if (inputSum_str.Equals("드라이버"))
                    {
                        cdck++;
                        inputSum_str = sum2_input.text;
                        if (inputSum_str.Equals("철제 상자") || inputSum_str.Equals("철제상자"))
                        {
                            cdck++;
                        }
                    }
                    if (cdck>=2)
                    {
                        //캡슐 얻음
                        getcap_i = 1;
                        GetI(4);
                        Act_btn.SetActive(false);
                        Sum_obj.SetActive(false);
                        indexAct = 10;
                        GM.GetComponent<DialogSys>().TextShow();
                    }
                    else
                    {
                        t_txt.text = "그런 것은 할 수 없어.";
                    }

                }
                else
                {
                    t_txt.text = "그런 것은 할 수 없어.";
                }

                break;
            case 4:
                t_txt.text = "그런 것은 할 수 없어.";
                break;
            default:
                break;
        }

        if (getReoff_i == 1&& getReOn_i==0)
        {
            int rbck = 0;
            inputSum_str = sum1_input.text;
            if (inputSum_str.Equals("불 꺼진 리모컨"))
            {
                rbck++;
                inputSum_str = sum2_input.text;
                if (inputSum_str.Equals("건전지"))
                {
                    rbck++;
                }
            }
            if (rbck < 2)
            {
                rbck = 0;
            }
            inputSum_str = sum1_input.text;
            if (inputSum_str.Equals("건전지"))
            {
                rbck++;
                inputSum_str = sum2_input.text;
                if (inputSum_str.Equals("불 꺼진 리모컨"))
                {
                    rbck++;
                }
            }
            if (rbck >= 2)
            {
                Debug.Log("asds");
                int cck = 0;
                if (GM.GetComponent<ItemSys>().itemR_i == 5)
                {
                    cck++;
                }
                if (GM.GetComponent<ItemSys>().itemL_i == 3)
                {
                    cck++;
                }
                if (cck < 2)
                {
                    cck = 0;
                }
                if (GM.GetComponent<ItemSys>().itemR_i == 3)
                {
                    cck++;
                }
                if (GM.GetComponent<ItemSys>().itemL_i == 5)
                {
                    cck++;
                }
                if (cck >= 2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (GM.GetComponent<ItemSys>().bagSlot_i[i] == 5)
                        {
                            GM.GetComponent<ItemSys>().bagSlot_i[i] = 0;
                            GM.GetComponent<ItemSys>().slot_obj[i].SetActive(false);
                            GM.GetComponent<ItemSys>().slotHand_obj[i].SetActive(false);
                            GM.GetComponent<ItemSys>().itemR_i = 0;
                            GM.GetComponent<ItemSys>().hand_obj[1].SetActive(false);
                            GM.GetComponent<ItemSys>().itemL_i = 0;
                            GM.GetComponent<ItemSys>().hand_obj[0].SetActive(false);
                        }
                        if (GM.GetComponent<ItemSys>().bagSlot_i[i] == 3)
                        {
                            GM.GetComponent<ItemSys>().bagSlot_i[i] = 0;
                            GM.GetComponent<ItemSys>().slot_obj[i].SetActive(false);
                            GM.GetComponent<ItemSys>().slotHand_obj[i].SetActive(false);
                            GM.GetComponent<ItemSys>().itemR_i = 0;
                            GM.GetComponent<ItemSys>().hand_obj[1].SetActive(false);
                            GM.GetComponent<ItemSys>().itemL_i = 0;
                            GM.GetComponent<ItemSys>().hand_obj[0].SetActive(false);
                        }
                    }
                            //불 켜진 리모컨 얻음
                            getReOn_i = 1;
                    GetI(6);
                    Act_btn.SetActive(false);
                    Sum_obj.SetActive(false);
                    indexAct = 22;
                    GM.GetComponent<DialogSys>().TextShow();
                }
            }
            else
            {
                t_txt.text = "그런 것은 할 수 없어.";
            }
        }
    }
    public void DisOK()
    {
        switch (direction)
        {
            case 1:
                t_txt.text = "그런 것은 할 수 없어.";
                break;
            case 2:
                t_txt.text = "그런 것은 할 수 없어.";
                break;
            case 3:
                t_txt.text = "그런 것은 할 수 없어.";
                break;
            case 4:
                t_txt.text = "그런 것은 할 수 없어.";
                break;
            default:
                break;
        }

        inputDis_str = dis_input.text;
        if (inputDis_str.Equals("캡슐")&& getcap_i==1)
        {
            t_txt.text = "그런 것은 없어.";
            int cck = 0;
            if (GM.GetComponent<ItemSys>().itemR_i == 4)
            {
                cck=1;
            }
            if (GM.GetComponent<ItemSys>().itemL_i == 4)
            {
                cck=2;
            }
            Debug.Log(cck);
            if (getReoff_i == 0&&cck>=1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (GM.GetComponent<ItemSys>().bagSlot_i[i] == 4)
                    {
                        GM.GetComponent<ItemSys>().bagSlot_i[i] = 0;
                        GM.GetComponent<ItemSys>().slot_obj[i].SetActive(false);
                        GM.GetComponent<ItemSys>().slotHand_obj[i].SetActive(false);
                        if (cck == 1)
                        {
                            GM.GetComponent<ItemSys>().itemR_i = 0;
                            GM.GetComponent<ItemSys>().hand_obj[1].SetActive(false);
                        }
                        if (cck == 2)
                        {
                            GM.GetComponent<ItemSys>().itemL_i = 0;
                            GM.GetComponent<ItemSys>().hand_obj[0].SetActive(false);
                        }
                    }

                }
                //불꺼진리모컨 얻음
                getReoff_i = 1;
                GetI(5);
                Act_btn.SetActive(false);
                get_inp.SetActive(false);
                indexAct = 21;
                GM.GetComponent<DialogSys>().TextShow();

            }
        }

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

            /*
            arrowU_obj.SetActive(true);//문양1
            arrowD_obj.SetActive(false);//문2
            arrowL_obj.SetActive(true);//책상3
            arrowR_obj.SetActive(true);//선반4
            */
            inputA_str = use_input.text;
            if (stage_i == 2)
            {
                switch (direction)
                {
                    case 1:

                        if (indexMove == 1)
                        {
                            if (inputA_str.Equals("불 켜진 리모컨"))
                            {
                                    item();
                                    use_input.text = "";
                                    indexAct = 10;
                                    getReOn_i = 1;
                                    dark_obj.SetActive(false);
                                    GM.GetComponent<SoundEvt>().SwitchSound();
                                GM.GetComponent<DialogSys>().TextShow();
                                Debug.Log("게임끝");
                            }
                            
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case 1:
                        if (indexMove == 1)
                        {
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
                                        GM.GetComponent<ItemSys>().bagSlot_i[0] = 0;
                                        GM.GetComponent<ItemSys>().itemR_i = 0;
                                        GM.GetComponent<ItemSys>().slot_obj[0].SetActive(false);
                                        GM.GetComponent<ItemSys>().slotHand_obj[0].SetActive(false);
                                        GM.GetComponent<ItemSys>().hand_obj[0].SetActive(false);
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
    }

    public void Get()
    {
        get_input.text = "";
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

            /*
            arrowU_obj.SetActive(true);//문양1
            arrowD_obj.SetActive(false);//문2
            arrowL_obj.SetActive(true);//책상3
            arrowR_obj.SetActive(true);//선반4
            */
            inputG_str = get_input.text;
            if (stage_i == 2)
            {
                switch (direction)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        if (indexMove == 1)
                        {
                            if (inputG_str.Equals("드라이버") || inputG_str.Equals("낡은 드라이버") || inputG_str.Equals("낡은드라이버"))
                            {
                                t_txt.text = "그런 것은 없어.";
                                if (getDr_i == 0)
                                {
                                    //드라이버 얻음
                                    getDr_i = 1;
                                    GetI(2);
                                    Act_btn.SetActive(false);
                                    get_inp.SetActive(false);
                                    indexAct = 0;
                                    GM.GetComponent<DialogSys>().TextShow();
                                }
                            }
                            else
                            {
                                t_txt.text = "그런 것은 없어.";
                            }
                        }
                        else
                        {
                            t_txt.text = "그런 것은 없어.";
                        }
                        break;
                    case 4:

                        if (indexMove == 1)
                        {
                            if (inputG_str.Equals("건전지") && getBattery_i == 0)
                            {
                                //건전지 얻음
                                getBattery_i = 1;
                                GetI(3);
                                Act_btn.SetActive(false);
                                get_inp.SetActive(false);
                                indexAct = 0;
                                GM.GetComponent<DialogSys>().TextShow();
                            }
                            else
                            {
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
                                    //t_txt.text = "나무 열쇠를 얻었다.";
                                    get_input.text = "";
                                    getKey_i = 1;
                                    indexAct = 0;
                                    GM.GetComponent<DialogSys>().TextShow();
                                    GetI(1);



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
    }

    /// <summary>
    /// 아이템을 얻었을때 처리
    /// </summary>
    /// <param name="numi"></param>
    void GetI(int numi)
    {

        for (int i = 0; i <= 3; i++)
        {
            Debug.Log(GM.GetComponent<ItemSys>().bagSlot_i[i]);
            if (GM.GetComponent<ItemSys>().bagSlot_i[i] == 0)
            {
                GM.GetComponent<ItemSys>().bagSlot_i[i] = numi;
                GM.GetComponent<ItemSys>().slot_obj[i].SetActive(true);
                GM.GetComponent<ItemSys>().slot_obj[i].GetComponent<Image>().sprite = GM.GetComponent<ItemSys>().item_spr[numi];
                if (GM.GetComponent<ItemSys>().itemL_i == 0)
                {
                    GM.GetComponent<ItemSys>().hand_obj[0].GetComponent<Image>().sprite = GM.GetComponent<ItemSys>().handItem_spr[numi];
                    GM.GetComponent<ItemSys>().hand_obj[0].SetActive(true);
                    GM.GetComponent<ItemSys>().slotHand_obj[i].SetActive(true);
                    GM.GetComponent<ItemSys>().itemL_i = numi;
                }
                else if (GM.GetComponent<ItemSys>().itemR_i == 0)
                {
                    GM.GetComponent<ItemSys>().hand_obj[1].GetComponent<Image>().sprite = GM.GetComponent<ItemSys>().handItem_spr[numi];
                    GM.GetComponent<ItemSys>().hand_obj[1].SetActive(true);
                    GM.GetComponent<ItemSys>().slotHand_obj[i].SetActive(true);
                    GM.GetComponent<ItemSys>().itemR_i = numi;
                }
                i = 4;
            }
        }
    }

    public void Go()
    {
        if (stage_i == 0)
        {
            TutorialGo();
            t_txt.text = "";
        }
        else
        {
            go_btn.SetActive(false);
            t_txt.text = "";
            direction = 2;
            pos_i = 2;
            arrowU_obj.SetActive(true);//문양1
            arrowD_obj.SetActive(false);//문2
            arrowL_obj.SetActive(true);//책상3
            arrowR_obj.SetActive(true);//선반4
            back.GetComponent<Image>().sprite = back2_spr[2];
            //tutoAdd_obj.GetComponent<Button>().interactable = true;
            //tutoResolve_obj.GetComponent<Button>().interactable = true;
            stage_i = 2;
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
        //t_txt.text = "‘누구나 무엇이든 구매할 수 있다!’ ?0?마켓 사이트가 열려있다.";
        tutoPro_i++;
        GM.GetComponent<DialogSys>().TextShow();
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
                //t_txt.text = "‘누구나 무엇이든 구매할 수 있다!’ ?0?마켓 사이트가 열려있다. 아!그래 주문해야지.분명..거울이라고 했었지 아마?";

                tutoPro_i++;
                //GM.GetComponent<DialogSys>().TextShow();
                tutoAct_obj.GetComponent<Button>().interactable = true;
                break;
            case 1:
                //t_txt.text = "내가 앉았던 자리다. 구석에 놓아 뒀던 가방이 보인다 ..많이 낡았네";
                tutoPro_i++;
                //GM.GetComponent<DialogSys>().TextShow();
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
            //t_txt.text = "텍스트 필요";
            tutoPro_i++;
            //GM.GetComponent<DialogSys>().TextShow();
            tutoDelay_obj.SetActive(true);
            use_input.text = "";
        }
    }
    public void TutoDelay()
    {

        testcamera.Fade = 0f;
        back.GetComponent<Image>().sprite = tutoBack_spr[2];
        TutoFalse();
        tutoBack_obj.SetActive(false);
        tutoDelay_obj.SetActive(false);
        //t_txt.text = "주문이 완료 되었다. 이제 오는 걸 기다리면 되겠지.";
        tutoPro_i++;
        GM.GetComponent<DialogSys>().TextShow();
        tutoUp_obj.SetActive(true);
    }
    void TutorialUp()
    {
        back.GetComponent<Image>().sprite = tutoBack_spr[1];
        TutoFalse();
        //t_txt.text = "이제 집으로 가야겠다. 으.. 어서 문을 열고 나가자.";
        tutoPro_i++;
        //GM.GetComponent<DialogSys>().TextShow();
        tutoMove_obj.GetComponent<Button>().interactable = true;
    }
    void TutorialMove()
    {
        

        if (inputM_str.Equals("문"))
        {
            TutoFalse();
            switch (tutoAct_i)
            {
                case 0:
                    //t_txt.text = "문 앞에 섰다. ...아! 가방을 가져오는 걸 깜빡했어.";
                    tutoPro_i++;
                    //GM.GetComponent<DialogSys>().TextShow();

                    tutoDown_obj.SetActive(true);
                    break;
                case 1:
                    //t_txt.text = "문 앞에 섰다.";
                    tutoPro_i++;
                    //GM.GetComponent<DialogSys>().TextShow();
                    tutoGo_obj.SetActive(true);
                    break;
            }
            move_input.text = "";
            tutoAct_i++;
        }
    }
    void TutorialDown()
    {
        back.GetComponent<Image>().sprite = tutoBack_spr[2];
        TutoFalse();
        //t_txt.text = "내가 앉았던 자리다. 아마 평생 여기서 일하겠지..";
        tutoPro_i++;
        //GM.GetComponent<DialogSys>().TextShow();
        tutoFeel_obj.GetComponent<Button>().interactable = true;
    }
    void TutorialGet()
    {
        if (inputG_str.Equals("가방"))
        {
            TutoFalse();
            //t_txt.text = "낡은 가방을 얻었다.";
            tutoPro_i++;
            GM.GetComponent<DialogSys>().TextShow();
            tutoUp_obj.SetActive(true);
            get_input.text = "";
            tutohand.SetActive(true);
        }
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
        //tutoAdd_obj.GetComponent<Button>().interactable = true;
        //tutoResolve_obj.GetComponent<Button>().interactable = true;
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
