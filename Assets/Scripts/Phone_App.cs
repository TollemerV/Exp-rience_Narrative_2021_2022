using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Phone_App : MonoBehaviour
{
    public void BackAllApp()
    {
        SceneManager.LoadScene("Phone_Menu");
    }

    public void onBtn(Button btn)
    {
        btn.image.color = new Color(255f, 255f, 255f, .5f);
    }
    public void leaveBtn(Button btn)
    {
        btn.image.color = new Color(255f, 255f, 255f, 1f);
    }

    public void onMenuBtn(Image btn)
    {
        btn.color = new Color(255f, 255f, 255f, .5f);
    }
    public void leaveMenuBtn(Image btn)
    {
        btn.color = new Color(255f, 255f, 255f, 1f);
    }

}
