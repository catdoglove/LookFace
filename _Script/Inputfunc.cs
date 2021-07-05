using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inputfunc : MonoBehaviour, ISelectHandler
{
    public InputField f;
    //임시 글자수 제한 한글 10개 영어 18개
    //영어와 한글만 입력가능하게 만들기
    /*
    public void click()
    {
        f.ActivateInputField();
        StartCoroutine(end_text());
    }
    IEnumerator end_text()
    {
        yield return 0;
        f.MoveTextEnd(false);
    }
    */

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {

            Debug.Log("a");
        }
        */



        /*
            if (Input.GetKeyDown(KeyCode.Return))
        {

            if (this.gameObject.GetComponent<InputField>().isFocused == true)
            {
                Debug.Log("a");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }

        */
        //f.selectionFocusPosition = f.selectionAnchorPosition;
        this.gameObject.GetComponent<InputField>().selectionFocusPosition = this.gameObject.GetComponent<InputField>().selectionAnchorPosition;
    }


    //Do this when the selectable UI object is selected.
    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " was selected");
        StartCoroutine(end_text());
    }

    IEnumerator end_text()
    {
        yield return 0;
        this.gameObject.GetComponent<InputField>().MoveTextEnd(true);
    }

    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        , IPointerDownHandler
        Debug.Log("The mouse click was released");
        //this.gameObject.GetComponent<InputField>().selectionAnchorPosition = this.gameObject.GetComponent<InputField>().selectionFocusPosition;
        StartCoroutine(end_text2());
    }
    */



    IEnumerator end_text2()
    {
        yield return 0;
        
    }

}
