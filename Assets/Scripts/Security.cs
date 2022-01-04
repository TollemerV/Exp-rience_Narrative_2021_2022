using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Security : MonoBehaviour
{
    public GameObject changingTextError;
    public InputField PswSelect;
    public void ValidatePsw()
    {
        if (PswSelect.text == "B666a9")
        {
            SceneManager.LoadScene("App_note");
        }
        else
        {
            changingTextError.GetComponent<Text>().text = "Le mot de passe saisi n'est pas correct. Veuillez réessayer.";
        }
    }
}
