using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoController: MonoBehaviour
{
    public GameObject cameraPlayer;
    public GameObject ath;
    public GameObject player;
    public GameObject cameraPiano;
    bool isUsePiano = false;
    public float melodyTime = 0;
    public bool isUsePianoKey;
    public AudioSource audioSource;
    public AudioClip melody1;
    public Collider cantPlayCollider;
    public List<int> melodyPlayed ;
    private List<int> melodyValues = new List<int> {5,5,4,2,6,5 };
    private bool findMelody;

   

    private void Update()
    {


        if (!audioSource.isPlaying)
        {
            melodyTime += Time.deltaTime;
            cantPlayCollider.enabled = false;
        }


        if (isUsePiano && Input.GetKeyDown(KeyCode.Escape))
        {
            DisablePiano();
            isUsePiano = false;
        }

        if (Verify(melodyPlayed, melodyValues) && !findMelody)
        {
            DisablePiano();
            isUsePiano = false;
            findMelody = true;
        }


        if (melodyTime >= 2 && isUsePianoKey && !findMelody)
        {
            melodyTime = 0;
            isUsePianoKey = false;
            audioSource.PlayOneShot(melody1);
            cantPlayCollider.enabled = true;
            melodyPlayed.Clear();
        }

        if (melodyTime >= 5 && !findMelody)
        {
            melodyTime = 0;
            audioSource.PlayOneShot(melody1);
            cantPlayCollider.enabled = true;
            melodyPlayed.Clear();
        }



    }

    public void UsePiano()
    {
        if (!findMelody)
        {
            StartCoroutine(UsePianoCoroutine());
            isUsePiano = true;
        }
        
        
    }
    
    private void DisablePiano()
    {
        cameraPiano.SetActive(false);
        cameraPlayer.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ath.SetActive(true);
        
        gameObject.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(WaitDisable());

    }

    private bool Verify(List<int> melodyPlayed, List<int> melody)
    {
        if (melodyPlayed.Count != melody.Count)
        {
            return false;
        }
        for (int i =0; i<melody.Count; i++)
        {
            if(melody[i] != melodyPlayed[i])
            {
                return false;
            }
        }
        return true;

    }

    

    System.Collections.IEnumerator WaitDisable()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerControler>().isPause = false;

    }

    System.Collections.IEnumerator UsePianoCoroutine()
    {
        Vector3 baseCameraPostion = cameraPlayer.transform.position;
        Quaternion baseCameraRotation = cameraPlayer.transform.rotation;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        

        while (cameraPlayer.transform.position != cameraPiano.transform.position)
        {
            cameraPlayer.transform.position = Vector3.MoveTowards(cameraPlayer.transform.position, cameraPiano.transform.position, 0.05f);
            cameraPlayer.transform.rotation = Quaternion.Lerp(cameraPlayer.transform.rotation, cameraPiano.transform.rotation, 0.07f);
            yield return new WaitForEndOfFrame();
        }
        player.GetComponent<PlayerControler>().isPause = true;
        yield return new WaitForSeconds(0.1f);
        Cursor.visible = true;
        Cursor.lockState = 0;
        cameraPiano.SetActive(true);
        cameraPlayer.SetActive(false);
        cameraPlayer.transform.position = baseCameraPostion;
        cameraPlayer.transform.rotation = baseCameraRotation;
        ath.SetActive(false);

    }






}
