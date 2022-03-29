using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchePianoVariable : MonoBehaviour
{
    public int numTouche;
    public AudioClip toucheClip;
    public AudioSource audioSource;
    public KeyCode code;
    public PianoController pianoController;



    public void OnPointerDown()
    {
        audioSource.PlayOneShot(toucheClip);
        gameObject.GetComponent<Animator>().SetTrigger("push");
        pianoController.isUsePianoKey = true;
        pianoController.melodyTime = 0;
        pianoController.melodyPlayed.Add(numTouche);
    }

    void Update()
    {

        if (Input.GetKeyDown(code))
        {
            OnPointerDown();
        }
    }
}
