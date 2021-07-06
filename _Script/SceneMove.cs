using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{

    AsyncOperation async;

    //업적
    public GameObject achievement_obj;
    public float moveX, moveY;

    //타이틀
    public GameObject title_obj;

    void Start()
    {
    }
    public void GameStart()
    {
        StartCoroutine("Load");
    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("SubLoad");
        while (!async.isDone)
        {
            yield return true;
        }
    }
}
