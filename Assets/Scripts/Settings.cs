using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Settings : MonoBehaviour
{
    public Dropdown DpResolution;

    public void SetResolution()
    {
        switch (DpResolution.value)
        {
            case 0:
                Screen.SetResolution(640, 360, true);
                break;

            case 1:
                Screen.SetResolution(720, 480, true);
                break;

            case 2:
                Screen.SetResolution(1270, 720, true);
                break;

            case 3:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
