using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Allows a "cold start" in the editor, when pressing Play and not passing from the Initialisation scene.
/// </summary> 
public class EditorColdStartup : MonoBehaviour
{
#if UNITY_EDITOR
	[SerializeField] private GameSceneSO _thisSceneSO = default;
	[SerializeField] private GameSceneSO _persistentManagersSO = default;
	[SerializeField] private VoidEventChannelSO _onSceneReadyChannel = default;
	[SerializeField] private PathStorageSO _pathStorage = default;
	[SerializeField] private SaveSystem _saveSystem = default;

	private bool isColdStart = false;
	private void Awake()
	{
		if (!SceneManager.GetSceneByName(_persistentManagersSO.sceneName).isLoaded)
		{
			isColdStart = true;

			//Reset the path taken, so the character will spawn in this location's default spawn point
			_pathStorage.lastPathTaken = null;
		}
		CreateSaveFileIfNotPresent();
	}

	private void Start()
	{
		if (isColdStart)
		{
		//	SceneManager.LoadSceneAsync(_persistentManagersSO.sceneIndex, LoadSceneMode.Additive).Completed += LoadEventChannel;

		}
		CreateSaveFileIfNotPresent();
	}
	private void CreateSaveFileIfNotPresent()
	{
		if (_saveSystem != null && !_saveSystem.LoadSaveDataFromDisk())
		{
			_saveSystem.SetNewGameData();
		}
	}




#endif
}
