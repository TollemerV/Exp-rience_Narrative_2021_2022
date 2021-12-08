using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public GameObject player;
    public Transform inventorySlots;
    public Transform itemPrefab;
    public int slotsCount;
    public GameObject DoorOne;

    public void AddInventory(GameObject objet)
    {
        player.GetComponent<Material>();
        if (!inventory.Contains(objet) && inventorySlots.childCount<slotsCount)
        {
            inventory.Add(objet);
            objet.SetActive(false);
            Transform newItem;
            newItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity) as Transform;
            newItem.SetParent(inventorySlots, false);
            newItem.name = objet.name + " Slot";
            ItemSlots itemInventory = newItem.GetComponent<ItemSlots>();
            ItemVariable itemScene = objet.GetComponent<ItemVariable>();
            itemInventory.itemType = itemScene.itemType;
            itemInventory.itemID = itemScene.itemID;
            itemInventory.itemSprite = itemScene.itemSprite;
            itemInventory.itemDescription = itemScene.itemDescription;

            if (itemScene.itemID=="001")
            {
                DoorOne.GetComponent<DetectionControler>().key = newItem.gameObject;
                DoorOne.GetComponent<DetectionControler>().haveKey=true;
            }
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
        player.GetComponent<PlayerControler>().isPause = false;
        player.GetComponent<PlayerControler>().Ath.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
