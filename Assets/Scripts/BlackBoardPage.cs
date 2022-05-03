using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBoardPage : MonoBehaviour
{
    public GameObject selectedPage;
    public bool isPlaced;
    public bool isSelected;
    public string letter;
    

 

    public void showPage()
    {
        selectedPage.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        selectedPage.GetComponent<Image>().color = Color.white;
        isSelected = true;
        selectedPage.GetComponent<SelectedPanelScript>().selectedObject = gameObject;
    }
}
