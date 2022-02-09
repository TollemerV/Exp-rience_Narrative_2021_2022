using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionControler : MonoBehaviour
{
    public GameObject key;
    public Text missingKeyText;
    public Text openDoorText;
    public Text closeDoorText;
    public bool haveKey = false;
    public string location;
    [SerializeField] Animator proximityDoor = null;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool isRunning = false;


    void OnTriggerEnter()
    {
        //proximityDoor = GameObject.Find("DoorRotation_" + location);

        if (!haveKey)
        {
            missingKeyText.gameObject.SetActive(true);
        }
        else
        {
            if (!isOpen)
            {
                openDoorText.gameObject.SetActive(true);
            }
            else
            {
                closeDoorText.gameObject.SetActive(true);
            }
        }
        
    }

    void OnTriggerStay()
    {
        if (key != null && Input.GetKey(KeyCode.F) && !isRunning)
        {
            if (!proximityDoor.GetCurrentAnimatorStateInfo(0).IsName("OpenDoor_" + location))
            {
                StartCoroutine(openDoor());
            }
            else
            {
                StartCoroutine(closeDoor());
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
            if (!isOpen)
            {
                openDoorText.gameObject.SetActive(false);
            }
            else
            {
                closeDoorText.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator openDoor()
    {
        isRunning = true;
        openDoorText.gameObject.SetActive(false);
        proximityDoor.SetTrigger("OpenDoor_" + location);
        Debug.Log("OpenDoor_" + location);
        //doorRotation
        proximityDoor.Play("OpenDoor_" + location);
        key.SetActive(false);
        isOpen = true;
        yield return new WaitForSeconds(1);
        closeDoorText.gameObject.SetActive(true);
        isRunning = false;
        yield break;
    }

    IEnumerator closeDoor()
    {
        closeDoorText.gameObject.SetActive(false);
        isRunning = true;
        proximityDoor.Play("CloseDoor_" + location);
        isOpen = false;
        yield return new WaitForSeconds(1);
        isRunning = false;
        openDoorText.gameObject.SetActive(true);
        yield break;
    }
}


