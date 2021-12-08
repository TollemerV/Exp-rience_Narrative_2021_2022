using UnityEngine;
using UnityEngine.SceneManagement;

public class App_FCts : MonoBehaviour
{
    public void Open_FicheContact(string contactNameSelect)
    {
        SceneManager.LoadScene(contactNameSelect);
    }

    public void quitFCt()
    {
        SceneManager.LoadScene("App_sms");
    }
}
