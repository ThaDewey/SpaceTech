using UnityEngine;
using UnityEngine.UIElements;

static class UIToolkitExtensions {

	public const string SCROLL_VIEW_CONTENT = "unity-content-container";


	#region ScrollView

	public static ScrollView GetScrollView(this VisualElement p, string ScrollViewName) => p.Q<ScrollView>(ScrollViewName);
	public static VisualElement GetScrollViewContent(this ScrollView s) => s.contentContainer;



	#endregion


	public static VisualElement GetElement(this VisualElement e, string elementID) => e.Q<VisualElement>(elementID);

	public static Button GetOrCreateButton(this VisualElement e, string btn_name) {
		Button button = GetButton(e, btn_name);

		if (button == null) button = CreateButton(e, btn_name);

		return button;
	}

	public static Label GetOrCreateLabel<T>(this VisualElement e, string label_name, T _text) {
		Label l = GetLabel(e, label_name);
		string msg = _text.ToString();

		if (l == null) { // if there is not label, then  Create one One
			//Debug.Log("We Did not find the label- Make one");
			l = CreateLabel(e, label_name, msg);
			return l;
		}
		else {// retrun what you round
			//Debug.Log("We found the label- no need to make one");
			UpdateLabel(l, msg);
			return l;
		}
	}

	public static void UpdateLabel(this Label l, string _text) => l.text = _text;



	public static Button GetButton(this VisualElement element, string btn_name) => element.Q<Button>(btn_name);

	public static Label GetLabel(this VisualElement element, string label) => element.Q<Label>(label);

	/// <summary>
	/// Show will make the element visible so you and other elements can see it.
	/// </summary>
	/// <param name="e"></param>
	public static void Show(this VisualElement e) {
		Display(e);
		Visible(e);
	}

	/// <summary>
	/// Hide will remove the element from the  to it cannot be see and the other elements will not react to it.
	/// </summary>
	/// <param name="e"></param>
	public static void Hide(this VisualElement e) {
		Conceal(e);
		Invisible(e);
	}

	/// <summary>
	/// the element is on display for all to see. other elements will react to it
	/// </summary>
	/// <param name="e"></param>
	public static void Display(this VisualElement e) => SetDisplay(e, DisplayStyle.Flex);
	/// <summary>
	/// the element is NOT ON display for all to see. other elements WILL NOT react to it
	/// </summary>
	/// <param name="e"></param>
	public static void Conceal(this VisualElement e) => SetDisplay(e, DisplayStyle.None);

	public static void SetDisplay(this VisualElement e, DisplayStyle s) => e.style.display = s;
	public static void Visible(this VisualElement e) => SetVisibility(e, Visibility.Visible);

	/// <summary>
	/// you can see the element, and it other elements will stil react t it
	/// </summary>
	/// <param name="e"></param>
	public static void Invisible(this VisualElement e) => SetVisibility(e, Visibility.Hidden);

	/// <summary>
	/// you CAN NOT see the element, and it other elements will stil react t it
	/// </summary>
	/// <param name="e"></param>
	public static void SetVisibility(this VisualElement e, Visibility v) => e.style.visibility = v;

	/// <summary>
	/// Sets a background image for the provided element
	/// </summary>
	/// <param name="e">the element or parent</param>
	/// <param name="s">the Sprite used for a background if desired.</param>
	/// <param name="bst">Background Size type</param>
	public static void SetBackgroundImage(this VisualElement e, Sprite s, BackgroundSizeType bst = BackgroundSizeType.Cover) {
		BackgroundSize bgSize = new BackgroundSize(bst);
		e.style.backgroundImage = new StyleBackground(s);
		e.style.backgroundSize = new StyleBackgroundSize(bgSize);
	}

	public static Button CreateButton(this VisualElement e, string butName, string className = null, Sprite s = null) {
		Button but = new Button();
		but.name = butName;
		but.text = butName;

		if (s != null) SetBackgroundImage(but, s);

		if (className != null) e.AddToClassList(className);

		e.Add(but);

		return but;

	}
	public static Label CreateLabel(this VisualElement e, string labelName, string msg = null, string classToAdd = null) {
		Label l = new Label();
		l.name = labelName;
		l.text = msg;
		if (classToAdd != null) l.AddToClassList(classToAdd);
		e.Add(l);
		return l;
	}
	public static Label CreateLabel(this VisualElement _l, string labelName, int num, string classToAdd = null) {
		string s = num.ToString();
		Label l = CreateLabel(_l, labelName, s, classToAdd);
		_l.Add(l);
		return l;
	}

	public static VisualElement CreateVisualElement(this VisualElement _e, string elementName, string classToAdd = null, Sprite sprite = null) {
		VisualElement e = new VisualElement();
		e.name = elementName;

		if (classToAdd != null) e.AddToClassList(classToAdd);
		if (sprite != null) {
			SetBackgroundImage(e, sprite);
			e.style.flexGrow = 1;
		}
		_e.Add(e);
		return e;
	}

	public static void SetWidthHeight(this VisualElement ve, int value) {
		StyleLength styleLength = new StyleLength();
		styleLength = value;

		SetWidth(ve, styleLength);
		SetHeight(ve, styleLength);

	}
	public static void SetWidthHeight(this VisualElement ve, int width, int height) {
		StyleLength _width = new StyleLength();
		_width = width;
		StyleLength _height = new StyleLength();
		_height = height;


		SetWidth(ve, _width);
		SetHeight(ve, _height);

	}


	private static void SetWidth(this VisualElement ve, StyleLength styleLength) {
		ve.style.width = styleLength;
	}
	private static void SetHeight(this VisualElement ve, StyleLength styleLength) {

		ve.style.height = styleLength;
	}
}
