using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


public class InventorySlot : VisualElement {
	public Image Icon;
	public Label label_Amount;
	public VisualElement root;
	public string ItemGuid = "";
	public Item item;

	public InventorySlot(Item _item = null) {
		//Debug.Log("Constructor | InventorySlot");
		item = _item;
		this.name = "InventorySlot";

		AddToClassList("slotContainer");
		root = parent;

		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
		}

	}


	public void OnPointerEnter(PointerEnterEvent evt) {
		Debug.Log($"{name} | OnPointerEnter");
		//throw new NotImplementedException();
	}
	public void OnPointerExit(PointerLeaveEvent evt) {
		Debug.Log($"{name} | PointerLeaveEvent");
		//throw new NotImplementedException();
	}
	public void OnPointerDown(PointerDownEvent evt) {
		Debug.Log($"{name} | OnPointerDown");

		if (evt.button != 0) 	return;
		
		Icon.image = null;

		InventorySystem.slotManipulator = this.parent.Q<SlotManipulator>();

		if (InventorySystem.slotManipulator == null) {
			new SlotManipulator(this.parent,item, this,evt);
		} else {
			InventorySystem.slotManipulator.UpdateItem(item, this, evt);
		}



		//UIInventory.StartDrag(evt.position, this);
	}


	public bool hasChild() => (childCount > 0) ? true : false;

	public void SetItem(Item _item) {
		Debug.Log($"SetItem({_item})");
		item = _item;
		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
			SerializedObject itemData = new SerializedObject(_item);
			this.Bind(itemData);
		}
		RegisterCallback<PointerDownEvent>(OnPointerDown);

	}

	public void UpdateIcon(Sprite sprite) {
		if (Icon != null) return;
		//Create a new Image element and add it to the root
		Icon = new Image();
		Icon.sprite = sprite;
		Add(Icon);
		//Add USS style properties to the elements
		Icon.AddToClassList("slotImg");
	}
	public void UpdateAmount(string amount) {
		if (label_Amount != null) return;

		label_Amount = this.CreateLabel("ItemAmount", amount);
	}


	public void HoldItem(Item item) {
		UpdateIcon(item.icon);

		ItemGuid = item.GUID;
	}
	public void DropItem() {
		ItemGuid = "";
		Icon.image = null;
	}
}