using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    //인덱스번호
    public static int direction = 1;
    public static int indexMove = 0;
    public static int indexAct = 2;

    // 방향버튼
    public GameObject arrowU_obj, arrowD_obj, arrowR_obj, arrowL_obj;
    //아이템과손
    public GameObject itemR_obj, itemL_obj, handR_obj, handL_obj;
    public int key;
    public Sprite key_spr;

    //변수
    public int where_i, switchOn_i, findKey_i, doorOpen_i, pos_i,getKey_i,findswitch_i, waterCoundt_i, findGlass_i;
    public string[] s_str, sf_str;
    //텍스트
    public string inputF_str, inputM_str, inputA_str, inputG_str;
    //인풋필드 및 행동 버튼
    public GameObject text, move_inp, use_inp, Act_btn, act_inp, back_btn, get_inp; 
    public Text t_txt;
    public InputField use_input, move_input, get_input;
    public GameObject back;
    public Sprite[] back_spr;

    //얼굴
    public GameObject face_obj, eyes_obj,nose_obj,mouse_obj,ears_obj, eyeb_obj;
    public Sprite[] face_spr, eyes_spr, nose_spr, mouse_spr, ears_spr, eyeb_spr;
    public int face_i,find_i,findM_i;

    //캐릭터
    public int char_i;
    public GameObject char_obj,body_obj,arm_obj,hair_obj;
    public Sprite[] char_spr;



    void Start()
    {
        //doorOpen_i 문이 열림 findKey_i 급수대에 열쇠를 봄 switchOn_i 스위치를 켬 getKey_i 열쇠 얻음 findswitch_i 스위치를 봄
        //findGlass_i 유리조각을 봄
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
    }



    //살짝 웃음
    void item()
    {
        find_i = 0;
        eyes_obj.GetComponent<Image>().sprite = eyes_spr[find_i];
        mouse_obj.GetComponent<Image>().sprite = mouse_spr[2];
        switch (face_i)
        {
            case 0:
                eyeb_obj.GetComponent<Image>().sprite = eyeb_spr[0];
                break;
            default:
                break;
        }
    }
    void GetItem()
    {
        find_i = 0;
        eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
        eyeb_obj.GetComponent<Image>().sprite = eyeb_spr[0];
        mouse_obj.GetComponent<Image>().sprite = mouse_spr[1];
    }

    void BasicFace()
    {
        eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
        eyeb_obj.GetComponent<Image>().sprite = eyeb_spr[0];
        mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
    }

    public void ArrowU()
    {
        fal();
        direction = 1;
        indexMove = 0;
        indexAct = 0;
        if (switchOn_i == 1)
        {
            eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
        }
        pos_i = 1;
        //t_txt.text = ""+ s_str[pos_i];
        back.GetComponent<Image>().sprite = back_spr[pos_i];
        back_btn.SetActive(false);
        where_i = 0;

        move_input.text = "";
        get_input.text = "";
        use_input.text = "";

        arrowL_obj.SetActive(true);
        arrowR_obj.SetActive(true);
        arrowU_obj.SetActive(false);
        arrowD_obj.SetActive(true);

        if (findswitch_i == 1)
        {
            indexAct = 1;
        }

    }
    public void ArrowD()
    {
        fal();
        direction = 2;
        indexMove = 0;
        indexAct = 0;
        if (switchOn_i == 1)
        {
            eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
        }
        pos_i = 2;
        //t_txt.text = ""+ s_str[pos_i];
        back.GetComponent<Image>().sprite = back_spr[pos_i];
        back_btn.SetActive(false);
        where_i = 0;

        move_input.text = "";
        get_input.text = "";
        use_input.text = "";

        arrowL_obj.SetActive(true);
        arrowR_obj.SetActive(true);
        arrowU_obj.SetActive(true);
        arrowD_obj.SetActive(false);
    }

    public void ArrowR()
    {
        fal();
        direction = 4;
        indexMove = 0;
        indexAct = 0;
        if (switchOn_i == 1)
        {
            eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
        }
        pos_i = 4;
        //t_txt.text = ""+ s_str[pos_i];
        back.GetComponent<Image>().sprite = back_spr[pos_i];
        back_btn.SetActive(false);
        where_i = 0;

        move_input.text = "";
        get_input.text = "";
        use_input.text = "";

        arrowL_obj.SetActive(true);
        arrowR_obj.SetActive(false);
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
        //t_txt.text = "" + s_str[pos_i];
        back.GetComponent<Image>().sprite = back_spr[pos_i];
        back_btn.SetActive(false);
        where_i = 0;

        move_input.text = "";
        get_input.text = "";
        use_input.text = "";

        arrowL_obj.SetActive(false);
        arrowR_obj.SetActive(true);
        arrowU_obj.SetActive(true);
        arrowD_obj.SetActive(true);
    }

    public void Feel()
    {
        indexAct = 1;
        findM_i = 0;
        fal();

        if (where_i == 1)
        {
            mouse_obj.GetComponent<Image>().sprite = mouse_spr[1];
        }

        if (where_i == 2)
        {
            mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];

        }

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

            default:
                break;
        }

        #region
        /*
            switch (pos_i)
        {
            case 1:

                if (where_i == 1)
                {
                    eyes_obj.GetComponent<Image>().sprite = eyes_spr[2];
                    mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
                }
                if (switchOn_i == 1)
                {

                    indexAct = 2;
                    eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
                    mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
                }
                break;
            case 2:
                if (where_i == 1)
                {
                    eyes_obj.GetComponent<Image>().sprite = eyes_spr[2];
                    mouse_obj.GetComponent<Image>().sprite = mouse_spr[1];
                }
                if (where_i == 2)
                {
                    eyes_obj.GetComponent<Image>().sprite = eyes_spr[2];
                    mouse_obj.GetComponent<Image>().sprite = mouse_spr[1];

                    if (doorOpen_i == 2)
                    {
                        eyes_obj.GetComponent<Image>().sprite = eyes_spr[2];
                        mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
                    }
                }

                if (where_i == 1&& getKey_i == 1)
                {
                    eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
                    mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
                }
                if (getKey_i == 1&& doorOpen_i==1)
                {
                    mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
                }
                break;
            default:
                break;
        }*/
        #endregion
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
    }



    public void MoveOk()
    {
        indexAct = 9;
        inputM_str = move_input.text;
        switch (direction)
        {
            case 1:
                if (inputM_str.Equals("스위치"))
                {
                    mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
                    //where_i = 1;
                    t_txt.text = "스위치 앞에 섰다.";
                    move_input.text = "";
                    fal();

                    back_btn.SetActive(true);
                    indexMove = 1;


                    if (switchOn_i == 1)
                    {
                        eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
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
                    mouse_obj.GetComponent<Image>().sprite = mouse_spr[1];
                    //where_i = 1;
                    //t_txt.text = "급수대 앞에 섰다.";
                    move_input.text = "";
                    fal();
                    back_btn.SetActive(true);
                    indexMove = 1;

                    if (getKey_i == 1)
                    {
                        eyes_obj.GetComponent<Image>().sprite = eyes_spr[0];
                        mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
                    }
                }
                else
                {
                    if (inputM_str.Equals("문"))
                    {
                        mouse_obj.GetComponent<Image>().sprite = mouse_spr[1];
                        //where_i = 2;
                        //t_txt.text = "문 앞에 섰다.";
                        move_input.text = "";
                        fal();
                        back_btn.SetActive(true);
                        indexMove = 3;
                        if (doorOpen_i == 1)
                        {
                            eyes_obj.GetComponent<Image>().sprite = eyes_spr[2];
                            mouse_obj.GetComponent<Image>().sprite = mouse_spr[0];
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

    public void Back()
    {
        //where_i = 0;
        indexMove = 0;
        back_btn.SetActive(false);
        move_inp.SetActive(false);
        Act_btn.SetActive(false);
        use_inp.SetActive(false);
        get_inp.SetActive(false);
        t_txt.text = "다시 제자리로 돌아왔다.";
        BasicFace();
    }

    public void ActOK()
    {
        t_txt.text = "그런 것은 없어.";
        switch (pos_i)
        {
            case 1:
                if (indexMove == 1)
                {
                    inputA_str = use_input.text;
                    if (inputA_str.Equals("스위치"))
                    {
                        if (switchOn_i == 1)
                        {
                            //액션을 취할것이 없을 때 10개 정도 이제 할것은 없다 이제 만질 것은 없다.
                            t_txt.text = "그건 이미 했어.";
                        }
                        else
                        {
                            item();
                            //t_txt.text = "스위치를 ON으로 바꾸자 불이 켜졌다.";
                            use_input.text = "";

                            indexAct = 10;

                            //sf_str[1] = "낡은 스위치가 있다. 음..ON으로 되어 있네";
                            switchOn_i = 1;
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
                        if (findKey_i == 1)
                        {
                            //액션을 취할것이 없을 때 10개 정도 이제 할것은 없다 이제 만질 것은 없다.
                            t_txt.text = "그건 이미 했어.";
                        }
                        else
                        {
                            item();
                            //t_txt.text = "물을 마셨다.";
                            

                            if (getKey_i == 1)
                            {

                            }
                            else
                            {
                                //sf_str[d_i + 1] = "물이 찰랑거린다. 자세히 보니 수면에 열쇠가 비치고 있다." + "\n" + "꼭지 뒤에 열쇠가 숨겨져 있었군.";
                                findKey_i = 1;
                            }
                        }
                        indexAct = 11;
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
                    if (where_i == 2)
                    {
                        inputA_str = use_input.text;
                        if (inputA_str.Equals("열쇠"))
                        {
                            if (doorOpen_i == 1)
                            {
                                //액션을 취할것이 없을 때 10개 정도 이제 할것은 없다 이제 만질 것은 없다.
                                t_txt.text = "그런 것은 없어.";
                            }
                            else
                            {
                                item();
                                t_txt.text = "문을 열었다.";
                                use_input.text = "";
                                
                                //sf_str[d_i + 2] = "문은 열려있다.";
                                doorOpen_i = 1;
                                Act_btn.SetActive(false);
                                use_inp.SetActive(false);
                                itemR_obj.SetActive(false);
                            }
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    public void Get()
    {
        fal();
        get_inp.SetActive(true);
    }
    public void GetOk()
    {
        switch (pos_i)
        {
            case 1:
                if (where_i == 1)
                {
                    t_txt.text = "그런 것은 없어.";
                }
                break;
            case 2:
                if (where_i == 1)
                {
                    inputG_str = get_input.text;
                    if (inputG_str.Equals("열쇠") && findKey_i == 1)
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
                            //sf_str[d_i + 1] = "물이 찰랑거린다. 수면에는 아무것도 비치고 있지 않다.";
                            itemR_obj.SetActive(true);
                            
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

    //캐락터 움작임
    IEnumerator movechar()
    {
        int sc=0;
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

}
