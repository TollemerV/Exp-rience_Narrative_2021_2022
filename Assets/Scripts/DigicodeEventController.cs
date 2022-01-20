using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigicodeEventController : MonoBehaviour
{
    public Material defaultMaterial;
    public Material onClickMaterial;
    public Text textNumber;
    public string number;

    

    public void ClickButton(int numero)
    {
        textNumber.gameObject.SetActive(true);

        if (numero== 10)
        {
            if (number == "123")
            {
                print("Code Bon");
            }
            else
            {
                print("Mauvais code");
            }
        }
        else if (numero == 11)
        {
            print("annulé");
            number = "";
            textNumber.text = "";
        }
        else
        {
            if (number.Length < 3)
            {
                number += numero.ToString();
                textNumber.text = number;
            }
        }
    }

    public void OnPointerDown(GameObject objet)
    {
        objet.GetComponent<Renderer>().material = onClickMaterial;
    }

    public void OnPointerUp(GameObject objet)
    {
        objet.GetComponent<Renderer>().material = defaultMaterial;
    }
}
