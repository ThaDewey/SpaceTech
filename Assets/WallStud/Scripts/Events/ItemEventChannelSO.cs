using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// This class is used for Item interaction events.
/// Example: Pick up an item passed as paramater
/// </summary>

[CreateAssetMenu(menuName = "Events/UI/Item Event Channel")]
public class ItemEventChannelSO : DescriptionBaseSO
{
	/*
	public UnityAction<Item> OnEventRaised;
	
	public void RaiseEvent(Item item)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(item);
	}
	*/
}

