using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

	private Dictionary<ItemData, Item> itemDict;

	public List<Item> inventory { get; private set; }

	private void Awake() {
		inventory = new List<Item>();
		itemDict = new Dictionary<ItemData, Item>();
	}

	public void Add(ItemData refData) { 
	
	}


}
