using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{

	[SerializeField] private InputActionReference _interact;
	[SerializeField] private bool _isInteractable;
	[SerializeField] private bool _isInteracting;
	[SerializeField] private IInteract interact;

	private void OnEnable() {

		_interact.action.Enable();
		_interact.action.started += OnStarted;
		_interact.action.performed += OnPerformed;
		_interact.action.canceled += OnCanceled;

	}



	private void OnDisable() {
		_interact.action.started -= OnStarted;
		_interact.action.performed -= OnPerformed;
		_interact.action.canceled -= OnCanceled;
		_interact.action.Disable();
	}
	private void OnPerformed(InputAction.CallbackContext context) {
		if (!_isInteractable && !_isInteracting) return;
		interact.PerformedInteract();

	}

	private void OnStarted(InputAction.CallbackContext context) {
		if (!_isInteractable) return;

		interact.StartInteract();
		_isInteracting = true;
	}


	private void OnCanceled(InputAction.CallbackContext context) {
		if (!_isInteractable) return;
		_isInteracting = false;
		interact.CancelInteract();


	}

	public void OnCollided(GameObject GO) {
		Debug.Log("Interacted with " + GO.name);
		_isInteractable = true;
		interact = GO.GetComponent<IInteract>();

	}


	public void SetAsInteracting(bool b) {
		_isInteracting = b;
	}
	public void Test(string msg) {
		Debug.Log(msg);
	}

}
