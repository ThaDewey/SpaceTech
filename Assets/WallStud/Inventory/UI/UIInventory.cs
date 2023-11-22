using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Base Class for accessing the UI element uiDocuments  during runtime.
/// </summary>
public class UIInventory : Window
{
	[SerializeField] private PlayerInventorySO myInventory;

	private VisualElement inventory;
	public VisualElement content;
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
		content.Clear();
		foreach (Item item in myInventory.inventory) {
			CreateInventoryItem(item);
		}
	}


	private VisualElement CreateInventoryItem(Item _item) {

		VisualElement itemUI = content.CreateVisualElement("itemUI","item");
		VisualElement itemImage = itemUI.CreateVisualElement("itemImage",_item.icon);
		VisualElement counterBg = itemImage.CreateVisualElement("counter");
		Label counter = counterBg.CreateLabel("counter",_item.amount);

		return itemUI;

	}
}
