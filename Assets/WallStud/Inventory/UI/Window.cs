using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Base Class for accessing the UI element uiDocuments  during runtime.
/// </summary>
public class Window : MonoBehaviour {

	protected UIDocument doc;
	protected VisualElement root;
	protected bool hideOnStart = true;

	protected virtual void Awake() {
		doc = GetComponent<UIDocument>();
		root = doc.rootVisualElement;
		Init();
	}




	protected virtual void Init() {

	}


	public virtual void CloseWindow() { }
	public virtual void OpenWindow() { }
	public virtual void MinimizeWindow() { }
	public virtual void UpdateDisplay() { }
}
