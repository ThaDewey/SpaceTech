using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument doc;
    [SerializeField] private MenuProperties menuProperties;
    [SerializeField] private VisualElement root;


	[SerializeField] private StringEventChannelSO _channel = default;

	public StringEvent OnEventRaised;


	public void Start() {

        doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        var menu = root.Q<VisualElement>("MenuHolder");
        Debug.Log(menu);
        Debug.Log(menuProperties.buttons.Count);

        foreach ( MenuButtonProperties button in menuProperties.buttons) {
        Button  btn = new Button();
            btn.name = button.uxmlName;
            btn.text = button.displayName;
            btn.clicked += button.OnClick.Invoke;

			menu.Add(btn);

        }

	}



	private void OnEnable() {
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable() {
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond(string value) {
		if (OnEventRaised != null) OnEventRaised.Invoke(value);
	}

	public void Test(string s) {
		Debug.Log(s);
	}




}