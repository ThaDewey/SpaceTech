using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
[InlineEditor, CreateAssetMenu(fileName = "Player Inventory", menuName = "SpaceTech/Inventory/Player Inventory")]
public class PlayerInventorySO : ScriptableObject {

	public List<Item> inventory;

	public PlayerInventorySO() {
		inventory = new List<Item>();

	}



}