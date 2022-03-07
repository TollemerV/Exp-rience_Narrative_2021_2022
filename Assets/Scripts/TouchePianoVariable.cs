using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchePianoVariable : MonoBehaviour
{
    public int numTouche;
    public AudioClip toucheClip;
    public AudioSource audioSource;
    public KeyCode code;



    public void OnPointerDown()
    {
        print("touche appuyée!");
        audioSource.PlayOneShot(toucheClip);
        gameObject.GetComponent<Animator>().SetTrigger("push");
    }

    void Update()
    {
        if (Input.GetKeyDown(code))
        {
            OnPointerDown();
        }
    }
}
