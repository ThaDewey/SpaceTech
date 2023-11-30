using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;

public class InventoryUI_Hotbar : MonoBehaviour
{
	public UIDocument doc;
	[SerializeField] bool log;

	private TemplateContainer container;
	private VisualElement hotbarHolder;
	private VisualElement hotbar;
	private int slots = 8;
	public List<Item> inventory = new List<Item>();

	[SerializeField] private PlayerInventorySO playerInventory;

	private void OnEnable()
	{
		var root = doc.rootVisualElement;
		container = root as TemplateContainer;
		hotbarHolder = container.Q<VisualElement>("hotbarHolder");
		hotbar = hotbarHolder.Q<VisualElement>("hotbar");
		inventory = playerInventory.items;
	}

	private void Start()
	{
		hotbar.Clear();

		inventory = playerInventory.items;


		UpdateDisplay();

	}

	private void UpdateDisplay()
	{
		if (log) Debug.Log("UpdateDisplay");

		foreach (Item item in inventory)
		{
			hotbar.CreateButton(item.name, "item", item.icon);
		}
	}

}
