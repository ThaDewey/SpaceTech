using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : CollidableObject {

	[SerializeField] private InputActionReference interact;
	[SerializeField] private UnityEvent _OnStarted;
	[SerializeField] private UnityEvent _OnPerformed;
	[SerializeField] private UnityEvent _OnCanceled;
	[SerializeField] private bool _isInteractable;
	[SerializeField] private bool _isInteracting;

	private void OnEnable() {

		interact.action.Enable();
		interact.action.started += OnStarted;
		interact.action.performed += OnPerformed;
		interact.action.canceled += OnCanceled;

	}



	private void OnDisable() {
		interact.action.started -= OnStarted;
		interact.action.performed -= OnPerformed;
		interact.action.canceled -= OnCanceled;
		interact.action.Disable();
	}
	private void OnPerformed(InputAction.CallbackContext context) {
		if (!_isInteractable && !_isInteracting) return;

		_OnPerformed.Invoke();
	}

	private void OnStarted(InputAction.CallbackContext context) {
		if (!_isInteractable) return;

		_isInteracting = true;
		_OnStarted.Invoke();
	}


	private void OnCanceled(InputAction.CallbackContext context) {
		if (!_isInteractable) return;
		_isInteracting = false;

		_OnCanceled.Invoke();

	}

	public override void OnCollided(GameObject GO) {
		Debug.Log("Interacted with " + GO.name);
		_isInteractable = true;

	}


	public void SetAsInteracting(bool b) {
		_isInteracting = b;
	}
	public void Test(string msg) { 
		Debug.Log(msg);
	}

}
