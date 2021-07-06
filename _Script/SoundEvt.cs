using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvt : MonoBehaviour
{
    public AudioSource se_move, se_switch, se_button, se_door, se_broken, se_talk, se_talkm, se_UImain, se_arrowdlg, se_keyboard, se_typing, 
        se_falling, se_act, se_get, se_waterdrop, se_remote, se_menu;
    public AudioClip sp_move, sp_switch, sp_button, sp_door, sp_broken, sp_talk, sp_talkm, sp_UImain, sp_arrowdlg, sp_keyboard, sp_typing, 
        sp_falling, sp_act, sp_get, sp_waterdrop, sp_remote, sp_menu;

    public AudioSource BGM, BGS;
    float BGMVol_f, BGSVol_f;
    // Use this for initialization
    void Start()
    {
        /*
        if (PlayerPrefs.GetInt("titlesets", 0) == 1)
        {
            BGSVol_f = PlayerPrefs.GetFloat("bgs", 1f);
            BGS.volume = BGSVol_f;
            PlayerPrefs.SetInt("titlesets", 0);
        }
        */
    }
    
    /// <summary>
    /// 발걸음소리
    /// </summary>
    public void MoveSound()
    {
        se_move = gameObject.GetComponent<AudioSource>();
        se_move.clip = sp_move;
        se_move.loop = false;
        se_move.Play();
    }

    /// <summary>
    /// 스위치소리
    /// </summary>
    public void SwitchSound()
    {
        se_switch = gameObject.GetComponent<AudioSource>();
        se_switch.clip = sp_switch;
        se_switch.loop = false;
        se_switch.Play();
    }

    /// <summary>
    /// 버튼소리
    /// </summary>
    public void ButtonSound()
    {
        se_button = gameObject.GetComponent<AudioSource>();
        se_button.clip = sp_button;
        se_button.loop = false;
        se_button.Play();
    }

    /// <summary>
    /// 문여는 소리
    /// </summary>
    public void DoorSound()
    {
        se_door = gameObject.GetComponent<AudioSource>();
        se_door.clip = sp_door;
        se_door.loop = false;
        se_door.Play();
    }

    /// <summary>
    /// 부서지는 소리
    /// </summary>
    public void BrokenSound()
    {
        se_broken = gameObject.GetComponent<AudioSource>();
        se_broken.clip = sp_broken;
        se_broken.loop = false;
        se_broken.Play();
    }

    // 말하는 소리
    public void TalkSound()
    {
        se_talk = gameObject.GetComponent<AudioSource>();
        se_talk.clip = sp_talk;
        se_talk.loop = false;
        se_talk.Play();
    }


    /// <summary>
    /// 화살표버튼소리
    /// </summary>
    public void ArrowSound()
    {
        se_arrowdlg = gameObject.GetComponent<AudioSource>();
        se_arrowdlg.clip = sp_arrowdlg;
        se_arrowdlg.loop = false;
        se_arrowdlg.Play();
    }

    //거울 말하는 소리
    public void TalkMirrorSound()
    {
        se_talkm = gameObject.GetComponent<AudioSource>();
        se_talkm.clip = sp_talkm;
        se_talkm.loop = false;
        se_talkm.Play();
    }

    //4개 주요 버튼 소리
    public void UIMainSound()
    {
        se_UImain = gameObject.GetComponent<AudioSource>();
        se_UImain.clip = sp_UImain;
        se_UImain.loop = false;
        se_UImain.Play();
    }


    //키보드소리
    public void keboardSound()
    {
        se_keyboard = gameObject.GetComponent<AudioSource>();
        se_keyboard.clip = sp_keyboard;
        se_keyboard.loop = false;
        se_keyboard.Play();
    }

    //타이핑 효과음
    public void typingSound()
    {
        se_typing = gameObject.GetComponent<AudioSource>();
        se_typing.clip = sp_typing;
        se_typing.loop = false;
        se_typing.Play();
    }


    //떨어지는 소리
    public void fallingSound()
    {
        se_falling = gameObject.GetComponent<AudioSource>();
        se_falling.clip = sp_falling;
        se_falling.loop = false;
        se_falling.Play();
    }


    //분해조합소리
    public void actSound()
    {
        se_act = gameObject.GetComponent<AudioSource>();
        se_act.clip = sp_act;
        se_act.loop = false;
        se_act.Play();
    }


    //얻는 소리
    public void getSound()
    {
        se_get = gameObject.GetComponent<AudioSource>();
        se_get.clip = sp_get;
        se_get.loop = false;
        se_get.Play();
    }

    //물 떨어지는 소리
    public void waterdropSound()
    {
        se_waterdrop = gameObject.GetComponent<AudioSource>();
        se_waterdrop.clip = sp_waterdrop;
        se_waterdrop.loop = false;
        se_waterdrop.Play();
    }

    //리모컨 소리
    public void remoteSound()
    {
        se_remote = gameObject.GetComponent<AudioSource>();
        se_remote.clip = sp_remote;
        se_remote.loop = false;
        se_remote.Play();
    }

    //메뉴관련 소리
    public void menuSound()
    {
        se_menu = gameObject.GetComponent<AudioSource>();
        se_menu.clip = sp_menu;
        se_menu.loop = false;
        se_menu.Play();
    }

}
