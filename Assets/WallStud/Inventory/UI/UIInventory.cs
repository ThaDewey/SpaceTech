using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using UnityEngine.InputSystem;


/// <summary>
/// Base Class for accessing the UI element uiDocuments  during runtime.
/// </summary>
public class UIInventory : Window {
	[SerializeField] private PlayerInventorySO myInventory;
	[SerializeField] private Inventory INVENTORY;

	private List<Item> inventory => INVENTORY.playerInv.items;
	//Global variable
	private static VisualElement ghostIcon;

	public VisualElement ve_inventory;
	public InventoryContainer inv_container;
	public VisualElement ve_description;

	protected override void Awake() {
		base.Awake();
	}

	protected void Start() {
		myInventory.OnInventoryChanged += GameController_OnInventoryChanged;
	}


	public InventoryContainer GetContainer() => root.Q<InventoryContainer>("InventoryContainer");

	protected override void Init() {
		base.Init();
		ve_inventory = root.GetElement("Inventory");
		ve_description = ve_inventory.GetElement("InventoryDescription");
		inv_container = GetContainer();
	}

	[Button]
	public override void OpenWindow() {
		base.OpenWindow();
		UpdateDisplay();
	}

	public override void UpdateDisplay() {
		//Debug.Log($"UpdateDisplay");
		//Debug.Log($"inventory.Count: {inventory.Count}");
		List<InventorySlot> mySlots = inv_container.Query<InventorySlot>("slot").ToList();

		for (int i = 0; i < inventory.Count; i++) {
			InventorySlot slot = mySlots[i];
			Item item = inventory[i];
			mySlots[i].SetItem(item);

		}


		Button close = ve_description.GetOrCreateButton("Close");
		close.clicked += CloseWindow;
	}


	[System.Obsolete]
	private void GameController_OnInventoryChanged(Item item, InventoryChangeType change) {
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
