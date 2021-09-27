using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EventMaker : MonoBehaviour
{
    string fullPth = "Assets/txt/eventsave";
    StreamWriter sw;


    //얼굴
    public GameObject[] faceParts_obj;
    public Sprite[] eyeBall_spr, mouth_spr, eyes_spr, ears_spr, nose_spr, eyebrow_spr, body_spr, eyesMask_spr;
    public int eyeBall_i, mouth_i, eyes_i, ears_i, nose_i, eyebrow_i, body_i, eyesMask_i, event_i;
    public GameObject body_obj;
    public Text Event_txt;

    StreamReader reader;
    public string value;
    public string[] event_str, mouth_str;

    // Start is called before the first frame update
    void Start()
    {

        if (false == File.Exists(fullPth))
        {
            reader = new StreamReader(fullPth + ".txt");
            value = reader.ReadToEnd();
            reader.Close();
            event_str = value.Split('s');

            mouth_str = event_str[1].Split('m');
            mouth_i = int.Parse(mouth_str[1]);
            faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[mouth_i];
        }
    }
    

    public void SaveEvent()
    {
        if (false == File.Exists(fullPth))
        {
            sw = new StreamWriter(fullPth + ".txt");
        }

        for (int i = 1; i < 7; i++)
        {
            sw.WriteLine("s" + event_str[i]);
            sw.Flush();
        }
        sw.Close();
    }

    public void MouthN()
    {
        mouth_i++;
        if (mouth_i>5)
        {
            mouth_i = 0;
        }
        event_str[event_i + 1] = event_i + "m" + mouth_i;
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[mouth_i];
    }
    public void MouthB()
    {
        mouth_i--;
        if (mouth_i < 0)
        {
            mouth_i = 5;
        }
        event_str[event_i + 1] = event_i + "m" + mouth_i;
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[mouth_i];
    }
    public void EventN()
    {
        event_i++;
        if (event_i > 5)
        {
            event_i = 0;
        }
        Event_txt.text = "" + event_i;
        mouth_str = event_str[event_i+1].Split('m');
        mouth_i = int.Parse(mouth_str[1]);
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[mouth_i];
    }
    public void EventB()
    {
        event_i--;
        if (event_i < 0)
        {
            event_i = 5;
        }
        Event_txt.text = "" + event_i;
        mouth_str = event_str[event_i + 1].Split('m');
        mouth_i = int.Parse(mouth_str[1]);
        faceParts_obj[2].GetComponent<Image>().sprite = mouth_spr[mouth_i];
    }
}
