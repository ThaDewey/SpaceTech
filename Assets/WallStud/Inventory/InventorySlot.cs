using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


public class InventorySlot : VisualElement {
	public VisualElement root;
	private Image img_icon;
	public StyleBackground background;
	public Label label_Amount;

	public Item item;
	public string ItemGuid => item.GUID;

	public InventorySlot(Item _item = null) {
		img_icon = new Image();
		img_icon.AddToClassList("slotImg");
		Add(img_icon);


		background = this.style.backgroundImage;

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
		Debug.Log($"{name} | {item.name}| OnPointerDown");

		if (evt.button != 0) return;


		InventorySystem.slotManipulator = this.parent.Q<SlotManipulator>();

		if (InventorySystem.slotManipulator == null) {
			new SlotManipulator(this.parent, item, this, evt);
		}
		else {
			InventorySystem.slotManipulator.UpdateManipulator(item, this, evt);
		}

		PrepareSlotForMove();
	}
	public void PrepareSlotForMove() {
		Debug.Log($"{name} | {item.name}| PrepareSlotForMove");
		Debug.Log($"{img_icon} PrepareSlotForMove");
		Debug.Log($"{img_icon.image} PrepareSlotForMove");
		ClearIcon();

	}

	public bool hasChild() => (childCount > 0) ? true : false;

	public void SetItem(Item _item) {
		//	Debug.Log($"SetItem({_item})");
		item = _item;
		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
			SerializedObject itemData = new SerializedObject(_item);
			this.Bind(itemData);
		}
		RegisterCallback<PointerDownEvent>(OnPointerDown);

	}

	public void UpdateIcon(Sprite sprite) => img_icon.sprite = sprite;


	public void ClearIcon() {
		img_icon.Hide();
		label_Amount.Hide();
	}

	public void UpdateAmount(string amount) {
		if (label_Amount != null) return;

		label_Amount = this.CreateLabel("ItemAmount", amount);
	}


	public void HoldItem(Item item) {
		UpdateIcon(item.icon);
	}
	public void DropItem() {
		ClearIcon();
	}
}