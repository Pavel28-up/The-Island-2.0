using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Default, Food, Weapon, Instrument}
public class ItemScriptableObject : ScriptableObject
{
    public ItemType itemType;
    public GameObject ItemPrefab;
    public Sprite icon;
    public string ItemName;
    public string ItemDiscription;
    public int MaximumAmount;
    public bool IsConsumeable;

    [Header("Consumble Characteristics")]
    public float ChangeHealth;
    public float ChangeHunder;
    public float ChangeThirst;
}
