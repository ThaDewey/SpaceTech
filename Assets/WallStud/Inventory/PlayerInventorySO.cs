using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
[InlineEditor, CreateAssetMenu(fileName = "Player Inventory", menuName = "SpaceTech/Inventory/Player Inventory")]
public class PlayerInventorySO : ScriptableObject {

	public int amountOfSlots;

	public List<Item> items;
	public int slotsCount => items.Count;
	public event OnInventoryChangedDelegate OnInventoryChanged = delegate { };
	public PlayerInventorySO(int count) {
		items = new List<Item>(amountOfSlots);
	}

	public bool isFull { get { return (slotsCount > amountOfSlots) ? true : false; } }

	public void AddItem(Item item) {
		if (isFull) return;

		items.Add(item);
	}

	public void RemoveItem(Item item) {

		items.Remove(item);
	}


}