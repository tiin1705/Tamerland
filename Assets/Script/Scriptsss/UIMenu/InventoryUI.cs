using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class InventoryUI : MonoBehaviour
{
   [SerializeField] GameObject itemList;
   [SerializeField] ItemSlotUi itemSlotUi;
   [SerializeField] Image itemIcon;
   [SerializeField] Text itemDescription;
   List<ItemSlotUi> slotUIlist;
   [SerializeField] Image upArrow;
   [SerializeField] Image downArrow;

     int selecteditem = 0;
     const int itemInViewport = 6;
    Inventory inventory;
    RectTransform itemListRect;
   
   private void Awake()

   {
        inventory = Inventory.GetInventory();
        itemListRect = itemList.GetComponent<RectTransform>();   

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
   }
   private void Start()
   {
        UpdateItem();
   }
   void UpdateItem()
   {
    //Xóa hết item đang tồn tại
    foreach (Transform child in itemList.transform)
        Destroy(child.gameObject);

          slotUIlist = new List<ItemSlotUi>();
        foreach( var itemSlot in inventory.Slots)
        {
            var slotUIOJ = Instantiate(itemSlotUi, itemList.transform); //Khởi tạo prefab ItemUI với list item
            slotUIOJ.SetData(itemSlot);

            slotUIlist.Add(slotUIOJ);
        }
   }
   void Update()
   {
     int prevSelection = selecteditem;
     if(Input.GetKeyDown(KeyCode.DownArrow))
     ++selecteditem;
     else if(Input.GetKeyDown(KeyCode.UpArrow))
     --selecteditem;

     selecteditem = Mathf.Clamp(selecteditem, 0, inventory.Slots.Count - 1);

     if(prevSelection != selecteditem)
          UpdateItemSelections();
   }
   Color highlight = new Color (90, 83, 83);
   void UpdateItemSelections()
   {
     for(int i = 0; i < slotUIlist.Count; i++)
     {
          if(i == selecteditem)
          {
               slotUIlist[i].Nametext.color = highlight;
          } else 
          {
               slotUIlist[i].Nametext.color = Color.black;
          }
     }
     var item = inventory.Slots[selecteditem].Item;// trả về vị trí mình đã chọn
     itemIcon.sprite = item.Icon;
     itemDescription.text = item.Description;

     HandleScroling(); //item scroll bang mui ten
   }
   void HandleScroling()
   {
     float scrollPos = Mathf.Clamp(selecteditem - 4, 0, selecteditem )* slotUIlist[0].Height;
     itemListRect.localPosition = new Vector2(itemListRect.localPosition.x, scrollPos);

     bool showUpArrow = selecteditem > itemInViewport / 2;
     upArrow.gameObject.SetActive(showUpArrow);
     bool showDownArrow = selecteditem + itemInViewport / 2 < slotUIlist.Count;
     downArrow.gameObject.SetActive(showDownArrow);    
   }
}
