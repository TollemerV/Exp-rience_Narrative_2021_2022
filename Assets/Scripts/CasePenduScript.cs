using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasePenduScript : MonoBehaviour
{
    public GameObject selectedPage;
    public GameObject objectPlaced;
    public Sprite sprite;
    public BlackBoardController blackBoardController;

    private void Start()
    {
        gameObject.GetComponent<Animator>().SetTrigger("exitPage");
    }

    public void pointerEnter()
    {
        if(selectedPage.GetComponent<SelectedPanelScript>().selectedObject != null)
        {

            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("onPage");
            gameObject.GetComponent<Animator>().ResetTrigger("exitPage");

            changeSprite();
        }
    }

    public void pointerExit() {
        if(objectPlaced != null)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("exitPage");
        }
    }

    public void changeSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = selectedPage.GetComponent<Image>().sprite;
    }

    public void placePage()
    {
        if (selectedPage.GetComponent<SelectedPanelScript>().selectedObject != null)
        {
            if(objectPlaced != null)
            {
                objectPlaced.SetActive(true);
                
            }
            objectPlaced = selectedPage.GetComponent<SelectedPanelScript>().selectedObject;


            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            sprite = selectedPage.GetComponent<Image>().sprite;
            selectedPage.GetComponent<Image>().color = Color.clear;
            
            selectedPage.GetComponent<SelectedPanelScript>().selectedObject.SetActive(false);
            selectedPage.GetComponent<SelectedPanelScript>().selectedObject = null;
            blackBoardController.verifCode();
        }
        else if(objectPlaced!=null)
        {
            objectPlaced.SetActive(true);
            objectPlaced = null;
            sprite = null;
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }

    }
}
