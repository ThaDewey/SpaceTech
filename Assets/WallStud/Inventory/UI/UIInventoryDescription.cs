using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDescription : MonoBehaviour {


    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text txt_title;
    [SerializeField] private TMP_Text txt_Description;

    public void Awake() {

        ResetDescription();
    }

    public void ResetDescription() {
        itemImage.gameObject.SetActive(false);
        txt_title.text = string.Empty;
        txt_Description.text = string.Empty;
    }
    public void SetDescription(Sprite sprite, string itemName, string itemDescription) {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = sprite;
        txt_title.text = itemName;
        txt_Description.text = itemDescription;
    }

}
