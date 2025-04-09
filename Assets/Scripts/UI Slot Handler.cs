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


    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item == null) {return;}  
            MouseManager.instance.PickupFromStack(this);
            return;
        }
        MouseManager.instance.UpdateHeldItem(this);
    }
    void itemStorage(){
       if (item != null)
        {
            item = item.Clone();
            icon.sprite = item.itemIcon;
            if (item.maxStack > 1){
                itemCountText.text = item.itemCount.ToString();
            }
            else{
                itemCountText.text = string.Empty;
            }
        }
        else
        {
            icon.gameObject.SetActive(false);
            itemCountText.text = string.Empty;
        }        
    }
    void Start()
    {
        itemStorage();   
    }

}
