using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject player;

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<Movement>().isPause = false;
    }
}
