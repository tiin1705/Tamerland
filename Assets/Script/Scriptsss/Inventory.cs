using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   [SerializeField] List<Itemslot> slots;

    public List<Itemslot> Slots => slots;

    public static Inventory GetInventory()
    {
        return FindObjectOfType<PlayerController>().GetComponent<Inventory>(); 
    }
}

[Serializable]

public class Itemslot
{
    [SerializeField] ItemBase item;
    [SerializeField] int count;

    public ItemBase Item => item;
    public int Count => count;
}
