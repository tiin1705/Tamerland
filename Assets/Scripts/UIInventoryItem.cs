using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIInventoryItem : MonoBehaviour, IPointerClickHandler,
    IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TMP_Text quantityTxt;

    [SerializeField]
    private Image borderImage;

    public event Action<UIInventoryItem> onItemClicked,
        onItemDroppedOn, onItemBeginDrag, onItemEndDrag,
        onRightMouseBtnClick;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }
    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }
    public void Deselect()
    {
        borderImage.enabled = false;
    }
    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.quantityTxt.text = quantity + "";
        empty = false;
    }
    public void Select()
    {
        borderImage.enabled = true;
    }



    public void OnDrop(PointerEventData eventData)
    {
        onItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onItemEndDrag?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (empty)
            return;
        onItemBeginDrag?.Invoke(this);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            onRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            onItemClicked?.Invoke(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}

