using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.GUI {

    /// <summary>
    /// a class that displays the inventory as a page.
    /// </summary>
    public class UIInventoryPage : MonoBehaviour {

        public bool isOpen;
        [SerializeField] private UIInventoryItem itemPrefab;
        [SerializeField] private MouseFollower cursor;
        [SerializeField] private RectTransform contentPanel;
        [SerializeField] private UIInventoryDescription itemDescription;
        [SerializeField] private List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

        private int currentlyDraggedItemIndex = -1;

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
        public Sprite image2;
        public int quantity;
        public string title, description;

        private void HandleShowItemActions(UIInventoryItem itemUI) {
            Debug.Log($"HandleShowItemActions: {itemUI.name}");


        }

        private void HandleBeginDrag(UIInventoryItem itemUI) {
            Debug.Log($"HandleBeginDrag: {itemUI.name}");

            int index = listOfUIItems.IndexOf(itemUI);

            if (index == -1) return;

            currentlyDraggedItemIndex = index;
            
            cursor.Toggle(true);
            cursor.SetData(index == 0 ? image : image2, quantity);
        }
        private void HandleEndDrag(UIInventoryItem itemUI) {
            Debug.Log($"HandleEndDrag: {itemUI.name}");
            cursor.Toggle(false);
        }


        private void HandleSwap(UIInventoryItem itemUI) {
            Debug.Log($"HandleSwap: {itemUI.name}");

                int index = listOfUIItems.IndexOf(itemUI);

                if(index == -1){
                    cursor.Toggle(false);
                    currentlyDraggedItemIndex = -1;
                    return;
                }

                listOfUIItems[currentlyDraggedItemIndex].SetData(index == 0 ? image : image2, quantity);
                listOfUIItems[index].SetData(index == 0 ? image : image2, quantity);
                cursor.Toggle(false);
                currentlyDraggedItemIndex = -1;

        }





        private void HandleItemSelection(UIInventoryItem itemUI) {
            itemDescription.SetDescription(image, title, description);
            listOfUIItems[0].Select();
        }


        public void Show() {
            isOpen = true;
            gameObject.SetActive(true);
            itemDescription.ResetDescription();
            listOfUIItems[0].SetData(image, quantity);
            listOfUIItems[1].SetData(image2, quantity);
        }
        public void Hide() {
            isOpen = false;
            gameObject.SetActive(false);
        }
    }

}