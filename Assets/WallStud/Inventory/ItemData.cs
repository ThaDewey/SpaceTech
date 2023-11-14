using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "SpaceTech/Inventory/ItemData", order = 1)]
public class ItemData : ScriptableObject {

	public string itemName;
	public int itemId;
	public ItemType itemType;

}

public class ItemType {
}