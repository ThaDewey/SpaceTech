using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SpaceTech/Inventory/Item", order = 1)]
public class Item : ScriptableObject {

	public string itemName;
	public int itemId;
	public ItemType itemType;

}

public class ItemType {
}