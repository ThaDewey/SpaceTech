using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UIElements;
using System;

public class Inventory : MonoBehaviour {
    public PlayerInventorySO playerInv;
    [SerializeField] private InventorySettings settings;
    public UIInventory ui;

    //public static event Action<Item> OnAddItem;
    //public static event Action<Item> OnRemoveItem;


    public void OnEnable() {
    }

    public void Awake() {
    }

    public void Start(){
        Debug.Log(ui);
        ui.inv_container.InitializeInventoryUI(settings.size);
    }


    private void Add(Item item) {
        playerInv.AddItem(item);
    }
    private void Remove(Item item) {
        playerInv.RemoveItem(item);

    }

    private void OnInventoryChanged(Item item, InventoryChangeType change) {
        //Loop through each item and if it has been picked up, add it to the next empty slot
        Debug.Log($"GameController_OnInventoryChanged({item},{change})");

        if (change == InventoryChangeType.Pickup) {
            InventorySlot emptySlot = new InventorySlot();
            emptySlot.item = item;
            //emptySlot.Icon.sprite = item.icon;
            //emptySlot.ItemGuid = item.GUID;

            if (emptySlot != null) {
                emptySlot.HoldItem(item);
            }
        }
    }
}
