using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public CinemachineVirtualCamera CVC;
    public GameObject UIBG;
    public GameObject Crosshair;
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public float ReachDistance = 3;
    public bool IsOpened = false;

    private Camera mainCamera;
    
    private void Awake()
    {
        UIBG.SetActive(true);
    }

    void Start()
    {
        mainCamera = Camera.main;

        for (int i = 0; i < InventoryPanel.childCount; i++)
        {
            if (InventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }

        UIBG.SetActive(false);
        InventoryPanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            IsOpened = !IsOpened;
            if (IsOpened)
            {
                UIBG.SetActive(true);
                InventoryPanel.gameObject.SetActive(true);
                Crosshair.SetActive(false);
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                UIBG.SetActive(false);
                InventoryPanel.gameObject.SetActive(false);
                Crosshair.SetActive(true);
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
                
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        RayItemObj();
    }

    public void RayItemObj()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, ReachDistance))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().Amount);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.Amount + _amount <= _item.MaximumAmount)
                {
                    slot.Amount += _amount;
                    slot.ItemAmountText.text = slot.Amount.ToString();
                    return;
                }
                break;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty == true)
            {
                slot.item = _item;
                slot.Amount = _amount;
                slot.IsEmpty = false;
                slot.SetIcon(_item.icon);
                slot.ItemAmountText.text = _amount.ToString();
                break;
            }
        }
    }
}
