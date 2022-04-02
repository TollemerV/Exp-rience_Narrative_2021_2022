using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBoardController : MonoBehaviour
{
    private Transform _selection;
    public Text textDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                textDisplayed.text = "Appuyer sur E pour utiliser le tableau";
                textDisplayed.gameObject.SetActive(true);
            }
            _selection = selection;
                
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        textDisplayed.gameObject.SetActive(false);
    }

}
