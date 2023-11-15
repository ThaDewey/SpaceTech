using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>
[System.Serializable]
public class StringEvent : UnityEvent<string> { }

/// <summary>
/// A flexible handler for int events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>
public class StringEventListener : MonoBehaviour
{
	[SerializeField] private StringEventChannelSO _channel = default;

	public StringEvent OnEventRaised;

	private void OnEnable()
	{
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable()
	{
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond(string value)
	{
		if (OnEventRaised != null) OnEventRaised.Invoke(value);
	}

	public void Test(string s) {
		Debug.Log(s);
	}
}
