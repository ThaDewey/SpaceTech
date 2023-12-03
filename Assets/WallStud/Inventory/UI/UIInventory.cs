using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEditor.PackageManager.UI;

/// <summary>
/// Base Class for accessing the UI element uiDocuments  during runtime.
/// </summary>
public class UIInventory : Window {
	[SerializeField] private PlayerInventorySO myInventory;
	public static List<InventorySlot> slots = new List<InventorySlot>();
	private List<Item> inventory => myInventory.items;
	[SerializeField] private InputActionReference mousePos;
	//Global variable
	private static VisualElement ghostIcon;


	private VisualElement ve_content;
	private VisualElement ve_inventory;
	private VisualElement ve_description;

	protected override void Awake() {
		base.Awake();

	}

	protected void Start() {
		myInventory.OnInventoryChanged += GameController_OnInventoryChanged;
	}



	protected override void Init() {
		base.Init();
		ve_inventory = root.GetElement("Inventory");
		ve_content = ve_inventory.GetElement("InventoryContent");
		ve_description = ve_inventory.GetElement("InventoryDescription");

	}

	[Button]
	public override void OpenWindow() {
		base.OpenWindow();
		UpdateDisplay();
	}

	public override void UpdateDisplay() {
		//Debug.Log($"UpdateDisplay");
		//Debug.Log($"inventory.Count: {inventory.Count}");
		List<InventorySlot> mySlots = ve_content.Query<InventorySlot>("slot").ToList();

		for (int i = 0; i < inventory.Count; i++) {
			InventorySlot slot = mySlots[i];
			Item item = inventory[i];
			mySlots[i].SetItem(item);

		}


		Button close = ve_description.GetOrCreateButton("Close");
		close.clicked += CloseWindow;
	}

	public void InitializeInventoryUI() {
		ve_content.Clear();


		for (int i = 0; i < myInventory.amountOfSlots; i++) {
			InventorySlot slot = CreateSlot();

			slots.Add(slot);
		}
	}



	public InventorySlot CreateSlot() {
		///Debug.Log("CreateSlot()");
		InventorySlot slot = new InventorySlot();

		slot.name = "slot";
		slot.AddToClassList("slot");

		ve_content.Add(slot);

		return slot;
	}

	private void InitGhostIcon() {
		//ghostIcon.RegisterCallback<PointerMoveEvent>(OnPointerMove);
		//ghostIcon.RegisterCallback<PointerUpEvent>(OnPointerUp);
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
