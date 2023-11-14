using System.ComponentModel;
using UnityEngine;



/// <summary>
/// Item data is a data container for actual items in the game
/// </summary>
[CreateAssetMenu(fileName = "Item Data", menuName = "SpaceTech/Inventory/ItemData", order = 1)]
public class ItemData : ScriptableObject {

	public string itemName;
	public int itemId;
	public ItemType itemType;

}

public class ItemType {
}