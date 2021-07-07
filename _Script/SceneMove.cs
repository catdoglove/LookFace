using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{

    AsyncOperation async;

    Color color;
    public GameObject fade_obj;

    void Start()
    {
        color = fade_obj.GetComponent<Image>().color;
    }
    public void GameStart()
    {
        StartCoroutine("imgFadein");
    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("StageScene");
        while (!async.isDone)
        {
            yield return true;
        }
    }


    IEnumerator imgFadein()
    {
        yield return new WaitForSeconds(0.1f);
        for (float i = 1f; i >= 0f; i -= 0.05f)
        {
            fade_obj.SetActive(true);
            color.a = Mathf.Lerp(1f, 0f, i);
            fade_obj.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }

        fade_obj.GetComponent<Image>().color = Color.black;
        StartCoroutine("Load");
    }

}
