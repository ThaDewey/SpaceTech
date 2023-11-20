using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class Containers : MonoBehaviour, IInteract {

	public ItemLibrary itemPool;

	public int max;
	public int slots;
	public List<Item> contents;
	public bool isOpen;
	public bool isLocked;

	private void populateContainer() {
		int randomAmount = Random.Range(1, max);
		Debug.Log($"randomAmount:{randomAmount}");
		contents = itemPool.PopulateContainer(randomAmount);
	}

	private void Awake() {
		populateContainer();
	}


	public virtual void OnOpen() {
		if (isLocked || isOpen) return;
		Debug.Log("OnOpen()");
	}
	public virtual void OnClose() {
		isOpen = false;
		Debug.Log("OnClose()");
	}

	public void PerformedInteract() { }

	public void StartInteract() {

	}

	public void CancelInteract() {

		isOpen = true;
		OnOpen();
	}
}