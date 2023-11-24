
using UnityEngine;
using UnityEngine.UIElements;

public abstract class View_Base : MonoBehaviour
{
	protected UIDocument doc;
	protected VisualElement root;



	public bool isOpen = false;

	protected abstract void Awake();


	public abstract void UpdateDisplay();



}
