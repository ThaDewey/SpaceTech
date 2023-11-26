using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Obsolete]
/// <summary>
/// Generates and controls access to the Item Database and Inventory Data
/// </summary>
public class GameController : MonoBehaviour {
	//[SerializeField]public List<Sprite> IconSprites;
	//private static Dictionary<string, Item> m_ItemDatabase = new Dictionary<string, Item>();
	//private List<Item> m_PlayerInventory = new List<Item>();

	//public PlayerInventorySO playerInventory;


	private void Start() {
		//Add the ItemDatabase to the players inventory and let the UI know that some items have been picked up
		//m_PlayerInventory.AddRange(m_ItemDatabase.Values);
		//OnInventoryChanged.Invoke(playerInventory.items.ToArray(), InventoryChangeType.Pickup);
	}

	/// <summary>
	/// Retrieve item details based on the GUID
	/// </summary>
	/// <param name="guid">ID to look up</param>
	/// <returns>Item details</returns>
	/*
	public static Item GetItemByGuid(string guid) {
		if (m_ItemDatabase.ContainsKey(guid)) {
			return m_ItemDatabase[guid];
		}

		return null;
	}
	*/
}