using System.ComponentModel;
using System.Data.Common;
using UnityEngine;



/// <summary>
/// Item data is a data container for actual items in the game
/// </summary>
[CreateAssetMenu(fileName = "Item Data", menuName = "SpaceTech/Inventory/ItemData", order = 1)]
public class ItemData : ScriptableObject {

	public string itemName;
	public string description;
	public Sprite sprite;
	public int itemId = 0;
	public bool stackable = true;
	public ItemType itemType;
	public int capacity=64;


}