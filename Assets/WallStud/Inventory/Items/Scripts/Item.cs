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
	public Sprite icon;
}