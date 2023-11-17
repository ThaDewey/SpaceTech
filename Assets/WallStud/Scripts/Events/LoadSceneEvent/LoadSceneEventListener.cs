using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>
[System.Serializable]
public class LoadSceneEvent : UnityEvent<GameSceneSO>
{

}

/// <summary>
/// A flexible handler for int events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>
public class LoadSceneEventListener : MonoBehaviour
{
	[SerializeField] private LoadSceneEventChannelSO _channel = default;

	public LoadSceneEvent OnEventRaised;

	private void OnEnable()
	{
		if (_channel != null)
			_channel.OnLoadingRequested += Respond;
	}

	private void OnDisable()
	{
		if (_channel != null)
			_channel.OnLoadingRequested -= Respond;
	}

	private void Respond(GameSceneSO gs)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(gs);
	}
}
