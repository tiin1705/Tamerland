using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Create new recovery item")]
public class ItemHoiPhuc : ItemBase
{
   [Header("HP")]
   [SerializeField] int hpAmount;
   [SerializeField] bool restoreMaxHP;
   [Header("PP")]
   [SerializeField] int ppMount;
   [SerializeField] bool restoreMaxPP;
   [Header("Status Condition")]
   [SerializeField] bool recoveryAllStatus;
   [Header("Revive")]
   [SerializeField] bool revive;
   [SerializeField] bool maxRevive;

}
