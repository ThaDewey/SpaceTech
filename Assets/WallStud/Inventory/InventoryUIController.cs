using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InventoryUIController : MonoBehaviour {
	//[SerializeField] private Inventory inv;
	[SerializeField] private UIInventoryPage inventoryUI;
	//[SerializeField] private UIInventory ui;
	[SerializeField] private InputActionReference reference;
	[SerializeField] private int inventorySize = 8;
	[SerializeField] private MouseFollower cursor;


	public void OnEnable() {
		//Debug.Log("OnEnable");
		EnableAction();
		cursor.Toggle(false);
	}

	public void Start() {
		inventoryUI.InitializeInventoryUI(inventorySize);
	}

	public void OnDisable() {
		DisableAction();
	}

	private void DisableAction() {
		reference.action.canceled -= Action_Canceled;
		reference.action.Disable();
	}

	public void EnableAction() {
		//Debug.Log("EnableAction");
		reference.action.Enable();
		reference.action.canceled += Action_Canceled;
	}

	private void Action_Canceled(InputAction.CallbackContext obj) {
		//	Debug.Log("Action_Canceled");
		if (inventoryUI.isOpen) {
			//ui.CloseWindow();
			inventoryUI.Hide();
		}
		else {
			inventoryUI.Show();
			//ui.OpenWindow();
		}
	}
}
