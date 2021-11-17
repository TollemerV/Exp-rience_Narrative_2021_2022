using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public GameObject player;
    public Sprite img;

    public void AddInventory(GameObject objet)
    {
        player.GetComponent<Material>();
        if (!inventory.Contains(objet))
        {
            inventory.Add(objet);
            objet.SetActive(false);
        }
        
    }
    public void DisableInventory()
    {
        StartCoroutine(CoroutineDisableInventory());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            DisableInventory();
        }
    }

    

    System.Collections.IEnumerator CoroutineDisableInventory()
    {
        
        
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
        player.GetComponent<Movement>().isPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
