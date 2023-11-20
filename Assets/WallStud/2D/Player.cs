using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	private AgentAnimations agentAnimations;
	private AgentMover agentMover;
	private Vector2 pointerInput, movementInput;
	private Vector2 PointerIput => pointerInput;
	[SerializeField] private bool isRunning;

	[SerializeField] private InputActionReference movement;
	[SerializeField] private InputActionReference interact;
	[SerializeField] private InputActionReference pointerPosition;
	[SerializeField] private InputActionReference run;


	private void Awake() {
		//agentAnimations = GetComponent<AgentAnimations>();
		agentMover = GetComponent<AgentMover>();
	
		
	}

	private void OnEnable() {
		run.action.Enable();
		run.action.started += OnRun;
		run.action.canceled += OnRun;
	}

	private void OnRun(InputAction.CallbackContext ctx) {
		isRunning = ctx.ReadValueAsButton();
		agentMover.isRunning = isRunning;
	}

	private void Start() {

	}


	


	private void OnDisable() {
		run.action.performed -= OnRun;
		run.action.Disable();
	}


	private void Update() {
		pointerInput = getPointerInput();

		movementInput = movement.action.ReadValue<Vector2>();

		agentMover.MovementInput = movementInput;

		animateCharacter();


	}

	private Vector2 getPointerInput() {
		Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();

		mousePos.z = Camera.main.nearClipPlane;
		return Camera.main.ScreenToWorldPoint(mousePos);



	}

	private void animateCharacter() {
		if (agentAnimations == null) return;


	}
}
