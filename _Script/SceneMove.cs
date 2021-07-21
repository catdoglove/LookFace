using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{

    AsyncOperation async;

    Color color, colorL, colorLB;
    public GameObject fade_obj, logo_obj, logoB_obj;

    void Start()
    {
        color = fade_obj.GetComponent<Image>().color;
        colorL=logo_obj.GetComponent<Image>().color;
        colorLB = logoB_obj.GetComponent<Image>().color;
        StartCoroutine("imgFadein");
    }
    public void GameStart()
    {
        StartCoroutine("BFadein");
    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("StageScene");
        while (!async.isDone)
        {
            yield return true;
        }
    }


    IEnumerator BFadein()
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


    IEnumerator imgFadeOut()
    {

        yield return new WaitForSeconds(2f);
        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            logo_obj.SetActive(true);
            colorL.a = Mathf.Lerp(0f, 1f, i);
            logo_obj.GetComponent<Image>().color = colorL;
            yield return new WaitForSeconds(0.05f);
        }
        logo_obj.SetActive(false);
        StartCoroutine("LogoBFadeOut");
    }

    IEnumerator imgFadein()
    {
        
        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            logo_obj.SetActive(true);
            colorL.a = Mathf.Lerp(1f, 0f, i);
            logo_obj.GetComponent<Image>().color = colorL;
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine("imgFadeOut");
    }

    IEnumerator LogoBFadeOut()
    {

        yield return new WaitForSeconds(1f);
        for (float i = 1f; i > 0f; i -= 0.05f)
        {
            logoB_obj.SetActive(true);
            colorLB.a = Mathf.Lerp(0f, 1f, i);
            logoB_obj.GetComponent<Image>().color = colorLB;
            yield return new WaitForSeconds(0.05f);
        }
        logoB_obj.SetActive(false);
    }

}
