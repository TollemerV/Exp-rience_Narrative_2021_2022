using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionControler : MonoBehaviour
{
    public GameObject key;
    public Text missingKeyText;
    public Text haveKeyText;
    public bool haveKey = false;
    public Animator fadeSystem;
    public Animator doorRotation;

    void OnTriggerEnter()
    {
        if (!haveKey)
        {
            missingKeyText.gameObject.SetActive(true);
        }
        else
        {
            haveKeyText.gameObject.SetActive(true);
        }
        
    }

    bool isOpen = false;

    void OnTriggerStay()
    {

        if (key != null && Input.GetKey(KeyCode.F))
        {
            if (!isOpen)
            {
                
                doorRotation.SetTrigger("OpenDoor");
                StartCoroutine(CorroutineOpenDoor());
                
                
                
                key.SetActive(false);
                //transform.parent.gameObject.SetActive(false);
                haveKeyText.gameObject.SetActive(false);
                isOpen = true;
            }
        }
    }

    void OnTriggerExit()
    {
        if (!haveKey)
        {
            missingKeyText.gameObject.SetActive(false);
        }
        else
        {
            haveKeyText.gameObject.SetActive(false);
        }
    }

    IEnumerator CorroutineOpenDoor()
    {
        yield return new WaitForSeconds(1f);
        fadeSystem.SetTrigger("FadeIn");
    }
}


