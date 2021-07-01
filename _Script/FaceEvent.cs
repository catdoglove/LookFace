using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceEvent : MonoBehaviour
{
    //얼굴
    public GameObject[] faceParts_obj;
    public Sprite[] eyeBall_spr, mouth_spr, eyes_spr, ears_spr, nose_spr, eyebrow_spr, body_spr;

    void Start()
    {
        
    }
    
    /// <summary>
    /// 아이탬 획득 살짝 웃음
    /// </summary>
    public void GetItemFace()
    {
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[1];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[0];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[0];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[0];
        //faceParts_obj[0].
        //faceParts_obj[6].
    }

    /// <summary>
    /// 대화 이밴트 놀람
    /// </summary>
    public void SurprisedFace()
    {
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[2];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[1];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[0];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[3];
    }

    /// <summary>
    /// 대화 이밴트 걱정
    /// </summary>
    public void WorryFace()
    {
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[5];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[1];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[1];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[2];
        //faceParts_obj[0].
    }

    /// <summary>
    /// 대화 이밴트 안심
    /// </summary>
    public void RelaxFace()
    {
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[4];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[3];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[1];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[4];
    }

    /// <summary>
    /// 대화 이밴트 생각중
    /// </summary>
    public void ThinkFace()
    {
        faceParts_obj[0].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[1].GetComponent<Image>().sprite = eyeBall_spr[0];
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[3];
        faceParts_obj[3].GetComponent<Image>().sprite = eyes_spr[3];
        faceParts_obj[4].GetComponent<Image>().sprite = ears_spr[0];
        faceParts_obj[5].GetComponent<Image>().sprite = nose_spr[0];
        faceParts_obj[6].GetComponent<Image>().sprite = eyebrow_spr[0];
        faceParts_obj[7].GetComponent<Image>().sprite = body_spr[1];
    }
}
