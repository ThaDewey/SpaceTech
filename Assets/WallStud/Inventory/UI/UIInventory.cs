using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Base Class for accessing the UI element uiDocuments  during runtime.
/// </summary>
public class UIInventory : Window {
	[SerializeField] private PlayerInventorySO myInventory;
	private List<InventorySlot> slots = new List<InventorySlot>();

	private VisualElement content;
	private VisualElement inventory;
	private VisualElement description;


	protected override void Awake() {
		base.Awake();
		GameController.OnInventoryChanged += GameController_OnInventoryChanged;

	}

	private void GameController_OnInventoryChanged(string[] itemGuid, InventoryChangeType change) {
		//Loop through each item and if it has been picked up, add it to the next empty slot
		foreach (string item in itemGuid) {
			if (change == InventoryChangeType.Pickup) {
				var emptySlot = myInventory.items.FirstOrDefault(x => x.ItemGuid.Equals(""));

				if (emptySlot != null) {
					emptySlot.HoldItem(GameController.GetItemByGuid(item));
				}
			}
		}
	}

	protected override void Init() {
		base.Init();
		inventory = root.GetElement("Inventory");
		content = inventory.GetElement("InventoryContent");
		description = inventory.GetElement("InventoryDescription");
	//	DragAndDropManipulator manipulator = 	new(root.Q<VisualElement>("object"));
	}

	[Button]
	public override void OpenWindow() {
		base.OpenWindow();
		UpdateDisplay();
	}

	public override void UpdateDisplay() {
	

		for (int i = 0; i < myInventory.items.Count; i++) {
			//AddItemToSlot(slots[i], myInventory.slots[i]);
			slots[i].SetItem(myInventory.items[i]);
		}


		Button close = description.GetOrCreateButton("Close");
		close.clicked += CloseWindow;
	}

	public void InitializeInventoryUI() {
		content.Clear();


		for (int i = 0; i < myInventory.amountOfSlots; i++) {
			InventorySlot slot = CreateSlot();
			
			slots.Add(slot);
		}
	}



	public InventorySlot CreateSlot() {
		Debug.Log("CreateSlot()");
		InventorySlot slot = new InventorySlot();

		slot.name = "slot";
		slot.AddToClassList("slot");
		content.Add(slot);
		
		return slot;
	}

}
