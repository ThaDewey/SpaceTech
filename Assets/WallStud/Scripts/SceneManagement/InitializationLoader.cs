using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for starting the game by loading the persistent managers scene 
/// and raising the event to load the Main Menu
/// </summary>

public class InitializationLoader : MonoBehaviour
{
	[SerializeField] private GameSceneSO _managersScene = default;
	[SerializeField] private GameSceneSO _menuToLoad = default;


	private void Start()
	{
		//Load the persistent managers scene
		//_managersScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadEventChannel;
	}

}
