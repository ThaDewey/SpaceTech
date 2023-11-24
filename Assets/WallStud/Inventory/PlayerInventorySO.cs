using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
[InlineEditor, CreateAssetMenu(fileName = "Player Inventory", menuName = "SpaceTech/Inventory/Player Inventory")]
public class PlayerInventorySO : ScriptableObject {

	public int amountOfSlots;
	public List<Item> slots;

	public PlayerInventorySO(int count) {
		slots = new List<Item>(amountOfSlots);
	}



}