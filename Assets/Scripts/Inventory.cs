using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public GameObject player;
    public Transform inventorySlots;
    public Transform itemPrefab;
    public int slotsCount;
    public GameObject DoorOne;
    public GameObject ItemDisplay;
    public GameObject ItemDisplaySlot;

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
            itemInventory.Object = objet;
            itemInventory.itemType = itemScene.itemType;
            itemInventory.itemID = itemScene.itemID;
            itemInventory.itemSprite = itemScene.itemSprite;
            itemInventory.itemSlotSprite = itemScene.itemSlotSprite;
            itemInventory.itemDescription = itemScene.itemDescription;
            EventTrigger ItemEventTrigger = newItem.GetComponent<EventTrigger>();
        }
        
    }

    public void EnableImage()
    {
        print("test");
    }

    private bool isSorted;

    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            StartCoroutine(CoroutineDisableInventory());
        }
        if (Input.GetKey(KeyCode.T) && ItemDisplay != null)
        {
            if (!isSorted)
            {
                RemoveInventory();
            }
            
        }
    }

    System.Collections.IEnumerator CoroutItem(GameObject newItem)
    {
        yield return new WaitForSeconds(0.1f);
        newItem.transform.SetParent(player.transform.parent, true);
        isSorted = false;
        ItemDisplay = null;
        ItemDisplaySlot = null;
        newItem.GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindGameObjectWithTag("ItemImage").GetComponent<Image>().color = new Color(255, 255, 255, 0);

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

    public void RemoveInventory()
    {
        ItemDisplaySlot.SetActive(false);
        GameObject newItem = Instantiate(ItemDisplay, Vector3.forward, Quaternion.identity);
        newItem.name = ItemDisplay.name;
        Transform PlayerCameraTransform = player.GetComponent<PlayerControler>().playerCamera.transform;
        newItem.transform.SetParent(PlayerCameraTransform, false);
        isSorted = true;
        newItem.GetComponent<Rigidbody>().isKinematic = true;
        newItem.SetActive(true);
        StartCoroutine(CoroutItem(newItem));
        Destroy(ItemDisplaySlot);
    }
}
