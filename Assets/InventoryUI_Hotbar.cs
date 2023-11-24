using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;

public class InventoryUI_Hotbar : MonoBehaviour {
	public UIDocument doc;

	private TemplateContainer container;
	private VisualElement hotbarHolder;
	private VisualElement hotbar;
	private int slots = 8;
	public List<Item> inventory = new List<Item>();

	[SerializeField] private PlayerInventorySO playerInventory;

	private void OnEnable() {
		var root = doc.rootVisualElement;
		container = root as TemplateContainer;
		hotbarHolder = container.Q<VisualElement>("hotbarHolder");
		hotbar = hotbarHolder.Q<VisualElement>("hotbar");
		Debug.Log(hotbar);

		inventory = playerInventory.items;
	}

	private void Start() {
		hotbar.Clear();
		
		inventory = playerInventory.items;
		
		
		UpdateDisplay();

	}

	private void UpdateDisplay() {
		Debug.Log("UpdateDisplay");

		foreach (Item item in inventory) {
			Debug.Log(item.name);
			Button button = new Button();
			button.text = item.name;
			Background newBG = new Background();
			newBG.sprite = item.icon;

			button.style.backgroundImage = newBG;
			button.AddToClassList("item");
			hotbar.Add(button);
		}
	}

}
