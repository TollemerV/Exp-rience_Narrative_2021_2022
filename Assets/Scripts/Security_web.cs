using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Security_web : MonoBehaviour
{

    public GameObject changingTextError;
    public InputField MailSelect;
    public InputField PswSelect;
    public void ValidatePsw()
    {
        if (MailSelect.text == "AZERTY@gmail.com" && PswSelect.text == "R6Z3C7U7S4")
        {
            SceneManager.LoadScene("App_web");
        }
        else
        {
            changingTextError.GetComponent<Text>().text = "Le nom d'utilisateur ou le mot de passe est incorrect";
        }
    }
}
