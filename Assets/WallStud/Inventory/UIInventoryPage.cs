using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour {

    public bool isOpen;
    [SerializeField] private UIInventoryItem itemPrefab;
    [SerializeField] private MouseFollower cursor;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private UIInventoryDescription itemDescription;
    [SerializeField] private List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    private void OnEnable() {

    }
    private void Awake() {
        Hide();
        itemDescription.ResetDescription();
    }
    private void Start() {
    }

    public void InitializeInventoryUI(int inventorySize) {
        for (int i = 0; i < inventorySize; i++) {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnBeginDrag += HandleBeginDrag;
            uiItem.OnDrop += HandleSwap;
            uiItem.OnEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }


    public Sprite image;
    public int quantity;
    public string title, description;

    private void HandleShowItemActions(UIInventoryItem item) {
        Debug.Log($"HandleShowItemActions: {item.name}");
    }

    private void HandleBeginDrag(UIInventoryItem item) {
        Debug.Log($"HandleBeginDrag: {item.name}");
        cursor.Toggle(true);
        cursor.SetData(image, quantity);
    }
    private void HandleEndDrag(UIInventoryItem item) {
           Debug.Log($"HandleEndDrag: {item.name}");
        cursor.Toggle(false);
    }


    private void HandleSwap(UIInventoryItem item) {
        Debug.Log($"HandleSwap: {item.name}");
    }





    private void HandleItemSelection(UIInventoryItem item) {
        itemDescription.SetDescription(image, title, description);
        listOfUIItems[0].Select();
    }


    public void Show() {
        isOpen = true;
        gameObject.SetActive(true);
        itemDescription.ResetDescription();
        listOfUIItems[0].SetData(image, quantity);
    }
    public void Hide() {
        isOpen = false;
        gameObject.SetActive(false);
    }
}
