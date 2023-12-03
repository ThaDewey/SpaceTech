using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class SlotManipulator : VisualElement {
	public Image Icon;
	public Label label_Amount;

	public string ItemGuid = "";
	public InventorySlot slot;
	private static bool isDragging;
	protected SlotManipulator target;
	public InventorySlot originalSlot;
	public Item item;
	private VisualElement root { get; set; }
	public DragAndDropManipulator dndManipulator;

	public SlotManipulator(VisualElement parent, Item _item, InventorySlot oldSlot, PointerDownEvent evt) {
		Debug.Log($"{_item.icon}");

		this.name = "manipulator";
		this.target = this;
		this.SetWidthHeight(128);
		this.SetBackgroundImage(_item.icon);
		this.Show();
		this.style.backgroundColor = new StyleColor(Color.red);
		this.style.position = Position.Absolute;

		InventorySystem.slotManipulator = this;
		parent.Add(InventorySystem.slotManipulator);
		dndManipulator = new DragAndDropManipulator(this);
		dndManipulator.RegisterCallbacks();
		SetFields(_item, oldSlot);
		OnPointerDown(evt);
	}

	private void SetFields(Item _item, InventorySlot oldSlot) {
		item = _item;
		this.SetBackgroundImage(item.icon);
		originalSlot = oldSlot;
		root = target.parent;
	}
	public void UpdateManipulator(Item _item, InventorySlot oldSlot, PointerDownEvent evt) {
		Debug.Log("UpdateManipulator");

		this.Show();
		SetFields(_item, oldSlot);
		OnPointerDown(evt);
	}

	public void OnPointerDown(PointerDownEvent evt) {
		if (evt.button != 0) return;
		dndManipulator.PointerDownHandler(evt);
		Debug.Log($"{name} | OnPointerDown");
		RegisterCallback<PointerUpEvent>(OnPointerUp);

	}

	private void OnPointerUp(PointerUpEvent evt) {
		Debug.Log($"OnPointerUp()");
		//Check to see if they are dropping the ghost icon over any inventory slots.
		IEnumerable<InventorySlot> _slots = UIInventory.slots.Where(x => x.worldBound.Overlaps(this.worldBound));
		//Found at least one
		if (_slots.Count() != 0) {
			Debug.Log($"_slots.Count()|{_slots.Count()}| !=0: {_slots.Count() != 0} ");
			InventorySlot closestSlot = _slots.OrderBy(x => Vector2.Distance(x.worldBound.position, this.worldBound.position)).First();

			originalSlot.ClearItem();

			closestSlot.HoldItem(originalSlot.item);

		}
		else {
			originalSlot.HoldItem(originalSlot.item); ;
		}

		isDragging = false;
		originalSlot = null;
		this.style.visibility = Visibility.Hidden;
		UnregisterCallback<PointerUpEvent>(OnPointerUp);
	}

	public bool hasChild() => (childCount > 0) ? true : false;

	public void SetItem(Item _item) {

		Debug.Log($"SetItem({_item})");
		item = _item;
		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
			SerializedObject itemData = new SerializedObject(_item);
			this.Bind(itemData);
		}
		dndManipulator = new DragAndDropManipulator(this);
	}

	public void UpdateIcon(Sprite sprite) {
		if (Icon != null) return;
		//Create a new Image element and add it to the root
		Icon = new Image();
		Icon.sprite = sprite;
		Add(Icon);
		//Add USS style properties to the elements
		Icon.AddToClassList("slotImg");
	}
	public void UpdateAmount(string amount) {
		if (label_Amount != null) return;

		label_Amount = this.CreateLabel("ItemAmount", amount);
	}


	public void HoldItem(Item item) {
		UpdateIcon(item.icon);

		ItemGuid = item.GUID;
	}
	public void DropItem() {
		ItemGuid = "";
		Icon.image = null;
	}


}