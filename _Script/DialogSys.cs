using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSys : MonoBehaviour
{

    List<Dictionary<string, object>> data;
    public string str, code_str;
    public string face_str;
    public Text dialog_txt;
    public GameObject[] faceParts_obj;
    public Sprite[] eyeBall_spr, mouth_spr, eyes_spr, ears_spr, nose_spr, eyebrow_spr, container_spr;
    public int[] face_i;
    // Start is called before the first frame update
    void Start()
    {

        data = CSVReader.Read("Dialog/satge1");

        /*
        if (data[0][str].Equals("스위치"))
        {

        }
        */

        //각각 값을 불러와서 순서대로 추가
        code_str = code_str + Event.direction;
        code_str = code_str + Event.indexMove;
        code_str = code_str + Event.indexAct;
        //20번 예외처리
        if (Event.indexAct >= 20)
        {
            code_str = "" + Event.indexAct;
        }

        //중요 키값이 있는지 먼저 확인하기 그렇지 않으면 에러발생
        if (data[0].ContainsKey(code_str))
        {
            //대사
            str = "" + data[0][code_str];
            dialog_txt.text = str;
            //표정
            face_str = "" + data[1][code_str];
            
            for (int i = 0; i < 6; i++)
            {
                face_i[i] =  int.Parse(face_str.Substring(i, 1));
            }
            
            if (face_i[0] == 9)
            {
                faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[5];
                faceParts_obj[6].GetComponent<Image>().sprite = eyeBall_spr[5];
                faceParts_obj[1].GetComponent<Image>().sprite = mouth_spr[0];
                faceParts_obj[2].GetComponent<Image>().sprite = eyes_spr[2];
                faceParts_obj[3].GetComponent<Image>().sprite = ears_spr[0];
                faceParts_obj[4].GetComponent<Image>().sprite = nose_spr[0];
                faceParts_obj[5].GetComponent<Image>().sprite = eyebrow_spr[2];
            }
            else
            {
                faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[face_i[0]];
                faceParts_obj[6].GetComponent<Image>().sprite = eyeBall_spr[face_i[0]];
                faceParts_obj[1].GetComponent<Image>().sprite = mouth_spr[face_i[1]];
                faceParts_obj[2].GetComponent<Image>().sprite = eyes_spr[face_i[2]];
                faceParts_obj[3].GetComponent<Image>().sprite = ears_spr[face_i[3]];
                faceParts_obj[4].GetComponent<Image>().sprite = nose_spr[face_i[4]];
                faceParts_obj[5].GetComponent<Image>().sprite = eyebrow_spr[face_i[5]];
            }
            
            
            
        }

        //GetDictonaryValue(data, "스위치");



        /*
        키 가있는 경우 값을 얻으려면 다음을 사용하십시오 Dictionary<TKey, TValue>.TryGetValue.

int value;
if (dictionary.TryGetValue(key, out value))
{
    // Key was in dictionary; "value" contains corresponding value
} 
else 
{
    // Key wasn't in dictionary; "value" is now 0
}
         */
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

        Debug.Log(code_str);
        //중요 키값이 있는지 먼저 확인하기 그렇지 않으면 에러발생
        if (data[0].ContainsKey(code_str))
        {
            //대사
            str = "" + data[0][code_str];
            dialog_txt.text = str;
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
