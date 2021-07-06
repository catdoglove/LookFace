using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSys : MonoBehaviour
{
    public Text Text_obj, TextChar_obj, TextOther_obj;
    string[] Text_cut; //대사 끊기

    int num = 0;
    float speedF = 0.05f;
    public GameObject speedBtn;//스피드업버튼

    List<Dictionary<string, object>> data_talk, data0_talk, data1_talk, data_eventtalk; //csv파일

    List<Dictionary<string, object>> data;
    public string str, code_str;
    public string face_str;
    public Text dialog_txt;
    public GameObject[] faceParts_obj;
    public Sprite[] eyeBall_spr, mouth_spr, eyes_spr, ears_spr, nose_spr, eyebrow_spr, container_spr;
    public int[] face_i;
    int spaceck_i;
    public GameObject GM;
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("스페이스 키 누름");
            textSpeedUp();
        }
    }

    void Awake()
    {
        data0_talk = CSVReader.Read("CSV/stage0");
        data1_talk = CSVReader.Read("CSV/stage1");
        data_talk = CSVReader.Read("CSV/stage2");
        data_eventtalk = CSVReader.Read("CSV/event0");
        data = CSVReader.Read("CSV/stage1");
    }


    void cleantalk() //대화 초기화
    {
        //Text_obj.text = "";
        str = "";
    }


    //문장스피드업기능 
    public void textSpeedUp()
    {
        speedF = 0.005f;
    }

    public void talkbtn()
    {
        str = "" + data_talk[0]["201"]; //뒷부분이 항목부르기 0은 고정값
        //TalkSound();
        Text_cut = str.Split('/');
        cleantalk();
        StartCoroutine("talkRun");
    }

    //대사 출력
    IEnumerator talkRun()
    {
        speedBtn.SetActive(true);
        for (int i = 0; i < Text_cut.Length; i++)
        {
            str = str.Insert(str.Length, Text_cut[i]);
            dialog_txt.text = str;
            yield return new WaitForSeconds(speedF);
        }
        speedBtn.SetActive(false);
        speedF = 0.05f;
        spaceck_i = 0;
    }


    public void talkeventbtn()
    {
        str = "" + data_eventtalk[num]["stage2"]; //뒷부분이 항목부르기 0은 고정값
        Text_cut = str.Split('/');
        cleantalk();
        StartCoroutine("talkEventRun");

        num++;
    }


    //대사 출력
    IEnumerator talkEventRun()
    {
        speedBtn.SetActive(true);
        eventTxtclean();
        for (int i = 1; i < Text_cut.Length; i++)
        {
            str = str.Insert(str.Length, Text_cut[i]);
            if (Text_cut[0] == "m")
            {
                TextOther_obj.text = str;
            }
            else if (Text_cut[0] == "p")
            {
                TextChar_obj.text = str;
            }
            else if (Text_cut[0] == "t")
            {
                Text_obj.text = str;
            }

            yield return new WaitForSeconds(speedF);
        }
        speedBtn.SetActive(false);
        speedF = 0.05f;
    }

    void eventTxtclean()
    {
        Text_obj.text = "";
        TextOther_obj.text = "";
        TextChar_obj.text = "";
    }


    public void TextShow()
    {
        //초기화 후 각각 값을 불러와서 순서대로 추가
        code_str = "";
        code_str = code_str + Event.direction;
        code_str = code_str + Event.indexMove;
        code_str = code_str + Event.indexAct;
        //20번 예외처리
        if (Event.indexAct >= 20)
        {
            code_str = "" + Event.indexAct;
        }

        if (Event.stage_i == 0)
        {
            data = data0_talk;
            code_str = "문장" + GM.GetComponent<Event>().tutoPro_i;
            //대사
            Debug.Log(code_str);
            str = "" + data[0][code_str];

            GM.GetComponent<SoundEvt>().TalkSound();
            //TalkSound();
            Text_cut = str.Split('/');
            cleantalk();
            StartCoroutine("talkRun");

        }
        else
        {

            Debug.Log(code_str);
            if (Event.stage_i == 2)
            {
                data = data_talk;
            }
            else if (Event.stage_i == 1)
            {
                data = data1_talk;
            }
            //중요 키값이 있는지 먼저 확인하기 그렇지 않으면 에러발생
            if (data[0].ContainsKey(code_str))
            {
                //대사
                str = "" + data[0][code_str];

                GM.GetComponent<SoundEvt>().TalkSound();
                //TalkSound();
                Text_cut = str.Split('/');
                cleantalk();
                StartCoroutine("talkRun");

                //dialog_txt.text = str;
                Debug.Log(str);
                //표정
                face_str = "" + data[1][code_str];

                //표정
                face_str = "" + data[1][code_str];

                for (int i = 0; i < 6; i++)
                {
                    if (face_str.Length < 6)
                    {
                        face_str = "0" + face_str;
                    }
                }

                Debug.Log(face_str);

                int k = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (int.Parse(face_str.Substring(i, 1)) == 9)
                    {
                        k = 1;
                    }
                    else
                    {
                        face_i[i] = int.Parse(face_str.Substring(i, 1));
                    }
                }

                if (k == 0)
                {
                    faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[face_i[0]];
                    faceParts_obj[6].GetComponent<Image>().sprite = eyeBall_spr[face_i[0]];
                    faceParts_obj[1].GetComponent<Image>().sprite = mouth_spr[face_i[1]];
                    faceParts_obj[2].GetComponent<Image>().sprite = eyes_spr[face_i[2]];
                    faceParts_obj[3].GetComponent<Image>().sprite = ears_spr[face_i[3]];
                    faceParts_obj[4].GetComponent<Image>().sprite = nose_spr[face_i[4]];
                    faceParts_obj[5].GetComponent<Image>().sprite = eyebrow_spr[face_i[5]];
                    faceParts_obj[0].SetActive(true);
                }
                else
                {
                    faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[5];
                    faceParts_obj[6].GetComponent<Image>().sprite = eyeBall_spr[5];
                    faceParts_obj[1].GetComponent<Image>().sprite = mouth_spr[0];
                    faceParts_obj[2].GetComponent<Image>().sprite = eyes_spr[2];
                    faceParts_obj[3].GetComponent<Image>().sprite = ears_spr[0];
                    faceParts_obj[4].GetComponent<Image>().sprite = nose_spr[0];
                    faceParts_obj[5].GetComponent<Image>().sprite = eyebrow_spr[2];
                    faceParts_obj[0].SetActive(false);
                }
            }
            else
            {
                faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
                faceParts_obj[6].GetComponent<Image>().sprite = eyeBall_spr[0];
                faceParts_obj[1].GetComponent<Image>().sprite = mouth_spr[0];
                faceParts_obj[2].GetComponent<Image>().sprite = eyes_spr[0];
                faceParts_obj[3].GetComponent<Image>().sprite = ears_spr[0];
                faceParts_obj[4].GetComponent<Image>().sprite = nose_spr[0];
                faceParts_obj[5].GetComponent<Image>().sprite = eyebrow_spr[0];
                faceParts_obj[0].SetActive(true);
                dialog_txt.text = "그런 것은 없어";
            }

        }
    }
    
}
