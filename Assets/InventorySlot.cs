using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot : VisualElement {
	public Image Icon;
	public Label label_Amount;
	
	public string ItemGuid = "";
	public Item item;

	public InventorySlot(Item _item = null) {
		Debug.Log("Constructor");
		item = _item;
		this.name = "InventorySlot";

		AddToClassList("slotContainer");

		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
		}
		RegisterCallback<PointerEnterEvent>((e) => Debug.Log($"{name} ENTER)"),TrickleDown.TrickleDown); ;
		RegisterCallback<PointerLeaveEvent>((e) => Debug.Log($"{name} EXIT)"));
		RegisterCallback<PointerDownEvent>((e) => Debug.Log($"{name} Down)"), TrickleDown.TrickleDown);
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
		//Not the left mouse button
		if (evt.button != 0 || ItemGuid.Equals("")) {
			return;
		}
		//Clear the image
		Icon.image = null;
		//Start the drag
		UIInventory.StartDrag(evt.position, this);
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