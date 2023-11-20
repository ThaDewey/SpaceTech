using JetBrains.Annotations;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

static class UIToolkitExtensions {
	public static Button GetButton(this VisualElement element, string btn_name) => element.Q<Button>(btn_name);

	public static Label GetLabel(this VisualElement element, string label) => element.Q<Label>(label);

	public static void Show(this VisualElement e) {
		Display(e);
		Visible(e);
	}
	public static void Hide(this VisualElement e) {
		Conceal(e);
		Invisible(e);
	}

	public static void Display(this VisualElement e) => SetDisplay(e, DisplayStyle.Flex);

	public static void Conceal(this VisualElement e) => SetDisplay(e, DisplayStyle.None);


	public static void SetDisplay(this VisualElement e, DisplayStyle s) => e.style.display = s;
	public static void Visible(this VisualElement e) => SetVisibility(e, Visibility.Visible);

	public static void Invisible(this VisualElement e) => SetVisibility(e, Visibility.Hidden);
	public static void SetVisibility(this VisualElement e, Visibility v) => e.style.visibility = v;
	public static void SetBackgroundImage(this VisualElement e, Sprite s) => e.style.backgroundImage = new StyleBackground(s);

	public static Button CreateButton(this VisualElement element, string buttonName) {
		Button but = new Button();
		but.name = buttonName;
		but.text = buttonName;
		element.Add(but);
		return but;

	}
	public static Button CreateButton(this VisualElement e, string buttonName,Sprite s) {
		Debug.Log(s);

		Button but = new Button();
		but.name = buttonName;
		but.text = buttonName;
		SetBackgroundImage(but, s);
		e.Add(but);
		return but;
	}
	public static Button CreateButton(this VisualElement e, string buttonName, Sprite s, string className) {
		Debug.Log(s);
		Button but = new Button();
		but.name = buttonName;
		but.text = buttonName;
		SetBackgroundImage(but, s);
		but.AddToClassList(className);
		e.Add(but);
		return but;
	}


}
