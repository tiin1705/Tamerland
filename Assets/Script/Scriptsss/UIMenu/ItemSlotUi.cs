using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUi : MonoBehaviour
{
   [SerializeField] Text nameText;
   [SerializeField] Text countText;

   RectTransform rectTransform;

   private void Awake()
   {
      rectTransform = GetComponent<RectTransform>();
   }

   public Text Nametext => nameText;
   
   public Text CountText => countText;

   public float Height => rectTransform.rect.height;

   public void SetData(Itemslot itemslot)
   {
      nameText.text  = itemslot.Item.Name;
      countText.text = $"X {itemslot.Count}";
   }
}
