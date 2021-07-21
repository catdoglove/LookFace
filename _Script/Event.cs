using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public int where_i, switchOn_i, findKey_i, doorOpen_i, pos_i, getKey_i, findswitch_i, waterCoundt_i, findGlass_i, progress_i, waterSee_i, waterdrink_i, progress2_i, eventsat2;
    public string[] s_str, sf_str;
    public int getBattery_i, getDr_i, getcap_i, getReoff_i, getReOn_i;
    public GameObject dr_obj,box_obj;
    //텍스트
    public string inputF_str, inputM_str, inputA_str, inputG_str, inputSum_str, inputDis_str;
    //인풋필드 및 행동 버튼
    public GameObject text, move_inp, use_inp, Act_btn, back_btn, go_btn, get_inp, Sum_inp, Sum2_inp, Dis_inp, Sum_obj;
    public Text t_txt, E_txt;
    public InputField use_input, move_input, get_input, sum1_input, sum2_input, dis_input;
    public int going_i;

    //배경
    public GameObject back, backEffect_obj;
    public Sprite[] back_spr, back2_spr;

    public GameObject ActBtn_obj, FeelBtn_obj;
    public GameObject[] hp_obj;

    //캐릭터
    public int char_i;
    public GameObject char_obj, body_obj, hair_obj,mirror_obj;
    public Sprite[] char_spr, mirror_spr;

    //이밴트
    public GameObject eventBtn_obj, dark_obj, eventTalk_obj, eventCharMove_obj, eventCharMove2_obj, eventBall_obj, eventTalk2_obj, end_obj;

    public GameObject GM;

    public CameraFilterPack_TV_ARCADE testcamera;

    public CameraFilterPack_Blizzard testcamera2;

    Color color, colorw;

    Vector2 pos;

    public GameObject fade_obj, fadein_obj;


    public static int stage_i=0;

    public int tuto_i, tutoAct_i, tutocant_i, tutoD_i;
    public int tutoPro_i=0;
    public GameObject tutoUp_obj, tutoDown_obj, tutoFeel_obj, tutoAct_obj, tutoMove_obj, tutoGet_obj, tutoGo_obj, tutoBack_obj, tutoBackBtn_obj, tutoDelay_obj, tutoAdd_obj, tutoResolve_obj, tutoBody_obj, tutoUse_obj;
    public Sprite[] tutoBack_spr;

    public GameObject bagHoverSite_obj;
    public GameObject tutohand;

    //doorOpen_i 문이 열림 findKey_i 급수대에 열쇠를 봄 switchOn_i 스위치를 켬 getKey_i 열쇠 얻음 findswitch_i 스위치를 봄
    //findGlass_i 유리조각을 봄


    public AudioSource BGS;
    float BGSVol_f;
    
    

    private void Update()
    {

    }
    void Start()
    {

        //esc 종료 다시 구현
        //으아아아~ 거울도 같이 해야함
        //이벤트 씬에서 화살표방향 없애기
        //스테이지1 >2도 넘어갈 때 페이드아웃효가
        //캐비넷(다가감), 거울, 유리조각(급수대) 멘트도 추가??  feel 관찰읏 다치는거  맞는 소리를 안 했나? //임시로 se_hurt
        //튜토리얼 > 스테이지1 전환할 때도 페이드 아웃...?
        //컴퓨터 화면 바로 전환말고 페이드 아웃처럼 꺼지는 효과 넣어주기
        //ㄴ왼쪽에 개발자 메일, 오른쪽 피드백보내기 버튼(유니티자체제작
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
        colorw = fadein_obj.GetComponent<Image>().color;

        fade_obj.SetActive(true);
        StopCoroutine("imgFadeOut");
        StartCoroutine("imgFadeOut");
    }

    void EvetStart()
    {
        GM.GetComponent<ItemSys>().CloseBag();
        arrowU_obj.SetActive(false);
        arrowD_obj.SetActive(false);
        arrowL_obj.SetActive(false);
        arrowR_obj.SetActive(false);
    }
    void EvetEnd()
    {
        arrowU_obj.SetActive(true);
        arrowD_obj.SetActive(true);
        arrowL_obj.SetActive(true);
        arrowR_obj.SetActive(true);
        switch (direction)
        {
            case 1:
                arrowU_obj.SetActive(false);
                break;
            case 2:
                arrowD_obj.SetActive(false);
                break;
            case 3:
                arrowL_obj.SetActive(false);
                break;
            case 4:
                arrowR_obj.SetActive(false);
                break;

            default:
                break;
        }
        if (stage_i == 1)
        {
            arrowL_obj.SetActive(false);
            arrowR_obj.SetActive(false);
        }
    }
    public void EventSnene1()
    {

        GM.GetComponent<ItemSys>().hand_obj[1].SetActive(false);
        GM.GetComponent<ItemSys>().hand_obj[0].SetActive(false);
        s_str[0] = "(터벅 터벅)";
        s_str[1] = "으... 엎친 데 덮친 격이네";
        s_str[2] = "주변이 좀 어두운 데 불 키는 거 없나?";
        if (stage_i == 2)
        {
            switch (progress2_i)
            {
                case 0:
                    //“여기는 무슨 창고인가.. 뭔가 잡다한 게 많네.”
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    eventTalk_obj.SetActive(true);
                    //GM.GetComponent<SoundEvt>().MoveSound();
                    GM.GetComponent<FaceEvent>().WorryFace();
                    GM.GetComponent<FaceEvent>().moven();
                    GM.GetComponent<FaceEvent>().moveR();
                    EvetStart();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 1:
                    GM.GetComponent<FaceEvent>().NomalFace();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    if (GM.GetComponent<ItemSys>().itemR_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[1].SetActive(true);
                    }
                    if (GM.GetComponent<ItemSys>().itemL_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[0].SetActive(true);
                    }
                    eventTalk_obj.SetActive(false);
                    E_txt.text = "";
                    eventsat2 = 1;

                    arrowU_obj.SetActive(false);
                    arrowD_obj.SetActive(false);
                    arrowL_obj.SetActive(false);
                    arrowR_obj.SetActive(true);
                    break;
                case 2:

                    arrowL_obj.SetActive(false);//책상3
                    arrowR_obj.SetActive(false);//선반4
                    //“콜록 콜록!”
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    EvetStart();
                    break;
                case 3:
                    //“뭐지? 어디선가 기침소리가 들리는데?” (불안한 표정)
                    eventTalk2_obj.SetActive(false);
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[5];
                    GM.GetComponent<FaceEvent>().moveR();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 4:
                    //선반 아래쪽 구석을 쳐다봤다.
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<FaceEvent>().NomalFace();
                    //GM.GetComponent<FaceEvent>().moveM();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().ArrowSound();
                    BackUpSizeR();
                    break;
                case 5:
                    //“음.. 여기서 소리가 났을 리는 없고..” (생각하는 표정)
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().ThinkFace();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    t_txt.text = "";
                    break;
                case 6:
                    //“대체 어디서..”
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 7:
                    //“콜록 콜록!”
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    break;
                case 8:
                    //“여기서 나잖아!” (놀란 표정)
                    eventTalk2_obj.SetActive(false);
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().SurprisedFace();
                    GM.GetComponent<FaceEvent>().moven();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 9:
                    //아래를 향해 손을 뻗었다. .//.///. 무언가 손에 잡혔다.
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<FaceEvent>().SurprisedFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[0];
                    GM.GetComponent<FaceEvent>().moveD();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().ArrowSound();
                    break;
                case 10:
                    //“..거울?” (생각하는 표정)
                    mirror_obj.SetActive(true);
                    eventTalk_obj.SetActive(true);
                    t_txt.text = "";
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[1];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    EventCharMove();
                    break;
                case 11:
                    //콜록 콜.. 음? 오! 꺼내졌네. 고마워!” (신난 거)
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    mirror_obj.GetComponent<Image>().sprite = mirror_spr[1];
                    break;
                case 12:

                    eventTalk2_obj.SetActive(false);
                    eventTalk_obj.SetActive(true);
                    //“거울이 말을 하잖아?????!!!!!!” (놀란 표정)
                    GM.GetComponent<FaceEvent>().SurprisedFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[0];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    mirror_obj.GetComponent<Image>().sprite = mirror_spr[0];
                    break;
                case 13:
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    //“아이고 시끄러워. 토끼소녀 좀 조용히 해줘.” “나도 지금 정신없다고.” (화난 거)
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    mirror_obj.GetComponent<Image>().sprite = mirror_spr[3];
                    break;
                case 14:
                    eventTalk2_obj.SetActive(false);
                    eventTalk_obj.SetActive(true);
                    //“예 아 음.. 말하는 거울은 처음 봤어요.” (일반 표정)
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().WorryFace();
                    GM.GetComponent<FaceEvent>().moveM();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[0];
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 15:
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    //“아무렴 어때! 너도 여기서 나가고 싶지?” (일반)
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    mirror_obj.GetComponent<Image>().sprite = mirror_spr[0];
                    break;
                case 16:
                    eventTalk2_obj.SetActive(false);
                    eventTalk_obj.SetActive(true);
                    //“에 그렇긴 하지만..” (불안한 표정)
                    GM.GetComponent<FaceEvent>().WorryFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[3];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 17:
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    //자 어서 둘러보자구! 토끼소녀!” (신난 거)
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    mirror_obj.GetComponent<Image>().sprite = mirror_spr[1];
                    break;
                case 18:
                    eventTalk2_obj.SetActive(false);
                    eventTalk_obj.SetActive(true);
                    //“뭐가 어떻게 된 거지..”(불안한 표정)
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[0];
                    GM.GetComponent<FaceEvent>().moveL();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 19:
                    BackReSize();
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<FaceEvent>().NomalFace();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    if (GM.GetComponent<ItemSys>().itemR_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[1].SetActive(true);
                    }
                    if (GM.GetComponent<ItemSys>().itemL_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[0].SetActive(true);
                    }
                    eventTalk_obj.SetActive(false);
                    eventTalk2_obj.SetActive(false);
                    mirror_obj.SetActive(false);
                    arrowU_obj.SetActive(true);//문양1
                    arrowD_obj.SetActive(true);//문2
                    arrowL_obj.SetActive(true);//책상3
                    arrowR_obj.SetActive(false);//선반4
                    E_txt.text = "";
                    EventCharBack();
                    break;
                case 20:

                    arrowL_obj.SetActive(false);//책상3
                    arrowR_obj.SetActive(false);//선반4
                    //드라이버로 무언가를 열 수 있겠는데.
                    mirror_obj.GetComponent<Image>().sprite = mirror_spr[0];
                    eventTalk2_obj.SetActive(true);
                    mirror_obj.SetActive(true);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    EventCharMove();
                    EvetStart();
                    break;
                case 21:
                    //“아마 열만한 게..”(생각표정
                    eventTalk_obj.SetActive(true);
                    eventTalk2_obj.SetActive(false);
                    GM.GetComponent<FaceEvent>().ThinkFace();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 22:
                    //“여기 있구만. 상자에 있는 못을 드라이버로 풀 수 있겠어.” (일반)
                    eventTalk_obj.SetActive(false);
                    eventTalk2_obj.SetActive(true);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    break;
                case 23:
                    //“아 그러면 되겠네요!” (놀란표정 손은 내림
                    eventTalk2_obj.SetActive(false);
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().SurprisedFace();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[1];
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[5];
                    GM.GetComponent<FaceEvent>().moven();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 24:
                    //EventCharBack();
                    GM.GetComponent<FaceEvent>().NomalFace();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    if (GM.GetComponent<ItemSys>().itemR_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[1].SetActive(true);
                    }
                    if (GM.GetComponent<ItemSys>().itemL_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[0].SetActive(true);
                    }
                    eventTalk_obj.SetActive(false);
                    eventTalk2_obj.SetActive(false);
                    mirror_obj.SetActive(false);
                    arrowR_obj.SetActive(false);
                    arrowL_obj.SetActive(false);
                    tutoUp_obj.SetActive(false);
                    tutoDown_obj.SetActive(false);
                    tutoResolve_obj.GetComponent<Button>().interactable = false;
                    tutoUse_obj.GetComponent<Button>().interactable = false;
                    //tutoFeel_obj.GetComponent<Button>().interactable = false;
                    tutoMove_obj.GetComponent<Button>().interactable = false;
                    tutoBackBtn_obj.GetComponent<Button>().interactable = false;
                    tutoGet_obj.GetComponent<Button>().interactable = false;
                    E_txt.text = "";
                    EventCharBack();
                    break;
                case 25:
                    arrowL_obj.SetActive(false);//책상3
                    arrowR_obj.SetActive(false);//선반4
                    //“캡슐 안에 뭔가 있어요.” (다 일반
                    EventCharMove();
                    eventTalk_obj.SetActive(true);
                    mirror_obj.SetActive(true);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    EvetStart();
                    break;
                case 26:
                    //“이건 그냥 손으로 열 수 있겠는데” (일반)
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    break;
                case 27:
                    //“m / 손 / 에 / / 들 / 고 / / 분 / 해 / 를 / / 해 / 보 / 자 / 고 /
                    eventTalk2_obj.SetActive(true);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    break;
                case 28:
                    //“한번 해볼게요.”
                    eventTalk_obj.SetActive(true);
                    eventTalk2_obj.SetActive(false);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 29:
                    GM.GetComponent<FaceEvent>().NomalFace();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    if (GM.GetComponent<ItemSys>().itemR_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[1].SetActive(true);
                    }
                    if (GM.GetComponent<ItemSys>().itemL_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[0].SetActive(true);
                    }
                    eventTalk_obj.SetActive(false);
                    eventTalk2_obj.SetActive(false);
                    mirror_obj.SetActive(false);
                    arrowR_obj.SetActive(false);
                    arrowL_obj.SetActive(false);
                    tutoUp_obj.SetActive(false);
                    tutoDown_obj.SetActive(false);
                    tutoAdd_obj.GetComponent<Button>().interactable = false;
                    tutoUse_obj.GetComponent<Button>().interactable = false;
                    tutoFeel_obj.GetComponent<Button>().interactable = false;
                    tutoMove_obj.GetComponent<Button>().interactable = false;
                    tutoBackBtn_obj.GetComponent<Button>().interactable = false;
                    tutoGet_obj.GetComponent<Button>().interactable = false;
                    E_txt.text = "";
                    EventCharBack();
                    GM.GetComponent<ItemSys>().OpenBag();
                    break;
                case 30:
                    EventCharMove();
                    //“어디서 본 거 같아요.” (생각하는 표정)
                    mirror_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().ThinkFace();
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    EvetStart();
                    break;
                case 31:
                    //“나도 방금까지 본 거 같은데..”(일반
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    break;
                case 32:
                    //“아! 리모콘에서 봤어요!” (놀란 + 손은 내리고)
                    eventTalk_obj.SetActive(true);
                    eventTalk2_obj.SetActive(false);
                    GM.GetComponent<FaceEvent>().SurprisedFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[0];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 33:
                    //“오 좋아. 그럼 한번 살펴보자고”(신난 거
                    eventTalk2_obj.SetActive(true);
                    eventTalk_obj.SetActive(false);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    mirror_obj.GetComponent<Image>().sprite = mirror_spr[1];
                    break;
                case 34:
                    mirror_obj.GetComponent<Image>().sprite = mirror_spr[0];
                    GM.GetComponent<FaceEvent>().NomalFace();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    if (GM.GetComponent<ItemSys>().itemR_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[1].SetActive(true);
                    }
                    if (GM.GetComponent<ItemSys>().itemL_i != 0)
                    {
                        GM.GetComponent<ItemSys>().hand_obj[0].SetActive(true);
                    }
                    eventTalk_obj.SetActive(false);
                    eventTalk2_obj.SetActive(false);
                    mirror_obj.SetActive(false);
                    arrowR_obj.SetActive(false);
                    arrowL_obj.SetActive(false);
                    tutoUp_obj.SetActive(false);
                    tutoDown_obj.SetActive(false);
                    tutoResolve_obj.GetComponent<Button>().interactable = false;
                    tutoUse_obj.GetComponent<Button>().interactable = true;
                    tutoAdd_obj.GetComponent<Button>().interactable = false;
                    tutoFeel_obj.GetComponent<Button>().interactable = false;
                    tutoMove_obj.GetComponent<Button>().interactable = false;
                    tutoBackBtn_obj.GetComponent<Button>().interactable = false;
                    tutoGet_obj.GetComponent<Button>().interactable = false;
                    E_txt.text = "";
                    EventCharBack();
                    break;
                case 35:
                    EventCharMove();
                    //“뭐지? 무슨 소리가 났는데.” (일반
                    eventTalk2_obj.SetActive(true);
                    mirror_obj.SetActive(true);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    EvetStart();
                    break;
                case 36:
                    //“딱히 변한 건 없어요.” (불안한 표정으로)
                    eventTalk_obj.SetActive(true);
                    eventTalk2_obj.SetActive(false);
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[3];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 37:
                    //“음.. 다른데를 살펴볼..” (일반
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkMirrorSound();
                    break;
                case 38:
                    //으아아아아!! (놀란+ 손은 내리고) (불안하거나 걱정되는 땀 삐질)
                    eventTalk2_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().SurprisedFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[0];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    GM.GetComponent<SoundEvt>().fallingSound();
                    fade_obj.SetActive(true);
                    StartCoroutine("imgFadeOutend");
                    break;
                case 39:
                    end_obj.SetActive(true);
                    BGS.mute = true;
                    break;
                default:
                    break;
            }
            progress2_i++;
        }
        if (stage_i == 1)
        {
            switch (progress_i)
            {
                case 0:
                    //p/(/터/벅/ /터/벅/)
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    //eventTalk_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[6].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().eyebrow_spr[1];
                    EvetStart();
                    break;
                case 1:
                    eventTalk_obj.SetActive(true);
                    ///으/./././//// /엎/친/ /데/ /덮/친/ /격/이/네/
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 2:
                    ///주/변/이/ /좀/ /어/두/운/ /데/ /불/ /키/는/ /거/ /없/나/?/
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 3:

                    GM.GetComponent<FaceEvent>().NomalFace();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    eventTalk_obj.SetActive(false);
                    arrowD_obj.SetActive(false);
                    E_txt.text = "";
                    break;
                case 4:
                    ///휴/ /이/제/야/ /밝/아/졌/네/.///// /어/디/ /한/번/ /둘/러/볼/까/?/
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    GM.GetComponent<FaceEvent>().RelaxFace();
                    EvetStart();
                    break;
                case 5:
                    ///위/험/한/ /게/ /있/을 /수/ /있/으/니/ /조/심/해/서/ /살/펴/봐/야/겠/다/./
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    GM.GetComponent<FaceEvent>().WorryFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[3];
                    GM.GetComponent<FaceEvent>().moveL();
                    break;
                case 6:
                    ///어/차/피/ /표/정/에/ /다/ /드/러/나/지/만/././
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[3];
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[0];
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 7:
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().moveM();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    eventTalk_obj.SetActive(false);
                    //GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[2];
                    E_txt.text = "";
                    break;
                case 8:
                    ///목/이/ /마/른/데/././///// /마/실/ /수/ /있/을/까/?/
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().WorryFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[5];
                    GM.GetComponent<FaceEvent>().faceParts_obj[7].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().body_spr[1];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    GM.GetComponent<FaceEvent>().moveR();
                    EvetStart();
                    break;
                case 9:
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().moveM();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    eventTalk_obj.SetActive(false);
                    E_txt.text = "";
                    break;
                case 10:
                    ///이/제/야/ /살/ /것/ /같/네/./ /휴/././
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().RelaxFace();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    EvetStart();
                    break;
                case 11:
                    ///음/?/ /꼭/지/ /뒤/에/ /뭔/가/ /있/는/데/?/
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[5];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 12:
                    GM.GetComponent<FaceEvent>().NomalFace();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    eventTalk_obj.SetActive(false);
                    E_txt.text = "";
                    break;
                case 13:
                    ///깜/짝/이/야/////// /열/쇠/가/ /부/러/졌/네/./
                    eventTalk_obj.SetActive(true);
                    GM.GetComponent<FaceEvent>().SurprisedFace();
                    GM.GetComponent<FaceEvent>().moven();
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().BrokenSound();
                    EvetStart();
                    break;
                case 14:
                    ///문/은/ /열/렸/으/니/ /다/행/이/지/만/././
                    GM.GetComponent<FaceEvent>().NomalFace();
                    GM.GetComponent<FaceEvent>().faceParts_obj[2].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().mouth_spr[5];
                    GM.GetComponent<FaceEvent>().faceParts_obj[3].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().eyes_spr[1];
                    GM.GetComponent<FaceEvent>().faceParts_obj[8].GetComponent<Image>().sprite = GM.GetComponent<FaceEvent>().eyesMask_spr[1];
                    GM.GetComponent<DialogSys>().talkeventbtn();
                    GM.GetComponent<SoundEvt>().TalkSound();
                    break;
                case 15:
                    GM.GetComponent<FaceEvent>().NomalFace();
                    eventBtn_obj.SetActive(false);
                    EvetEnd();
                    eventTalk_obj.SetActive(false);
                    E_txt.text = "";
                    break;
                default:
                    break;
            }
            progress_i++;
        }
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
        BackReSize();
        GM.GetComponent<SoundEvt>().ArrowSound();
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
        dr_obj.SetActive(false);
        box_obj.SetActive(false);
    }
    public void ArrowD()
    {
        BackReSize();
        GM.GetComponent<SoundEvt>().ArrowSound();
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
            else
            {

                if (waterSee_i == 0)
                {
                    waterSee_i = 1;
                    eventBtn_obj.SetActive(true);
                }
            }
        }
        dr_obj.SetActive(false);
        box_obj.SetActive(false);
    }

    public void ArrowR()
    {
        BackReSize();
        GM.GetComponent<SoundEvt>().ArrowSound();
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
            if (eventsat2 == 1)
            {
                eventBtn_obj.SetActive(true);
                eventsat2 = 2;
            }
        }

        dr_obj.SetActive(false);
        box_obj.SetActive(false);
    }

    public void ArrowL()
    {
        BackReSize();
        EventBoxBack();
        GM.GetComponent<SoundEvt>().ArrowSound();
        fal();
        if (stage_i == 2)
        {
            if (getDr_i == 0)
            {
                dr_obj.SetActive(true);
            }
            if (getcap_i == 0)
            {
                box_obj.SetActive(true);
            }
        }
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
        GM.GetComponent<SoundEvt>().ArrowSound();
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
                        if (indexMove == 1)
                        {
                            if (eventsat2 == 4 && getReOn_i == 1)
                            {
                                eventBtn_obj.SetActive(true);
                                eventsat2 = 5;
                            }
                        }
                        break;
                    case 2:
                        indexAct = 1;
                        break;
                    case 3:
                        indexAct = 1;
                        if (getDr_i == 1 && indexMove == 1)
                        {
                            indexAct = 3;
                        }
                        if (getcap_i == 1 && indexMove == 1)
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
            else
            {
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
                        }
                        else if (indexMove == 0)
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

                        if (indexMove == 2)
                        {
                            indexAct = 1;
                        }
                        break;
                    case 2:
                        if (indexMove == 3)
                        {
                            indexAct = 1;
                        }
                        if (indexMove == 1)
                        {
                            findGlass_i = 1;
                            indexAct = 1;
                            if (findKey_i >= 1)
                            {
                                indexAct = 2;
                                findKey_i = 2;
                            }

                            if (getKey_i == 1)
                            {
                                indexAct = 3;
                            }
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
        GM.GetComponent<SoundEvt>().ArrowSound();
        fal();
        move_inp.SetActive(true);
    }

    public void Act()
    {
        GM.GetComponent<SoundEvt>().ArrowSound();
        fal();
        Act_btn.SetActive(true);
    }

    public void Use()
    {
        GM.GetComponent<SoundEvt>().ArrowSound();
        fal();
        use_inp.SetActive(true);
    }
    public void Dis()
    {
        GM.GetComponent<SoundEvt>().ArrowSound();
        fal();
        Dis_inp.SetActive(true);
        dis_input.text = "";
    }
    public void Sum()
    {
        GM.GetComponent<SoundEvt>().ArrowSound();
        fal();
        Sum_obj.SetActive(true);
        sum1_input.text = "";
        sum2_input.text = "";
    }


    void fal()
    {
        //GM.GetComponent<SoundEvt>().ArrowSound();
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
        GM.GetComponent<SoundEvt>().ArrowSound();
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
                            BackUpSizeM();
                            indexMove = 1;
                            move_input.text = "";
                            fal();
                            back_btn.SetActive(true);
                        }
                            break;
                    case 2:
                        if (inputM_str.Equals("문"))
                        {
                            BackUpSizeM();
                            indexMove = 0;
                            move_input.text = "";
                            fal();
                            back_btn.SetActive(true);
                        }
                        break;
                    case 3:
                        if (inputM_str.Equals("책상"))
                        {
                            BackUpSizeR();
                            EventBoxM();
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
                            BackUpSizeR();
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
                        if (inputM_str.Equals("붉은 빛") || inputM_str.Equals("붉은빛") || inputM_str.Equals("빛"))
                        {
                            BackUpSizeL();
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


                            if (inputM_str.Equals("캐비넷"))
                            {

                                BackUpSizeR();
                                indexMove = 2;
                                move_input.text = "";
                                fal();

                                back_btn.SetActive(true);
                                t_txt.text = "캐비넷 앞에 섰다.";
                            }
                            else
                            {
                                //오타가 난 경우 확인할 수 있도록
                                t_txt.text = "그런 곳으로는 갈수 없어.";
                            }

                        }
                        break;
                    case 2:
                        if (inputM_str.Equals("급수대"))
                        {
                            BackUpSizeR();
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
                                BackUpSizeL();
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
        GM.GetComponent<SoundEvt>().ArrowSound();
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
        BackReSize();
        EventBoxBack();

        GM.GetComponent<FaceEvent>().NomalFace();
    }

    public void SumOK()
    {
        GM.GetComponent<SoundEvt>().ArrowSound();
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
                    if (inputSum_str.Equals("철제 상자") || inputSum_str.Equals("철제상자") || inputSum_str.Equals("상자"))
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
                        if (inputSum_str.Equals("철제 상자") || inputSum_str.Equals("철제상자") || inputSum_str.Equals("상자"))
                        {
                            cdck++;
                        }
                    }
                    if (cdck>=2)
                    {
                        //캡슐 얻음
                        getcap_i = 1;
                        box_obj.SetActive(false);
                        GetI(4);
                        Act_btn.SetActive(false);
                        Sum_obj.SetActive(false);
                        indexAct = 10;
                        GM.GetComponent<DialogSys>().TextShow();
                        arrowR_obj.SetActive(true);
                        arrowL_obj.SetActive(true);
                        tutoUp_obj.SetActive(true);
                        tutoDown_obj.SetActive(true);
                        tutoResolve_obj.GetComponent<Button>().interactable = true;
                        tutoAdd_obj.GetComponent<Button>().interactable = true;
                        tutoUse_obj.GetComponent<Button>().interactable = true;
                        tutoFeel_obj.GetComponent<Button>().interactable = true;
                        tutoMove_obj.GetComponent<Button>().interactable = true;
                        tutoBackBtn_obj.GetComponent<Button>().interactable = true;
                        tutoGet_obj.GetComponent<Button>().interactable = true;

                        if (eventsat2 == 3)
                        {
                            eventBtn_obj.SetActive(true);
                            eventsat2 = 4;
                        }
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
            if (inputSum_str.Equals("불 꺼진 리모컨")|| inputSum_str.Equals("리모컨"))
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
                if (inputSum_str.Equals("불 꺼진 리모컨") || inputSum_str.Equals("리모컨"))
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
        GM.GetComponent<SoundEvt>().ArrowSound();
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
        if (inputDis_str.Equals("캡슐") || inputDis_str.Equals("투명한캡슐") || inputDis_str.Equals("투명한 캡슐"))
        {
            if (getcap_i == 1)
            {
                t_txt.text = "그런 것은 없어.";
                int cck = 0;
                if (GM.GetComponent<ItemSys>().itemR_i == 4)
                {
                    cck = 1;
                }
                if (GM.GetComponent<ItemSys>().itemL_i == 4)
                {
                    cck = 2;
                }
                Debug.Log(cck);
                if (getReoff_i == 0 && cck >= 1)
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

                    arrowR_obj.SetActive(true);
                    arrowL_obj.SetActive(true);
                    tutoUp_obj.SetActive(true);
                    tutoDown_obj.SetActive(true);
                    tutoResolve_obj.GetComponent<Button>().interactable = true;
                    tutoAdd_obj.GetComponent<Button>().interactable = true;
                    tutoUse_obj.GetComponent<Button>().interactable = true;
                    tutoFeel_obj.GetComponent<Button>().interactable = true;
                    tutoMove_obj.GetComponent<Button>().interactable = true;
                    tutoBackBtn_obj.GetComponent<Button>().interactable = true;
                    tutoGet_obj.GetComponent<Button>().interactable = true;
                }
            }
        }

    }

    public void ActOK()
    {
        GM.GetComponent<SoundEvt>().ArrowSound();
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
                            if (getReOn_i == 1)
                            {
                                if (inputA_str.Equals("불 켜진 리모컨") || inputSum_str.Equals("리모컨"))
                                {
                                    item();
                                    use_input.text = "";
                                    indexAct = 10;
                                    getReOn_i = 1;
                                    dark_obj.SetActive(false);
                                    GM.GetComponent<SoundEvt>().SwitchSound();
                                    progress2_i = 35;
                                    eventBtn_obj.SetActive(true);
                                    //GM.GetComponent<DialogSys>().TextShow();
                                    Act_btn.SetActive(false);
                                    use_inp.SetActive(false);

                                }
                            }
                            else
                            {

                                t_txt.text = "그런 것은 없어.";

                                if (inputA_str.Equals("불 꺼진 리모컨") || inputSum_str.Equals("리모컨"))
                                {
                                    item();
                                    use_input.text = "";
                                    indexAct = 11;
                                    getReOn_i = 1;
                                    dark_obj.SetActive(false);
                                    GM.GetComponent<SoundEvt>().SwitchSound();
                                    eventBtn_obj.SetActive(true);
                                    //GM.GetComponent<DialogSys>().TextShow();

                                }
                            }

                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        if (inputA_str.Equals("종이") || inputA_str.Equals("포스터"))
                        {
                            indexAct = 13;
                            use_input.text = "";
                            Act_btn.SetActive(false);
                            use_inp.SetActive(false);
                        }
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
                                    indexAct = 11;
                                }
                                else
                                {
                                    item();
                                    use_input.text = "";

                                    Debug.Log("a");
                                    indexAct = 10;

                                    switchOn_i = 1;
                                    eventBtn_obj.SetActive(true);
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
                                    hp_obj[2].SetActive(false);
                                    GM.GetComponent<SoundEvt>().BrokenSound();

                                }
                                else
                                {
                                    if (waterdrink_i == 0)
                                    {
                                        waterdrink_i = 1;
                                        eventBtn_obj.SetActive(true);
                                        GM.GetComponent<SoundEvt>().waterdropSound();
                                        hp_obj[2].SetActive(true);
                                    }

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
                                //use_input.text = "";
                                waterCoundt_i++;
                                if (waterCoundt_i >= 5)
                                {
                                    indexAct = 12;
                                }
                                Act_btn.SetActive(false);
                                use_inp.SetActive(false);
                            }


                            if (inputA_str.Equals("유리조각") || inputA_str.Equals("거울") || inputA_str.Equals("유리 조각"))
                            {
                                indexAct = 13;
                                use_input.text = "";
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
                                    else if (getKey_i == 1)
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
                                        GM.GetComponent<ItemSys>().itemL_i = 0;
                                        GM.GetComponent<ItemSys>().hand_obj[0].SetActive(false);
                                        GM.GetComponent<ItemSys>().slot_obj[0].SetActive(false);
                                        GM.GetComponent<ItemSys>().slotHand_obj[0].SetActive(false);
                                        eventBtn_obj.SetActive(true);
                                    }
                                }
                            }

                            if (indexMove == 3)
                            {
                                if (inputA_str.Equals("문")|| inputA_str.Equals("갈색 문") || inputA_str.Equals("갈색문"))
                                {

                                    use_input.text = "";
                                    Act_btn.SetActive(false);
                                    use_inp.SetActive(false);
                                    indexAct = 13;
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
        GM.GetComponent<SoundEvt>().ArrowSound();
        get_input.text = "";
        fal();
        get_inp.SetActive(true);
    }
    public void GetOk()
    {
        GM.GetComponent<SoundEvt>().ArrowSound();
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
                                    GM.GetComponent<SoundEvt>().getSound();
                                    if (eventsat2 == 2)
                                    {
                                        eventBtn_obj.SetActive(true);
                                        eventsat2 = 3;
                                    }
                                    
                                        dr_obj.SetActive(false);

                                }
                            }
                            else
                            {
                                t_txt.text = "그런 것은 없어.";
                            }

                            if (inputG_str.Equals("종이") || inputG_str.Equals("포스터"))
                            {
                                Debug.Log("dsads"+indexMove);
                                indexAct = 13;
                                get_input.text = "";
                                Act_btn.SetActive(false);
                                get_inp.SetActive(false);
                                GM.GetComponent<DialogSys>().TextShow();
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
                                GM.GetComponent<SoundEvt>().getSound();
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
                                    GM.GetComponent<SoundEvt>().getSound();
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

                            if (inputG_str.Equals("유리조각") || inputG_str.Equals("거울") || inputG_str.Equals("유리 조각"))
                            {
                                indexAct = 13;
                                get_input.text = "";
                                Act_btn.SetActive(false);
                                use_inp.SetActive(false);
                                GM.GetComponent<DialogSys>().TextShow();
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
        if (going_i==0)
        {
            going_i = 1;
            GM.GetComponent<FaceEvent>().NomalFace();
            GM.GetComponent<SoundEvt>().ArrowSound();
            StartCoroutine("StageFadeInOut");
        }
    }

    void TutoGoShot()
    {
        backEffect_obj.SetActive(true);
        //GM.GetComponent<ItemSys>().ShowBag();
        TutorialGo();
        t_txt.text = "";
        BGSVol_f = 0.2f;
        BGS.volume = BGSVol_f;
        BGS.Play();
        eventBtn_obj.SetActive(true);
        bagHoverSite_obj.SetActive(true);
    }


    void GoShot()
    {
        Back();
        GM.GetComponent<SoundEvt>().MoveSound();
        eventBtn_obj.SetActive(true);
        GM.GetComponent<DialogSys>().num = 0;
        go_btn.SetActive(false);
        t_txt.text = "";
        direction = 2;
        indexAct = 0;
        indexMove = 0;
        pos_i = 2;
        arrowU_obj.SetActive(false);//문양1
        arrowD_obj.SetActive(false);//문2
        arrowL_obj.SetActive(false);//책상3
        arrowR_obj.SetActive(true);//선반4
        back.GetComponent<Image>().sprite = back2_spr[2];
        tutoAdd_obj.GetComponent<Button>().interactable = true;
        tutoResolve_obj.GetComponent<Button>().interactable = true;
        stage_i = 2;
    }


    IEnumerator imgFadeOut()
    {
        GM.GetComponent<SoundEvt>().typingSound();
        yield return new WaitForSecondsRealtime(2.2f);
        for (float i = 1f; i > 0f; i -= 0.02f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(0f, 1f, i);
            fade_obj.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }
        fade_obj.SetActive(false);
    }

    IEnumerator imgFadein()
    {
        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(0f, 1f, i);
            fade_obj.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(2f);
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
        tutocant_i = 1;
        t_txt.text = "그런 것은 할 수 없어.";
        TutoFalse();
        switch (tuto_i)
        {
            case 0:
                //t_txt.text = "‘누구나 무엇이든 구매할 수 있다!’ ?0?마켓 사이트가 열려있다. 아!그래 주문해야지.분명..거울이라고 했었지 아마?";

                tutoPro_i++;
                tutocant_i = 0;
                tutoAct_obj.GetComponent<Button>().interactable = true;
                break;
            case 1:
                //t_txt.text = "내가 앉았던 자리다. 구석에 놓아 뒀던 가방이 보인다 ..많이 낡았네";
                tutoPro_i++;
                tutocant_i = 0;
                tutoGet_obj.GetComponent<Button>().interactable = true;
                break;
            default:
                break;
        }
        tuto_i++;
    }
    void TutorialAct()
    {
        tutocant_i = 1;
        t_txt.text = "그런 것은 할 수 없어.";
        if (inputA_str.Equals("거울"))
        {
            TutoFalse();
            tutoBack_obj.GetComponent<Image>().sprite = tutoBack_spr[0];
            //t_txt.text = "텍스트 필요";
            tutoPro_i++;
            tutocant_i = 0;
            tutoDelay_obj.SetActive(true);
            use_input.text = "";

            GM.GetComponent<SoundEvt>().typingSound();
        }
    }
    public void TutoDelay()
    {
        if (tutoD_i == 0)
        {
            StartCoroutine("TutoimgFadeInOut");
            tutoD_i = 1;
        }
    }
    void TutorialUp()
    {
        BackReSize();
        back.GetComponent<Image>().sprite = tutoBack_spr[1];
        TutoFalse();
        //t_txt.text = "이제 집으로 가야겠다. 으.. 어서 문을 열고 나가자.";
        tutoPro_i++;
        //GM.GetComponent<DialogSys>().TextShow();
        tutoMove_obj.GetComponent<Button>().interactable = true;
    }
    void TutorialMove()
    {
        tutocant_i = 1;
        t_txt.text = "그런 것은 할 수 없어.";
        if (inputM_str.Equals("문"))
        {
            BackUpSizeM();
            TutoFalse();
            switch (tutoAct_i)
            {
                case 0:
                    //t_txt.text = "문 앞에 섰다. ...아! 가방을 가져오는 걸 깜빡했어.";
                    tutoPro_i++;
                    tutocant_i = 0;
                    tutoDown_obj.SetActive(true);
                    break;
                case 1:
                    //t_txt.text = "문 앞에 섰다.";
                    tutoPro_i++;
                    tutocant_i = 0;
                    tutoGo_obj.SetActive(true);
                    break;
            }
            move_input.text = "";
            tutoAct_i++;
        }
    }
    void TutorialDown()
    {
        BackReSize();
        back.GetComponent<Image>().sprite = tutoBack_spr[2];
        TutoFalse();
        //t_txt.text = "내가 앉았던 자리다. 아마 평생 여기서 일하겠지..";
        tutoPro_i++;
        //GM.GetComponent<DialogSys>().TextShow();
        tutoFeel_obj.GetComponent<Button>().interactable = true;
    }
    void TutorialGet()
    {
        tutocant_i = 1;
        t_txt.text = "그런 것은 할 수 없어.";
        if (inputG_str.Equals("가방"))
        {
            TutoFalse();
            tutocant_i = 0;
            tutoPro_i++;
            tutoUp_obj.SetActive(true);
            get_input.text = "";
            tutohand.SetActive(true);
        }
        GM.GetComponent<DialogSys>().TextShow();
    }
    void TutorialGo()
    {
        BackReSize();
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
        GM.GetComponent<SoundEvt>().MoveSound();
        testcamera2._Fade = 0.1f;
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


    void BackUpSizeR()
    {
        RectTransform rectTran = back.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1201);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 781);
        Vector3 position = back.transform.localPosition;
        position.x = position.x - 160;
        back.transform.localPosition = position;
    }
    void BackUpSizeL()
    {
        RectTransform rectTran = back.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1201);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 781);
        Vector3 position = back.transform.localPosition;
        position.x = position.x + 160;
        back.transform.localPosition = position;
    }
    void BackUpSizeM()
    {
        RectTransform rectTran = back.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1201);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 781);
        Vector3 position = back.transform.localPosition;
        position.x = 0;
        back.transform.localPosition = position;
    }
    void BackReSize()
    {
        RectTransform rectTran = back.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 884);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 575);
        Vector3 position = back.transform.localPosition;
        position.x = 0;
        back.transform.localPosition = position;
    }

    void EventCharMove()
    {
        Vector3 position = eventCharMove_obj.transform.localPosition;
        position.x = -289.8f;
        eventCharMove_obj.transform.localPosition = position;

        Vector3 position2 = eventBall_obj.transform.localPosition;
        position2.x = 87.0324f;
        eventBall_obj.transform.localPosition = position2;
    }

    void EventCharBack()
    {
        Vector3 position = eventCharMove_obj.transform.localPosition;
        position.x = 0f;
        eventCharMove_obj.transform.localPosition = position;

        Vector3 position2 = eventBall_obj.transform.localPosition;
        position2.x = 376.8324f;
        eventBall_obj.transform.localPosition = position2;
    }
    void EventBoxM()
    {

        RectTransform rectTran = box_obj.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 292.1489f);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 171.6894f);
        Vector3 position = box_obj.transform.localPosition;
        position.x = 363.2f;
        position.y = 110.8f;
        box_obj.transform.localPosition = position;
    }

    void EventBoxBack()
    {

        RectTransform rectTran = box_obj.GetComponent<RectTransform>();
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 211);
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 124);
        Vector3 position = box_obj.transform.localPosition;
        position.x = 264.3399f;
        position.y = 80.59f;
        box_obj.transform.localPosition = position;
    }

    IEnumerator imgFadeOutend()
    {

        yield return new WaitForSeconds(0.1f);
        for (float i = 1f; i >= 0f; i -= 0.05f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(1f, 0f, i);
            fade_obj.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.005f);
        }

        fade_obj.GetComponent<Image>().color = Color.black;
    }

    IEnumerator TutoimgFadeInOut()
    {

        yield return new WaitForSeconds(0.1f);
        for (float i = 1f; i >= 0f; i -= 0.05f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(1f, 0f, i);
            fade_obj.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }

        testcamera.Fade = 0f;
        back.GetComponent<Image>().sprite = tutoBack_spr[2];
        tutoBack_obj.SetActive(false);
        tutoDelay_obj.SetActive(false);
        t_txt.text = "";
        //t_txt.text = "주문이 완료 되었다. 이제 오는 걸 기다리면 되겠지.";
        fade_obj.GetComponent<Image>().color = Color.black;
        yield return new WaitForSecondsRealtime(0.5f);
        for (float i = 1f; i > 0f; i -= 0.02f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(0f, 1f, i);
            fade_obj.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }

        TutoFalse();
        fade_obj.SetActive(false);
        tutoPro_i++;
        GM.GetComponent<DialogSys>().TextShow();
        tutoUp_obj.SetActive(true);
    }


    IEnumerator StageFadeInOut()
    {

        yield return new WaitForSeconds(0.1f);
        for (float i = 1f; i >= 0f; i -= 0.05f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(1f, 0f, i);
            fade_obj.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }


        if (stage_i == 0)
        {
            TutoGoShot();
        }
        else
        {
            GoShot();
        }

        fade_obj.GetComponent<Image>().color = Color.black;
        yield return new WaitForSecondsRealtime(0.8f);
        for (float i = 1f; i > 0f; i -= 0.02f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(0f, 1f, i);
            fade_obj.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }
        going_i = 0;
        fade_obj.SetActive(false);
    }

    public void Pdb()
    {
        Application.OpenURL("https://docs.google.com/forms/d/1JQtDxXflfUxHlVaDIVPOCnT9n3DB7fKB83UPYikYuYs/edit?usp=sharing");
    }
}
