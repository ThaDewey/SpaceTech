using System;
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

	private const string INV_SLOT_CONTAINER = InventorySystem.USS_SLOT_CONTAINER;
	private const string INV_SLOT = InventorySystem.INV_SLOT;
	private const string INV_SLOT_IMG = InventorySystem.INV_SLOT_IMG;
	private const string USS_N_ITEM_AMOUNT = InventorySystem.USS_N_ITEM_AMOUNT;


	public InventorySlot(Item _item = null) {
		img_icon = new Image();
		img_icon.AddToClassList(INV_SLOT_IMG);
		Add(img_icon);


		background = this.style.backgroundImage;

		//Debug.Log("Constructor | InventorySlot");
		item = _item;
		this.name = INV_SLOT;

		AddToClassList(INV_SLOT_CONTAINER);
		root = parent;

		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
		}

	}


	public void OnPointerEnter(PointerEnterEvent evt) {
		Debug.Log($"{name} | OnPointerEnter");
	}
	public void OnPointerExit(PointerLeaveEvent evt) {
		Debug.Log($"{name} | PointerLeaveEvent");
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
	public void PrepareSlotForMove() => ClearIcon();

	public bool hasChild() => (childCount > 0) ? true : false;

	public void SetItem(Item _item) {
		if (_item == null) return;
		//	Debug.Log($"SetItem({_item})");
		item = _item;


		UpdateIcon(item.icon);
		UpdateAmount(item._amount);
		BindItemData(_item);
		RegisterCallback<PointerDownEvent>(OnPointerDown);

	}
	private void BindItemData(Item _item) {
		SerializedObject itemData = new SerializedObject(_item);
		this.Bind(itemData);
	}
	private void UpdateIcon(Sprite sprite) {
		img_icon.sprite = sprite;
		img_icon.Show();

	}
	public void ClearIcon() {
		img_icon.Hide();
		label_Amount.Hide();
	}
	public void UpdateAmount(string amount) {
		if (label_Amount != null) return;

		label_Amount = this.GetOrCreateLabel(USS_N_ITEM_AMOUNT, amount);
	}
	private Label CreateAmountLabel(string amount) {
		return this.GetOrCreateLabel<string>(USS_N_ITEM_AMOUNT,amount);
	}
	public void HoldItem(Item item) {
		Debug.Log($"HoldItem({item})");
		SetItem(item);
	}
	public void DropItem() {
		ClearIcon();
	}
}