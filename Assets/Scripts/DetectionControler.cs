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
    public GameObject inventory;

    bool isOpen = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            DisplayMessage();

            if (CheckKey() && Input.GetKey(KeyCode.F))
            {
                if (!isOpen)
                {

                    doorRotation.SetTrigger("OpenDoor");
                    StartCoroutine(CorroutineOpenDoor());
                    Destroy(key);
                    //transform.parent.gameObject.SetActive(false);
                    haveKeyText.gameObject.SetActive(false);
                    isOpen = true;
                    transform.gameObject.SetActive(false);
                }
            }
        }
        
    }

    void OnTriggerExit()
    {
        if (CheckKey())
        {
            haveKeyText.gameObject.SetActive(false);
        }
        else
        {
            missingKeyText.gameObject.SetActive(false);
        }
        haveKey = false;
    }

    IEnumerator CorroutineOpenDoor()
    {
        yield return new WaitForSeconds(1f);
        fadeSystem.SetTrigger("FadeIn");
    }

    public bool CheckKey()
    {
        if (inventory.transform.childCount > 0)
        {
            int i = 0;
            do
            {
                Transform item = inventory.transform.GetChild(i);
                if (item.GetComponent<ItemSlots>().itemID == "001")
                {
                    key = item.gameObject;
                    return true;

                }
                i += 1;
            } while (i < inventory.transform.childCount);
        }
        

        return false;
    }

    private void DisplayMessage()
    {
        if (CheckKey())
        {
            haveKeyText.gameObject.SetActive(true);
            missingKeyText.gameObject.SetActive(false);
        }
        else
        {
            haveKeyText.gameObject.SetActive(false);
            missingKeyText.gameObject.SetActive(true);
        }
    }
}



