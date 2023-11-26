using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InventoryUIController : MonoBehaviour
{
	[SerializeField] private UIInventory ui;
	[SerializeField] private InputActionReference reference;

	public void OnEnable() {
		//Debug.Log("OnEnable");
		EnableAction();
		ui.InitializeInventoryUI();
	}

	public void Start() {
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
		Debug.Log("Action_Canceled");
		Debug.Log($"isOpen: {ui.isOpen}");
		


		if (ui.isOpen) {
			ui.CloseWindow();
		} else { 
			ui.OpenWindow();
		}
	}
}
