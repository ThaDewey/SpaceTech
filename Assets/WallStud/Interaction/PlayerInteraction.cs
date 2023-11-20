using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour {

	[SerializeField] private InputActionReference interact;
	[SerializeField] private InputActionReference pointer;
	[SerializeField] private bool isInteractable;
	[SerializeField] private bool isInteracting;
	[SerializeField] private IInteract interaction;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private bool is2D = true;
	private Collider2D col;
	[SerializeField] private ContactFilter2D filter;
	[SerializeField] private List<Collider2D> colliders;


	private void Awake() {
		mainCamera = Camera.main;
		col = GetComponent<Collider2D>();
	}


	private void OnEnable() {
		EnableAction();
	}

	private void EnableAction() {
		interact.action.Enable();
		interact.action.started += OnStarted;
		interact.action.performed += OnPerformed;
		interact.action.canceled += OnCanceled;
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

	private void DetectObject() {
		Debug.Log($"DetectObject()");
		var pointerPos = pointer.action.ReadValue<Vector2>();
		Ray ray = mainCamera.ScreenPointToRay(pointerPos);

		if (is2D) {
			RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
			if (hits2D.collider != null) {
				Debug.Log($"3D hit: {hits2D.collider.name}");
			}
		} else {//3d
				//https://www.youtube.com/watch?v=JID7YaHAtKA
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider != null) {
					Debug.Log($"3D hit: {hit.collider.name}");
				}
			}
		}
	}

	public virtual void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log($"OnCollisionEnter2D({collision.collider.name})");


		interaction = collision.collider.GetComponent<IInteract>();

		if (interaction != null) interaction.PerformedInteract();

	}

	public void OnCollided(GameObject GO) {
		Debug.Log($"OnCollided({GO.name})");
		isInteractable = true;
		interaction = GO.GetComponent<IInteract>();

	}

	private void OnPerformed(InputAction.CallbackContext context) {
		if (!isInteractable && !isInteracting) return;
		interaction.PerformedInteract();

	}

	private void OnStarted(InputAction.CallbackContext context) {
		if (!isInteractable) return;

		interaction.StartInteract();
		isInteracting = true;
	}


	private void OnCanceled(InputAction.CallbackContext context) {
		if (!isInteractable) return;
		isInteracting = false;
		interaction.CancelInteract();


	}



	public void SetAsInteracting(bool b) {
		isInteracting = b;
	}
	public void Test(string msg) {
		Debug.Log(msg);
	}

}
