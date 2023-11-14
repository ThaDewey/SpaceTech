using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument doc;

    private Button btn_startGame;

    public void Start()
    {
        var rootElement = doc.rootVisualElement;

        btn_startGame = rootElement.Q<Button>("btn_startGame");
        btn_startGame.clicked += OnButtonClicked;
    }

    private void OnDestroy()
    {
        btn_startGame.clickable.clicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        Debug.Log("OnButtonClicked()");
    }

}