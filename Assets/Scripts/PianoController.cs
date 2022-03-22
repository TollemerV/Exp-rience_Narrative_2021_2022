using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoController: MonoBehaviour
{
    public GameObject cameraPlayer;
    public GameObject ath;
    public PlayerControler playerControler;
    public GameObject cameraPiano;
    bool isUsePiano = false;



    private void Update()
    {
        if (isUsePiano && Input.GetKeyDown(KeyCode.Escape))
        {

            DisablePiano();
            isUsePiano = false;
        }

    }

    public void UsePiano()
    {
        StartCoroutine(UsePianoCoroutine());
        isUsePiano = true;
        
    }
    
    private void DisablePiano()
    {
        cameraPiano.SetActive(false);
        cameraPlayer.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ath.SetActive(true);
        
        gameObject.GetComponent<BoxCollider>().enabled = true;
        playerControler.isPause = false;

    }


    System.Collections.IEnumerator UsePianoCoroutine()
    {
        Vector3 baseCameraPostion = cameraPlayer.transform.position;
        Quaternion baseCameraRotation = cameraPlayer.transform.rotation;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        playerControler.isPause = true; 

        while (cameraPlayer.transform.position != cameraPiano.transform.position)
        {
            cameraPlayer.transform.position = Vector3.MoveTowards(cameraPlayer.transform.position, cameraPiano.transform.position, 0.05f);
            cameraPlayer.transform.rotation = Quaternion.Lerp(cameraPlayer.transform.rotation, cameraPiano.transform.rotation, 0.07f);
            Debug.Log("transformation camera");
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.1f);

        Cursor.visible = true;
        Cursor.lockState = 0;
        cameraPiano.SetActive(true);
        cameraPlayer.SetActive(false);
        cameraPlayer.transform.position = baseCameraPostion;
        cameraPlayer.transform.rotation = baseCameraRotation;
        ath.SetActive(false);

    }
}
