using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePage : MonoBehaviour
{
    public PlayerControler playerControler;
    public GameObject fondNoire;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            disablePage();
        }
    }

    // Start is called before the first frame update
    public void disablePage()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        transform.parent.gameObject.SetActive(false);
        playerControler.isPause = false;
        fondNoire.SetActive(false);
    }
  
    
}
