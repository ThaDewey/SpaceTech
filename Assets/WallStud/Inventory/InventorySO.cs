using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class InventorySO : ScriptableObject {


	public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

	[SerializeField] private List<InventoryItem> inventoryItems;

	[field: SerializeField] public int Size { get; private set; } = 10;

	public void Initialize() { }


}
