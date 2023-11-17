using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument doc;
    [SerializeField] private MenuProperties menuProperties;
    [SerializeField] private VisualElement root;

	public void Start() {
		

        doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        var menu = root.Q<VisualElement>("MenuHolder");

        foreach ( MenuButtonProperties button in menuProperties.buttons) {
        Button  btn = new Button();
            btn.name = button.uxmlName;
            btn.text = button.displayName;
            btn.clicked += button.OnClick.Invoke;

			menu.Add(btn);

        }

	}




}