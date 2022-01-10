using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{
    public string itemType;
    public string itemID;
    public Sprite itemSprite;
    public Sprite itemSlotSprite;
    public string itemDescription;
    public GameObject Object;
    public GameObject imagePrefab;
    public Image itemImagePanel;

    // Start is called before the first frame update

    void Start()
    {
        GetComponent<Image>().sprite = itemSlotSprite;
        GameObject itemImagePanel = GameObject.Find("ItemsImage");
        itemImagePanel.GetComponent<Image>().sprite = itemSprite;
        //float item = ItemImagePanel.GetComponent<Image>().color.a;
    }

    public void DisplayImage()
    {
        //itemImagePanel.sprite = itemSprite;
        GameObject.FindGameObjectWithTag("ItemImage").GetComponent<Image>().sprite = itemSprite;
        GameObject.FindGameObjectWithTag("ItemImage").GetComponent<Image>().color = new Color (255,255,255,255);
        transform.parent.parent.GetComponent<Inventory>().ItemDisplay = Object;
        transform.parent.parent.GetComponent<Inventory>().ItemDisplaySlot = transform.gameObject;
    }

}
