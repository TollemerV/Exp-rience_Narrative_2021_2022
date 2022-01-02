using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Phone_click : MonoBehaviour
{
    public void Start_App(string appNameSelect)
    {
        SceneManager.LoadScene(appNameSelect);
    }

    public void OnMouseOver(Image img)
    {
        img.enabled = true;
    }

    public void OnMouseExit(Image img)
    {
        img.enabled = false;
    }

    public void OnMouseOver_(RawImage Rimg)
    {
        Rimg.enabled = true;
    }

    public void OnMouseExit_(RawImage Rimg)
    {
        Rimg.enabled = false;
    }

}
