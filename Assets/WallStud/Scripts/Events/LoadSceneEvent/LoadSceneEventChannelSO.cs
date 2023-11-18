using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one int argument.
/// Example: An Achievement unlock event, where the int is the Achievement ID.
/// </summary>

[CreateAssetMenu(menuName = "Game/Events/Load Event Channel")]
public class LoadSceneEventChannelSO : DescriptionBaseSO
{
	public UnityAction<GameSceneSO> OnLoadingRequested;

	public void RaiseEvent(GameSceneSO gameScene)
	{
		if (OnLoadingRequested != null)
		{
			OnLoadingRequested.Invoke(gameScene);
		}
		else
		{
			Debug.LogWarning("A Scene loading was requested, but nobody picked it up. " +
				"Check why there is no SceneLoader already present, " +
				"and make sure it's listening on this Load Event channel.");
		}
	}
}
