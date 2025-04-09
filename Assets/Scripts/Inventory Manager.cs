using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public void StackInInventory(UISlotHandler currentSlot, Item item)
    {
        currentSlot.item.itemCount += item.itemCount;
        currentSlot.itemCountText.text = currentSlot.item.itemCount.ToString();
    }

    public void PlaceInInventory(UISlotHandler currentSlot, Item item)
    {
        currentSlot.item = item;
        currentSlot.icon.sprite = item.itemIcon;
            if (item.maxStack > 1){
                currentSlot.itemCountText.text = item.itemCount.ToString();
            }
            else{
                currentSlot.itemCountText.text = string.Empty;
            }
        currentSlot.icon.gameObject.SetActive(true);
    }

    public void ClearInventorySlot(UISlotHandler currentSlot)
    {
        currentSlot.item = null;
        currentSlot.icon.sprite = null;
        currentSlot.itemCountText.text = string.Empty;
        currentSlot.icon.gameObject.SetActive(false);
    }
}
