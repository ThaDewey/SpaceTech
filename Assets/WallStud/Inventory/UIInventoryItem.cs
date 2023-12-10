using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour {


    [SerializeField] private Image img_item;
    [SerializeField] private TMP_Text TXT_quantity;
    [SerializeField] private Image img_Border;


    public event Action<UIInventoryItem> OnItemClicked;
    public event Action<UIInventoryItem> OnDrop;
    public event Action<UIInventoryItem> OnBeginDrag;
    public event Action<UIInventoryItem> OnEndDrag;
    public event Action<UIInventoryItem> OnRightMouseBtnClick;

    public bool empty = true;



    public void Awake() {
        ResetData();
        Deselect();
    }

    public void Select() => Set_Img_Border(true);
    public void Deselect() => Set_Img_Border(false);

    private void Set_Img_Border(bool b) => img_Border.enabled = b;


    public void BeginDrag() {
       if (empty) return;
        OnBeginDrag?.Invoke(this);
    }
    public void Drop() {
        OnDrop?.Invoke(this);
    }
    public void EndDrag() {
        OnEndDrag?.Invoke(this);
    }
    private void OnDeselect() {
        throw new NotImplementedException();
    }
    private void ResetData() {
        this.img_item.gameObject.SetActive(false);
        empty = true;
    }
    public void OnPointerclick(BaseEventData data) {
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right) {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else {
            OnItemClicked?.Invoke(this);
        }
    }
    public void SetData(Sprite s, int quantity) {
        empty = false;
        this.img_item.gameObject.SetActive(true);
        this.img_item.sprite = s;
        this.TXT_quantity.text = quantity + "";
    }



}
