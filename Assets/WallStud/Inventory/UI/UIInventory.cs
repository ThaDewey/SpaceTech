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
	private List<VisualElement> slots = new List<VisualElement>();

	private VisualElement content;
	private VisualElement inventory;
	private VisualElement description;

	protected override void Init() {
		base.Init();
		inventory = root.GetElement("Inventory");
		content = inventory.GetElement("InventoryContent");
		description = inventory.GetElement("InventoryDescription");
		
	}

	[Button]
	public override void OpenWindow() {
		base.OpenWindow();
		UpdateDisplay();
	}

	public override void UpdateDisplay() {
	

		for (int i = 0; i < myInventory.slots.Count; i++) {
			AddItemToSlot(slots[i], myInventory.slots[i]);
		}


		Button close = description.GetOrCreateButton("Close");
		close.clicked += CloseWindow;
	}







	public void InitializeInventoryUI() {
		content.Clear();


		for (int i = 0; i < myInventory.amountOfSlots; i++) {
			VisualElement slot = CreateSlot();
			
			slots.Add(slot);
		}
	}



	public VisualElement CreateSlot() {
		Debug.Log("CreateSlot()");
		VisualElement slot = content.CreateVisualElement("slot", "slot");
		return slot;
	}
	public static void AddItemToSlot(VisualElement slot, Item _item) {
		if (slot.childCount > 0) return;
		
		VisualElement slotImg = slot.CreateVisualElement("slotImg", null, _item.icon);
		Label itemAmount = slotImg.CreateLabel("ItemAmount", _item.amount);
		SerializedObject item = new SerializedObject(_item);
		slot.Bind(item);
	}

}
