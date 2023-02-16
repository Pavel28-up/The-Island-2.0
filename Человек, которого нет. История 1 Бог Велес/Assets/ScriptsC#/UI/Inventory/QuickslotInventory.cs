using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickslotInventory : MonoBehaviour
{
    // Объект у которого дети являются слотами
    public InventoryManager inventoryManager;
    public InventorySlot ActiveSlot = null;
    public Transform QuickslotParent;
    public Transform ItemContainer;
    public Transform AllWeapons;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    public Text healthText;
    public int currentQuickslotID = 0;
    

    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        // Используем колесико мышки
        if (mw > 0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки назад и наше число currentQuickslotID равно 0, то выбираем наш последний слот
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = QuickslotParent.childCount - 1;
            }
            else
            {
                // Уменьшаем число currentQuickslotID на 1
                currentQuickslotID--;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            ActiveSlot = QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
            ShowItemInHand();
            // Что то делаем с предметом:

        }
        if (mw < -0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки вперед и наше число currentQuickslotID равно последнему слоту, то выбираем наш первый слот (первый слот считается нулевым)
            if (currentQuickslotID >= QuickslotParent.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // Прибавляем к числу currentQuickslotID единичку
                currentQuickslotID++;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            ActiveSlot = QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
            ShowItemInHand();
            // Что то делаем с предметом:

        }
        // Используем цифры
        for (int i = 0; i < QuickslotParent.childCount; i++)
        {
            // если мы нажимаем на клавиши 1 по 5 то...
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                // проверяем если наш выбранный слот равен слоту который у нас уже выбран, то
                if (currentQuickslotID == i)
                {
                    // Ставим картинку "selected" на слот если он "not selected" или наоборот
                    if (QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
                    {
                        QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                        ActiveSlot = QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
                        ShowItemInHand();
                    }
                    else
                    {
                        QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                        ActiveSlot = null;
                        HideItemsInHand();
                    }
                }
                // Иначе мы убираем свечение с предыдущего слота и светим слот который мы выбираем
                else
                {
                    QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    
                    currentQuickslotID = i;
                    
                    QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                    ActiveSlot = QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>();
                    ShowItemInHand();
                }
            }
        }
        // Используем предмет по нажатию на левую кнопку мыши
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item != null)
            {
                if (QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item.IsConsumeable && !inventoryManager.IsOpened && QuickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)
                {
                    // Применяем изменения к здоровью (будущем к голоду и жажде) 
                    ChangeCharacteristics();

                    if (QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().Amount <= 1)
                    {
                        QuickslotParent.GetChild(currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                    }
                    else
                    {
                        QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().Amount--;
                        QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().ItemAmountText.text = QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().Amount.ToString();
                    }
                }
            }
        }
    }

    private void ChangeCharacteristics()
    {
        //// Если здоровье + добавленное здоровье от предмета меньше или равно 100, то делаем вычисления... 
        //if(int.Parse(healthText.text) + QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item.ChangeHealth <= 100)
        //{
        //    float newHealth = int.Parse(healthText.text) + QuickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item.ChangeHealth;
        //    healthText.text = newHealth.ToString();
        //}
        //// Иначе, просто ставим здоровье на 100
        //else
        //{
        //    healthText.text = "100";
        //}
    }

    private void ShowItemInHand()
    {
        HideItemsInHand();
        if (ActiveSlot.item == null)
        {
            return;
        }
        for (int i = 0; i < AllWeapons.childCount; i++)
        {
            if (ActiveSlot.item.InHandName == AllWeapons.GetChild(i).name)
            {
                AllWeapons.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    private void HideItemsInHand()
    {
        for (int i = 0; i < AllWeapons.childCount; i++)
        {
            AllWeapons.GetChild(i).gameObject.SetActive(false);
        }
    }
}
