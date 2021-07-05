using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvt : MonoBehaviour
{
    public AudioSource se_move, se_switch, se_button, se_door, se_broken, se_talk;
    public AudioClip sp_move, sp_switch, sp_button, sp_door, sp_broken, sp_talk;

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
    /// <summary>
    /// 부서지는 소리
    /// </summary>
    public void TalkSound()
    {
        se_talk = gameObject.GetComponent<AudioSource>();
        se_talk.clip = sp_talk;
        se_talk.loop = false;
        se_talk.Play();
    }

}
