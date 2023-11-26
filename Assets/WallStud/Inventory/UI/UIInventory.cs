using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using Unity.VisualScripting;

/// <summary>
/// Base Class for accessing the UI element uiDocuments  during runtime.
/// </summary>
public class UIInventory : Window {
	[SerializeField] private PlayerInventorySO myInventory;
	private List<InventorySlot> slots = new List<InventorySlot>();
	private List<Item> inventory => myInventory.items;

	//Global variable
	private static VisualElement m_GhostIcon;
	private static bool m_IsDragging;
	private static InventorySlot m_OriginalSlot;

	private VisualElement ve_content;
	private VisualElement ve_inventory;
	private VisualElement ve_description;

	protected override void Awake() {
		base.Awake();

	}

	protected void Start() {
		m_GhostIcon = ve_content.CreateVisualElement("GhostIcon");

		m_GhostIcon.style.position = Position.Absolute;
		StyleLength width = new StyleLength();
		width = 128;

		m_GhostIcon.style.width = width;
		m_GhostIcon.style.height = width;
		m_GhostIcon.style.visibility = Visibility.Visible;
		m_GhostIcon.style.backgroundColor = new StyleColor(Color.red);



		myInventory.OnInventoryChanged += GameController_OnInventoryChanged;
		m_GhostIcon.RegisterCallback<PointerMoveEvent>(OnPointerMove);
		m_GhostIcon.RegisterCallback<PointerUpEvent>(OnPointerUp);
	}

	protected override void Init() {
		base.Init();
		ve_inventory = root.GetElement("Inventory");
		ve_content = ve_inventory.GetElement("InventoryContent");
		ve_description = ve_inventory.GetElement("InventoryDescription");
	}

	[Button]
	public override void OpenWindow() {
		base.OpenWindow();
		UpdateDisplay();
	}

	public override void UpdateDisplay() {
		Debug.Log($"UpdateDisplay");
		Debug.Log($"inventory.Count: {inventory.Count}");
		List<InventorySlot> mySlots = ve_content.Query<InventorySlot>("slot").ToList();

		for (int i = 0; i < inventory.Count; i++) {
			InventorySlot slot = mySlots[i];
			Item item = inventory[i];
			mySlots[i].SetItem(item);
			//slot.name = item.name;
			mySlots[i].RegisterCallback<PointerEnterEvent>((e) => Debug.Log($"{mySlots[i].name} ENTER)")); ;
			mySlots[i].RegisterCallback<PointerLeaveEvent>((e) => Debug.Log($"{mySlots[i].name} EXIT)"));
		}


		Button close = ve_description.GetOrCreateButton("Close");
		close.clicked += CloseWindow;
	}

	public void InitializeInventoryUI() {
		ve_content.Clear();


		for (int i = 0; i < myInventory.amountOfSlots; i++) {
			InventorySlot slot = CreateSlot();

			slots.Add(slot);
		}
	}



	public InventorySlot CreateSlot() {
		///Debug.Log("CreateSlot()");
		InventorySlot slot = new InventorySlot();

		slot.name = "slot";
		slot.AddToClassList("slot");

		ve_content.Add(slot);

		return slot;
	}



	public static void StartDrag(Vector2 position, InventorySlot originalSlot) {
		Debug.Log($"StartDrag()");
		//Set tracking variables
		m_IsDragging = true;
		m_OriginalSlot = originalSlot;
		//Set the new position
		m_GhostIcon.style.top = position.y - m_GhostIcon.layout.height / 2;
		m_GhostIcon.style.left = position.x - m_GhostIcon.layout.width / 2;
		StyleBackground bg = new StyleBackground(originalSlot.Icon.sprite);

		//Set the image
		m_GhostIcon.style.backgroundImage = bg;
		//Flip the visibility on
		m_GhostIcon.style.visibility = Visibility.Visible;
	}
	private void OnPointerMove(PointerMoveEvent evt) {
		Debug.Log($"OnPointerMove()");
		//Only take action if the player is dragging an item around the screen
		if (!m_IsDragging) {
			return;
		}
		//Set the new position
		m_GhostIcon.style.top = evt.position.y - m_GhostIcon.layout.height / 2;
		m_GhostIcon.style.left = evt.position.x - m_GhostIcon.layout.width / 2;
	}
	private void OnPointerUp(PointerUpEvent evt) {
		Debug.Log($"OnPointerUp()");
		if (!m_IsDragging) 	return;

		//Check to see if they are dropping the ghost icon over any inventory slots.
		IEnumerable<InventorySlot> _slots = slots.Where(x => x.worldBound.Overlaps(m_GhostIcon.worldBound));
		//Found at least one
		if (_slots.Count() != 0) {
			InventorySlot closestSlot = _slots.OrderBy(x => Vector2.Distance
			   (x.worldBound.position, m_GhostIcon.worldBound.position)).First();

			//Set the new inventory slot with the data
			closestSlot.HoldItem(m_OriginalSlot.item);

			//Clear the original slot
			m_OriginalSlot.DropItem();
		}
		//Didn't find any (dragged off the window)
		else {
			m_OriginalSlot.Icon.image =  m_OriginalSlot.Icon.image;
		}
		//Clear dragging related visuals and data
		m_IsDragging = false;
		m_OriginalSlot = null;
		m_GhostIcon.style.visibility = Visibility.Hidden;
	}

	private void GameController_OnInventoryChanged(Item item, InventoryChangeType change) {
		//Loop through each item and if it has been picked up, add it to the next empty slot
		Debug.Log($"GameController_OnInventoryChanged({item},{change})");

		if (change == InventoryChangeType.Pickup) {
			InventorySlot emptySlot = new InventorySlot();
			emptySlot.item = item;
			emptySlot.Icon.sprite = item.icon;
			emptySlot.ItemGuid = item.GUID;

			if (emptySlot != null) {
				emptySlot.HoldItem(item);
			}
		}
	}
}
