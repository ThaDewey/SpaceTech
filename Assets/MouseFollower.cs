using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

//TODO: change classe/name to UIInventoryCursor
public class MouseFollower : MonoBehaviour {
    private Canvas canvas;
    private Camera mainCam;
    private UIInventoryItem item;

    [SerializeField] private InputActionReference mouse;
    public void OnEnable() {
        //Debug.Log("OnEnable");
        EnableAction();
    }
    public void Awake() {
        canvas = transform.root.GetComponent<Canvas>();
        mainCam = Camera.main;
        item = GetComponentInChildren<UIInventoryItem>();

    }
    public void OnDisable() => DisableAction();

    private void DisableAction() {
        mouse.action.Disable();
    }

    public void EnableAction() {
        //Debug.Log("EnableAction");
        mouse.action.Enable();

    }


    public void Update() {
        var mousePos = mouse.action.ReadValue<Vector2>();
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, mousePos, canvas.worldCamera, out position);
        transform.position = canvas.transform.TransformPoint(position);
    }

    public void Toggle(bool b) {
        Debug.Log($"Toggle({b})");
        gameObject.SetActive(b);

    }
    public void SetData(Sprite sprite, int quantity) {

        item.SetData(sprite, quantity);
    }


}
