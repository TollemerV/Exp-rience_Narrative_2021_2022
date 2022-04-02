using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventControler : MonoBehaviour
{
    public GameObject blackBoard;


    private void Start()
    {
        PageEvent(0);
    }

    public void PageEvent(int numberPage)
    {
        print("état " + numberPage.ToString());

        if (numberPage == 6)
        {
            Collider[] blackBoardColliders = blackBoard.GetComponents<Collider>();

            for(int i = 0; i<blackBoardColliders.Length; i++)
            {
                blackBoardColliders[i].enabled = true;
            }
            
            Debug.Log("collider activé");
        }
    }
}
