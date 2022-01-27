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
    public GameObject spotLight;
    public Animator porte;
    public Animator tourbillonAnimation;
    public string code;

    


    void Start()
    {
        code = Random.Range(1, 6).ToString() + Random.Range(1, 6).ToString() + Random.Range(1, 6).ToString();
        spotLight.GetComponent<SpotLightController>().code = code;
        Debug.Log(code);
    }


    public void ClickButton(int numero)
    {
        textNumber.gameObject.SetActive(true);

        if (numero== 10)
        {
            if (number == code)
            {
                print("Code Bon");
                StartCoroutine(CodeBon());
                number = "";
                textNumber.text = "";
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

    System.Collections.IEnumerator CodeBon()
    {
        tourbillonAnimation.SetTrigger("Code Bon");
        
        yield return new WaitForSeconds(4f);
        porte.SetTrigger("Code Bon");
    }
}
