using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Menu Button Settings", menuName = "WallStud/Menus/Menu Button Settings")]
public class MenuButtonProperties : ScriptableObject
{
  public string displayName;
  public string uxmlName;
  public UnityEvent OnClick;



}
