using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class InventoryContainer : VisualElement {
	private InventorySystem invSystem;

	public static List<InventorySlot> _slots = new List<InventorySlot>();

	public List<InventorySlot> slots => _slots;

	public new class UxmlFactory : UxmlFactory<InventoryContainer, UxmlTraits> { }

	public void InitializeInventoryUI(int size) {
		Clear();

		for (int i = 0; i < size; i++) {
			InventorySlot slot = CreateSlot();
			slots.Add(slot);
		}
	}


	public InventorySlot CreateSlot() {
		///Debug.Log("CreateSlot()");
		InventorySlot slot = new InventorySlot();

		slot.name = "slot";
		slot.AddToClassList("slot");

		this.Add(slot);

		return slot;
	}

	public void DeleteSlot(InventorySlot slot) {
		Remove(slot);
		_slots.Remove(slot);
	}

}