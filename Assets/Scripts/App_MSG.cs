using UnityEngine;
using UnityEngine.SceneManagement;

public class App_MSG : MonoBehaviour
{
    public void Open_Chat(string chatNameSelect)
    {
        SceneManager.LoadScene(chatNameSelect);
    }

    public void quitChat()
    {
        SceneManager.LoadScene("App_sms");
    }
}
