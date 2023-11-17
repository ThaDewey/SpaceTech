using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is a base class which contains what is common to all game scenes (Locations, Menus, Managers)
/// </summary>
[CreateAssetMenu(menuName = "Game/Inventory/Player Inventory ")]
public class PlayerInventory : ScriptableObject
{
	public int slots = 1;

	public List<Item> inventory;

	private void Awake()
	{
		inventory = new List<Item>(new Item[slots]);
	}

	public void Add(Item _item)
	{
		bool exists = DoesItemExist(_item);
		if (exists) return;

	}
	public void Remove(Item item) { }

	public bool DoesItemExist(Item item) => inventory.Contains(item);
	public bool IsFull(Item item)
	{
		if (!DoesItemExist(item)) return false;


		Item myItem = inventory.Find(x => x.data.itemId == item.data.itemId);
		if (item.amount < item.data.capacity)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

}
