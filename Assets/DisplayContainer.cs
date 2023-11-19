using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Controlller for showing Container contents
/// </summary>
public class DisplayContainer : MonoBehaviour {
	[SerializeField] private UIDocument document;
	[SerializeField] private VisualElement root;
	[SerializeField] private VisualElement containerContents;
	[SerializeField] private Containers container;


	private void Awake() {
		document = GetComponent<UIDocument>();
		root = document.rootVisualElement;
	}

	// Start is called before the first frame update
	void Start() {
		containerContents = root.Q<VisualElement>("ContainerInventory");
		DisplayContents();
	}

	// Update is called once per frame
	void Update() {

	}

	public void OnOpen() { 
	//containerContents.style.display.
	
	}


	private void DisplayContents() {
		foreach (Item item in container.contents) {
			root.CreateButton(containerContents, item.name);
		}
	}
}
