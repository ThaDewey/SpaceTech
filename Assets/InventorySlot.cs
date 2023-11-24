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
		item = _item;
		this.name = "InventorySlot";

		AddToClassList("slotContainer");

		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
		}

	}
	public bool hasChild() => (childCount > 0) ? true : false;

	public void SetItem(Item _item) {
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