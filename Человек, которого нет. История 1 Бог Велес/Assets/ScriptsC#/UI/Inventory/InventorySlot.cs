using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public GameObject IconGO;
    public TMP_Text ItemAmountText; 
    public bool IsEmpty = true;
    public int Amount;

    public void Start()
    {
        IconGO = transform.GetChild(0).GetChild(0).gameObject;
        ItemAmountText = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
    }

    public void SetIcon(Sprite icon)
    {
        IconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        IconGO.GetComponent<Image>().sprite = icon;
    }
}
