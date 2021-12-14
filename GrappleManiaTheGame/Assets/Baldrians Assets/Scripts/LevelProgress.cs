using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private bool reloadScene;

	private GameObject playerObject;
    void Start()
    {
		SpawnPlayer();
    }

	void SpawnPlayer()
	{
		if (!playerObject)
			playerObject = Instantiate(playerPrefab, StaticProgress.currentCheckpoint, Quaternion.identity);
		else
			playerObject.transform.position = StaticProgress.currentCheckpoint;
	}

	public void PlayerDied()
	{
		if (reloadScene)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		SpawnPlayer();
	}
}
