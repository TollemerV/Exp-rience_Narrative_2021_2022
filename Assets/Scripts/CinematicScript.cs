using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicScript : MonoBehaviour
{
    public Animator fadeSystem;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(waitEndCinematic());

    }


    System.Collections.IEnumerator waitEndCinematic()
    {
        yield return new WaitForSeconds(15);
        gameObject.GetComponent<Animator>().SetTrigger("trigger");
        yield return new WaitForSeconds(1.9f);
        SceneManager.LoadScene("Eliott");
        fadeSystem.SetTrigger("FadeIn");
    }
}
