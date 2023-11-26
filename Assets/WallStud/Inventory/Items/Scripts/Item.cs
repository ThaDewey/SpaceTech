using System.ComponentModel;
using UnityEngine;

/// <summary>
/// i do not know...we should probably update this
/// </summary>
[CreateAssetMenu(fileName = "Item", menuName = "SpaceTech/Inventory/Item", order = 1)]
public class Item : ScriptableObject {

	public int itemId;
	public ItemType itemType;
	public int amount;
	public string GUID;
	public string Title;
	public bool CanDrop;
	public string _amount =>amount.ToString();
	public Sprite icon;
}

public enum InventoryChangeType {
	Pickup,
	Drop
}

public delegate void OnInventoryChangedDelegate(Item item, InventoryChangeType change);
