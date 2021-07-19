using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceEvent : MonoBehaviour
{
    //얼굴
    public GameObject[] faceParts_obj;
    public Sprite[] eyeBall_spr, mouth_spr, eyes_spr, ears_spr, nose_spr, eyebrow_spr, body_spr, eyesMask_spr;

    void Start()
    {
        
    }
    
    /// <summary>
    /// 아이탬 획득 살짝 웃음
    /// </summary>
    public void GetItemFace()
    {
        faceParts_obj[0].SetActive(true);
        faceParts_obj[1].SetActive(true);
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[1];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[0];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[0];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[0];
        faceParts_obj[8].GetComponent<Image>().sprite = eyesMask_spr[0];
        //faceParts_obj[0].
        //faceParts_obj[6].
    }

    /// <summary>
    /// 기본
    /// </summary>
    public void NomalFace()
    {
        faceParts_obj[0].SetActive(true);
        faceParts_obj[1].SetActive(true);
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[0];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[0];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[0];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[0];
        faceParts_obj[8].GetComponent<Image>().sprite = eyesMask_spr[0];
        moven();
        moveM();
        //faceParts_obj[0].
        //faceParts_obj[6].
    }

    /// <summary>
    /// 대화 이밴트 놀람
    /// </summary>
    public void SurprisedFace()
    {
        moves();
        faceParts_obj[0].SetActive(true);
        faceParts_obj[1].SetActive(true);
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[2];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[1];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[1];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[0];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[3];
        faceParts_obj[8].GetComponent<Image>().sprite = eyesMask_spr[1];
    }

    /// <summary>
    /// 대화 이밴트 걱정
    /// </summary>
    public void WorryFace()
    {
        faceParts_obj[0].SetActive(true);
        faceParts_obj[1].SetActive(true);
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[5];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[0];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[1];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[2];
        faceParts_obj[8].GetComponent<Image>().sprite = eyesMask_spr[0];
        //faceParts_obj[0].
    }

    /// <summary>
    /// 대화 이밴트 안심
    /// </summary>
    public void RelaxFace()
    {
        faceParts_obj[0].SetActive(false);
        faceParts_obj[1].SetActive(false);
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[4];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[3];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[1];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[4];
        faceParts_obj[8].GetComponent<Image>().sprite = eyesMask_spr[3];
    }

    /// <summary>
    /// 대화 이밴트 생각중
    /// </summary>
    public void ThinkFace()
    {
        faceParts_obj[0].SetActive(false);
        faceParts_obj[1].SetActive(false);
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[3];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[3];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[0];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[1];
        faceParts_obj[8].GetComponent<Image>().sprite = eyesMask_spr[3];
    }



    public void moves()
    {
        Vector3 position = faceParts_obj[0].transform.localPosition;
        position.y = 0.3f;
        faceParts_obj[0].transform.localPosition = position;

        Vector3 position2 = faceParts_obj[1].transform.localPosition;
        position2.y = 0.3f;
        faceParts_obj[1].transform.localPosition = position2;

        Vector3 position3 = faceParts_obj[6].transform.localPosition;
        position3.y = 241.86f;
        faceParts_obj[6].transform.localPosition = position3;
    }

    public void moven()
    {
        Vector3 position = faceParts_obj[0].transform.localPosition;
        position.y = -12.06004f;
        faceParts_obj[0].transform.localPosition = position;

        Vector3 position2 = faceParts_obj[1].transform.localPosition;
        position2.y = -12.06004f;
        faceParts_obj[1].transform.localPosition = position2;
        
        Vector3 position3 = faceParts_obj[6].transform.localPosition;
        position3.y = 232.87f;
        faceParts_obj[6].transform.localPosition = position3;
    }


    public void moveL()
    {
        Vector3 position = faceParts_obj[0].transform.localPosition;
        position.x = -74.9f;
        faceParts_obj[0].transform.localPosition = position;

        Vector3 position2 = faceParts_obj[1].transform.localPosition;
        position2.x = 41.3f;
        faceParts_obj[1].transform.localPosition = position2;

    }
    public void moveM()
    {
        Vector3 position = faceParts_obj[0].transform.localPosition;
        position.x = -53.4f;
        faceParts_obj[0].transform.localPosition = position;

        Vector3 position2 = faceParts_obj[1].transform.localPosition;
        position2.x = 47.8f;
        faceParts_obj[1].transform.localPosition = position2;

    }
    public void moveR()
    {
        Vector3 position = faceParts_obj[0].transform.localPosition;
        position.x = -46.45f;
        faceParts_obj[0].transform.localPosition = position;

        Vector3 position2 = faceParts_obj[1].transform.localPosition;
        position2.x = 66.09f;
        faceParts_obj[1].transform.localPosition = position2;

    }


    public void moveD()
    {
        Vector3 position = faceParts_obj[0].transform.localPosition;
        position.y =-17.4f;
        faceParts_obj[0].transform.localPosition = position;

        Vector3 position2 = faceParts_obj[1].transform.localPosition;
        position2.y =-17.4f;
        faceParts_obj[1].transform.localPosition = position2;

    }


}
