using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour {

	[SerializeField] private InputActionReference interact;
	[SerializeField] private InputActionReference pointer;
	[SerializeField] private bool canInteract;
	[SerializeField] private bool isInteracting;
	[SerializeField] private IInteract interaction;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private bool is2D = true;
	[SerializeField] private List<Collider2D> colliders;


	private void Awake() {
		mainCamera = Camera.main;
	}


	private void OnEnable() {
		EnableAction();
	}



	private void OnDisable() {
		DisableAction();
	}

	private void DisableAction() {
		interact.action.started -= OnStarted;
		interact.action.performed -= OnPerformed;
		interact.action.canceled -= OnCanceled;
		interact.action.Disable();
	}
	private void EnableAction() {
		interact.action.Enable();
		interact.action.started += OnStarted;
		interact.action.performed += OnPerformed;
		interact.action.canceled += OnCanceled;
	}
	private void DetectObject() {
		if (!canInteract) return;

		Debug.Log($"DetectObject()");
		var pointerPos = pointer.action.ReadValue<Vector2>();
		Ray ray = mainCamera.ScreenPointToRay(pointerPos);

		if (is2D) {
			RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
			if (hits2D.collider != null) {
				Debug.Log($"2d hit: {hits2D.collider.name}");
				interaction.PerformedInteract();
			}
		} else {//3d
				//https://www.youtube.com/watch?v=JID7YaHAtKA
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider != null) {
					Debug.Log($"3D hit: {hit.collider.name}");
					interaction.PerformedInteract();
				}
			}
		}
	}

	public virtual void OnCollisionEnter2D(Collision2D collision) {
//		Debug.Log($"OnCollisionEnter2D({collision.collider.name})");


		interaction = collision.collider.GetComponent<IInteract>();



		if (interaction == null) return;

		canInteract = true;

	}

	public virtual void OnCollisionExit2D(Collision2D collision) {
		canInteract = false;
		interaction = null;
	}

	private void OnPerformed(InputAction.CallbackContext context) {
		if (!canInteract && !isInteracting) return;

		DetectObject();
	}

	private void OnStarted(InputAction.CallbackContext context) {
	}


	private void OnCanceled(InputAction.CallbackContext context) {
	}



	
}
