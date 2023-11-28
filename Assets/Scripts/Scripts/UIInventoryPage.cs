using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem inventoryItemUIPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private UIInventoryDescription inventoryItemUIDescription;

    [SerializeField]
    private MouseFollower mouseFollower;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();


    private int currentlyDraggedItemIndex = -1;

    public event Action<int> OnDescriptionRequested,
        OnItemActionRequested,
        OnStartDragging;
    public event Action<int, int> OnSwapItems;


    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        inventoryItemUIDescription.ResetDescription();
    }

    public void InitializeInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem uiItem = Instantiate(inventoryItemUIPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.onItemClicked += HandleItemSelection;
            uiItem.onItemBeginDrag += HandleBeginDrag;
            uiItem.onItemDroppedOn += HandelSwap;
            uiItem.onItemEndDrag += HandleEndDrag;
            uiItem.onRightMouseBtnClick += HandleShowItemActions;
        }
    }
    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if(listOfUIItems.Count > itemIndex)
        {
            listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
        }
    }

    private void HandleShowItemActions(UIInventoryItem inventoryItemUI)
    {

    }

    private void HandleEndDrag(UIInventoryItem inventoryItemUI)
    {
        ResetDraggedItem();
    }

    private void HandelSwap(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if(index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(inventoryItemUI);

    }

    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }
    public void CreateDraggedITem(Sprite sprite, int quantity)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(sprite, quantity);
    }

    private void HandleItemSelection(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ResetSelection();

    }

    public void ResetSelection()
    {
        inventoryItemUIDescription.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach(UIInventoryItem item in listOfUIItems)
        {
            item.Deselect();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ResetDraggedItem();
    }

    internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
    {
        inventoryItemUIDescription.SetDescription(itemImage, name, description);
        DeselectAllItems();
        listOfUIItems[itemIndex].Select();
    }

    internal void ResetAllItems()
    {
        foreach (var item in listOfUIItems)
        {
            item.ResetData();
            item.Deselect();
        }
    }
}
