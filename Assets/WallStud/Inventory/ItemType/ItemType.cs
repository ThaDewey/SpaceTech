using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemType", menuName = "SpaceTech/Inventory/ItemType", order = 1)]
public class ItemType : ScriptableObject {

	public Sprite icon;
	public int id;
	[TextArea]	public string description;


}