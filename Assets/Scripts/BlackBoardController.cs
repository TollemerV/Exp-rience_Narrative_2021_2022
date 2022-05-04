using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBoardController : MonoBehaviour
{
    private Transform _selection;
    public Text textDisplayed;
    public GameObject player;
    public GameObject cameraPlayer;
    public GameObject blackBoardCamera;
    public Collider blackBoardCollider;
    public GameObject ath;
    public GameObject pageUI;
    public GameObject selectedPageUI;
    private bool isUseBlackBoard = false;


    public GameObject[] allCase= {};

    void Update()
    {
        if (isUseBlackBoard && Input.GetKeyDown(KeyCode.Escape))
        {
            quitBlackBoard();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_selection != null)
        {
            textDisplayed.gameObject.SetActive(false);
            _selection = null;
        }

        RaycastHit hit;
        if (other.name == "Player" && Physics.Raycast(other.transform.GetChild(0).position, other.transform.GetChild(0).forward, out hit, 2.5f))
        {
            var selection = hit.transform;
            if (selection.gameObject == gameObject)
            {
                textDisplayed.text = "Appuyer sur [E] pour utiliser le tableau";
                textDisplayed.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Use Black board!");
                    textDisplayed.gameObject.SetActive(false);
                    StartCoroutine(useBlackBoardCoroutine());
                    isUseBlackBoard = true;
                    
                }
            }
            _selection = selection;
                
        }

        
       
    }

    private void OnTriggerExit(Collider other)
    {
        textDisplayed.gameObject.SetActive(false);
    }

    private void quitBlackBoard()
    {
        blackBoardCamera.SetActive(false);
        cameraPlayer.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ath.SetActive(true);
        pageUI.SetActive(false);
        selectedPageUI.SetActive(false);
        isUseBlackBoard = false;
        StartCoroutine(waitIsPause());
        player.GetComponent<MeshRenderer>().enabled = true;
        foreach (Collider collider in gameObject.GetComponents<Collider>())
        {
            collider.enabled = true;
        }
    }

    System.Collections.IEnumerator useBlackBoardCoroutine()
    {
        player.GetComponent<MeshRenderer>().enabled = false;
        Vector3 baseCameraPostion = cameraPlayer.transform.position;
        Quaternion baseCameraRotation = cameraPlayer.transform.rotation;
        foreach (Collider collider in  gameObject.GetComponents<Collider>())
        {
            collider.enabled = false;
        }
        player.GetComponent<PlayerControler>().isPause = true;
        while (cameraPlayer.transform.position != blackBoardCamera.transform.position)
        {
            cameraPlayer.transform.position = Vector3.MoveTowards(cameraPlayer.transform.position, blackBoardCamera.transform.position, 0.05f);
            cameraPlayer.transform.rotation = Quaternion.Lerp(cameraPlayer.transform.rotation, blackBoardCamera.transform.rotation, 0.07f);
            yield return new WaitForEndOfFrame();
        }
        
        yield return new WaitForSeconds(0.1f);
        Cursor.visible = true;
        Cursor.lockState = 0;
        blackBoardCamera.SetActive(true);
        cameraPlayer.SetActive(false);
        cameraPlayer.transform.position = baseCameraPostion;
        cameraPlayer.transform.rotation = baseCameraRotation;
        
        ath.SetActive(false);
        pageUI.SetActive(true);
        selectedPageUI.SetActive(true);
    }

    public void verifCode()
    {
        string res = "";
        foreach (GameObject caseBoard in allCase)
        {
            if (caseBoard.GetComponent<CasePenduScript>().objectPlaced)
            {
                res += caseBoard.GetComponent<CasePenduScript>().objectPlaced.GetComponent<BlackBoardPage>().letter;
            }
        }
        if (res == "ARTHUR")
        {
            quitBlackBoard();
            foreach (Collider collider in gameObject.GetComponents<Collider>())
            {
                collider.enabled = false;
            }

        }
        
    }

    System.Collections.IEnumerator waitIsPause()
    {
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerControler>().isPause = false;
    }
}

