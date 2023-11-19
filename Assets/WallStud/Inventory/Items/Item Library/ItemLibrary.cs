using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using UnityEngine;



/// <summary>
/// Item data is a data container for actual items in the game
/// </summary>
[CreateAssetMenu(fileName = "Item Library", menuName = "SpaceTech/Inventory/Item Library ", order = 1)]
public class ItemLibrary : ScriptableObject {

	public List<Item> itemLibrary = new List<Item>();

	[Button]
	private void OrganizeLibrary() {

		foreach (Item item in itemLibrary) {
			int index = itemLibrary.IndexOf(item);
			item.itemId = index;
		}
	}

	private Item RandomItem() {
		int index = Random.Range(0, itemLibrary.Count);
		return itemLibrary[index];
	}

	public List<Item> PopulateContainer(int amountRequested) {
		List<Item> container = new List<Item>();

		for (int i = 0; i < amountRequested; i++) {
			container.Add(RandomItem());
		}

		return container;
	}


}