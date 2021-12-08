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

    void OnTriggerStay()
    {
        if (key != null && Input.GetKey(KeyCode.F))
        {
            transform.parent.gameObject.SetActive(false);
            haveKeyText.gameObject.SetActive(false);
            key.SetActive(false);
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
}
