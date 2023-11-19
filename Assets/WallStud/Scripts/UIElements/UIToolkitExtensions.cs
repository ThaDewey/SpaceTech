using UnityEngine;
using UnityEngine.UIElements;

static class UIToolkitExtensions
{
    public static Button GetButton(this VisualElement element, string btn_name) => element.Q<Button>(btn_name);

    public static Label GetLabel(this VisualElement element, string label) => element.Q<Label>(label);


    public static Button CreateButton(this VisualElement element,VisualElement parent, string buttonName) { 
        Button but = new Button();
        but.name = buttonName;
        but.text = buttonName;
        parent.Add(but);
        return but;

    }


}
