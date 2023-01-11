using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
/// IPointerDownHandler - Следит за нажатиями мышки по объекту на котором висит этот скрипт
/// IPointerUpHandler - Следит за отпусканием мышки по объекту на котором висит этот скрипт
/// IDragHandler - Следит за тем не водим ли мы нажатую мышку по объекту

public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public InventorySlot OldSlot;

    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        OldSlot = transform.GetComponentInParent<InventorySlot>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (OldSlot.IsEmpty)
        {
            return;
        }
        GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OldSlot.IsEmpty)
        {
            return;
        }
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        GetComponentInChildren<Image>().raycastTarget = false;

        transform.SetParent(transform.parent.parent.parent);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OldSlot.IsEmpty)
        {
            return;
        }

        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        GetComponentInChildren<Image>().raycastTarget = true;
        
        transform.SetParent(OldSlot.transform);
        transform.position = OldSlot.transform.position;

        if (eventData.pointerCurrentRaycast.gameObject.name == "UIBG")
        {
            GameObject itemObject = Instantiate(OldSlot.item.ItemPrefab, _player.position + Vector3.up + _player.forward, Quaternion.identity);
            itemObject.GetComponent<Item>().Amount = OldSlot.Amount;
            NullifySlotData();
        }
        else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent == null)
        {
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>() != null)
        {
            ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>());
        }
    }

    public void NullifySlotData()
    {
        OldSlot.item = null;
        OldSlot.Amount = 0;
        OldSlot.IsEmpty = true;
        OldSlot.IconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        OldSlot.IconGO.GetComponent<Image>().sprite = null;
        OldSlot.ItemAmountText.text = "";
    }

    void ExchangeSlotData(InventorySlot newSlot)
    {
        ItemScriptableObject item = newSlot.item;
        int Amount = newSlot.Amount;
        bool IsEmpty = newSlot.IsEmpty;
        GameObject IconGO = newSlot.IconGO;
        TMP_Text ItemAmountText = newSlot.ItemAmountText;

        newSlot.item = OldSlot.item;
        newSlot.Amount = OldSlot.Amount;

        if (OldSlot.IsEmpty == false)
        {
            newSlot.SetIcon(OldSlot.IconGO.GetComponent<Image>().sprite);
            newSlot.ItemAmountText.text = OldSlot.Amount.ToString();
        }
        else
        {
            newSlot.IconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            newSlot.IconGO.GetComponent<Image>().sprite = null;
            newSlot.ItemAmountText.text = "";
        }

        newSlot.IsEmpty = OldSlot.IsEmpty;

        OldSlot.item = item;
        OldSlot.Amount = Amount;
        
        if (IsEmpty == false)
        {
            OldSlot.SetIcon(IconGO.GetComponent<Image>().sprite);
            OldSlot.ItemAmountText.text = Amount.ToString();
        }
        else
        {
            OldSlot.IconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            OldSlot.IconGO.GetComponent<Image>().sprite  = null;
            OldSlot.ItemAmountText.text = "";
        }

        OldSlot.IsEmpty = IsEmpty;
    }
}
