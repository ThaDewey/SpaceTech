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
	private static bool m_IsDragging;
	protected VisualElement target;

	public InventorySlot originalSlot;
	public Item item;
	private VisualElement root { get; }
	public DragAndDropManipulator dragAndDropManipulator;

	public SlotManipulator( Item _item, InventorySlot oldSlot , PointerDownEvent evt) {
		Debug.Log("SlotManipulator Constructor");
		item = _item;
		originalSlot = oldSlot;
		Debug.Log(_item);
		this.name = "manipulator";
		this.SetWidthHeight(128);
		this.style.position = Position.Absolute;
		this.Show();
		this.style.backgroundColor = new StyleColor(Color.red);
		//RegisterCallback<GeometryChangedEvent>((e) => { Debug.Log($"{this.layout}"); });
		this.target = this;
		root = target.parent;
		Debug.Log(this.resolvedStyle.width);
		
		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
		}
		dragAndDropManipulator = new DragAndDropManipulator(this);
		OnPointerDown(evt);
	}
	public void UpdateItem(Item _item, InventorySlot oldSlot, PointerDownEvent evt) {
		Debug.Log("SlotManipulator Constructor");
		item = _item;
		originalSlot = oldSlot;
		Debug.Log(_item);
		this.name = "manipulator";
		this.SetWidthHeight(128);
		this.style.position = Position.Absolute;
		this.Show();
		this.style.backgroundColor = new StyleColor(Color.red);

		if (item != null) {
			UpdateIcon(item.icon);
			UpdateAmount(item._amount);
		}
		//RegisterCallback<PointerDownEvent>(OnPointerDown);
		dragAndDropManipulator = new DragAndDropManipulator(this);
		OnPointerDown(evt);
	}
	
	public void OnPointerDown(PointerDownEvent evt) {
		Debug.Log($"{name} | OnPointerDown");
		//Not the left mouse button

		if (evt.button != 0) {
			return;
		}

		//Clear the image
		Icon.image = null;



	}

	/*
	public void PointerDownHandler(PointerDownEvent evt) {
		targetStartPosition = transform.position;
		pointerStartPosition = evt.position;
		this.CapturePointer(evt.pointerId);
		enabled = true;

		RegisterCallback<PointerUpEvent>(PointerUpHandler);
		RegisterCallback<PointerMoveEvent>(PointerMoveHandler);
	}
	*/
	private Vector2 targetStartPosition { get; set; }

	private Vector3 pointerStartPosition { get; set; }
	private bool enabled { get; set; }
	/*
	private void PointerMoveHandler(PointerMoveEvent evt) {
		if (enabled && this.HasPointerCapture(evt.pointerId)) {
			Vector3 pointerDelta = evt.position - pointerStartPosition;

			this.transform.position = new Vector2(
				Mathf.Clamp(targetStartPosition.x + pointerDelta.x, 0, this.panel.visualTree.worldBound.width),
				Mathf.Clamp(targetStartPosition.y + pointerDelta.y, 0, this.panel.visualTree.worldBound.height));
		}
	}
	*/
	/*
	private void PointerUpHandler(PointerUpEvent evt) {
		if (enabled && this.HasPointerCapture(evt.pointerId)) {
			this.ReleasePointer(evt.pointerId);
			UnregisterCallback<PointerUpEvent>(PointerUpHandler);
			UnregisterCallback<PointerMoveEvent>(PointerMoveHandler);
		}

	}
	*/

	/*
	private void OnPointerUp(PointerUpEvent evt) {
		Debug.Log($"OnPointerUp()");
		if (!m_IsDragging) {
			Debug.Log($"not dragging");
			return;
		} else {
			Debug.Log($"GO ON");
		}

		//Check to see if they are dropping the ghost icon over any inventory slots.
		IEnumerable<InventorySlot> _slots = UIInventory.slots.Where(x => x.worldBound.Overlaps(this.worldBound));
		//Found at least one
		if (_slots.Count() != 0) {
			InventorySlot closestSlot = _slots.OrderBy(x => Vector2.Distance(x.worldBound.position, this.worldBound.position)).First();

			//Set the new inventory slot with the data
			closestSlot.HoldItem(originalSlot.item);

			//Clear the original slot
			originalSlot.DropItem();
		}
		//Didn't find any (dragged off the window)
		else {
			originalSlot.Icon.image = originalSlot.Icon.image;
		}
		//Clear dragging related visuals and data
		m_IsDragging = false;
		originalSlot = null;
		this.style.visibility = Visibility.Hidden;
		UnregisterCallback<PointerUpEvent>(OnPointerUp);
		UnregisterCallback<PointerMoveEvent>(OnPointerMove);
	}
	*/
	/*
	public void StartDrag() {
		Debug.Log("StartDrag");


		Vector2 pos = Mouse.current.position.ReadValue();


		float centerY = originalSlot.layout.height / 2;
		float centerX = originalSlot.layout.width / 2;
		Debug.Log($"{this.layout.height}");
		Debug.Log($"{centerY}");


		pos.y = Screen.height - (pos.y + centerY);
		pos.x = pos.x - centerX;
		Debug.Log($"pos:{pos.x}, {pos.y}");
		this.transform.position = pos;

		m_IsDragging = true;


		Debug.Log(originalSlot);

		StyleBackground bg = new StyleBackground(originalSlot.Icon.sprite);

		//Set the image
		this.style.backgroundImage = bg;
		//Flip the visibility on
		this.style.visibility = Visibility.Visible;
		RegisterCallback<PointerUpEvent>(OnPointerUp);
		RegisterCallback<PointerMoveEvent>(OnPointerMove);
		Debug.Log("StartDrag END");
	}
	*/
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
		dragAndDropManipulator = new DragAndDropManipulator(this);
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