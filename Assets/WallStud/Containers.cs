using System.Collections.Generic;
using UnityEngine;

public class Containers : MonoBehaviour, IInteract {

	public int max;
	public int slots;
	public List<Item> contents;
	public bool isOpen;
	public bool isLocked;



	public virtual void OnOpen() {
		if (isLocked || isOpen) return;
		Debug.Log("OnOpen()");
	}
	public virtual void OnClose() {
		Debug.Log("OnClose()");
	}

	public void PerformedInteract() { }

	public void StartInteract() {
		isOpen = true;
		OnOpen();
	}

	public void CancelInteract() {
	}
}