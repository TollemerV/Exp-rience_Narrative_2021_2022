using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCarried : MonoBehaviour
{
    public RaycastControler raycastControler;

    void Start()
    {
        gameObject.GetComponent<IsCarried>().enabled = false;
    }
     
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name != "DetectionZone" && raycastControler.beingCarried)
        {
            raycastControler.DropObject(transform);
        }
        
    }
    
}
