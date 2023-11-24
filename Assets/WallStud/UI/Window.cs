using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Base Class for accessing the UI element uiDocuments  during runtime.
/// </summary>
public class Window : View_Base {


	[SerializeField] protected bool hideOnStart = true;
	protected Button close;

	protected override void Awake() {
		doc = GetComponent<UIDocument>();
		root = doc.rootVisualElement;
		Init();
	}




	protected virtual void Init() {
		EvaluateHideOneStart();

		close = root.GetButton("btn_close");
	}

	protected void EvaluateHideOneStart() {
		if (!hideOnStart) return;
		root.Hide();

	}


	public virtual void CloseWindow() {
		root.Hide();
		isOpen = false;
	}
	public virtual void OpenWindow() {
		root.Show();
		isOpen = true;
	}
	public virtual void MinimizeWindow() {
		throw new System.NotImplementedException();
	}


	public override void UpdateDisplay() {
		throw new System.NotImplementedException();
	}
}
