using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class UISlotHandler : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public Image icon;
    public TextMeshProUGUI itemCountText;
    public InventoryManager inventoryManager;

    // Add this reference to the hand slot
    public UISlotHandler handSlot;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item == null) { return; }
            MouseManager.instance.PickupFromStack(this);
            return;
        }
        MouseManager.instance.UpdateHeldItem(this);
    }

    void UpdateHandSlot()
    {
        // Only update the hand slot if there's a held item
        if (MouseManager.instance.currentlyHeldItem != null && handSlot != null)
        {
            // Set the item in the hand slot
            handSlot.item = MouseManager.instance.currentlyHeldItem;
            handSlot.icon.sprite = MouseManager.instance.currentlyHeldItem.itemIcon;

            // Update the item count text
            if (MouseManager.instance.currentlyHeldItem.maxStack > 1)
            {
                handSlot.itemCountText.text = MouseManager.instance.currentlyHeldItem.itemCount.ToString();
            }
            else
            {
                handSlot.itemCountText.text = string.Empty; // No count if it's a single item
            }

            handSlot.icon.gameObject.SetActive(true); // Make the icon visible
        }
        else
        {
            // If there’s no held item, hide the hand slot UI
            if (handSlot != null)
            {
                handSlot.icon.gameObject.SetActive(false);
                handSlot.itemCountText.text = string.Empty;
            }
        }
    }

    void Start()
    {
        itemStorage();
    }

    void Update()
    {
        // Continuously update the hand slot every frame
        UpdateHandSlot();
    }

    void itemStorage()
    {
        if (item != null)
        {
            item = item.Clone();
            icon.sprite = item.itemIcon;
            if (item.maxStack > 1)
            {
                itemCountText.text = item.itemCount.ToString();
            }
            else
            {
                itemCountText.text = string.Empty;
            }
        }
        else
        {
            icon.gameObject.SetActive(false);
            itemCountText.text = string.Empty;
        }
    }
}
