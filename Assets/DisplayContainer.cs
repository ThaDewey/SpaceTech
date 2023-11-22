using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Controlller for showing Container contents
/// </summary>
public class DisplayContainer : Window {
	private VisualElement containerContents;
	private Button close;
	private Containers container;


	protected override void Awake() {
		container = GetComponent<Containers>();
	}

	// Start is called before the first frame update
	void Start() {
		containerContents = root.Q<VisualElement>("ContainerInventory");

		containerContents.Hide();

	}

	public void OnOpen() {
		close = containerContents.CreateButton("close");
		close.clicked += OnClose;
		close.clicked += GetComponent<Interactable>().EnableInteraction;
		Debug.Log("OnOpen");
		containerContents.Show();
		DisplayContents();
	}
	public void OnClose() {
		Debug.Log("OnClose");
		containerContents.contentContainer.Q<VisualElement>("unity-content-container").Clear();
		containerContents.Hide();
		close.clicked -= OnClose;
	}

	private void DisplayContents() {
		foreach (Item item in container.contents) {
			//Debug.Log(containerContents.contentContainer);
			containerContents.contentContainer.Q<VisualElement>("unity-content-container").CreateButton(item.name, item.icon, "item");

		}
	}
}
