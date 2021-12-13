using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DummyLevelCompleter : MonoBehaviour
{
	[SerializeField] private int levelNumber;
    public void LevelWon()
	{
		if (StaticProgress.levelsCleared < levelNumber)	//	In case you can replay levels, we don't want to set progress back to lower than where we are
			StaticProgress.levelsCleared = levelNumber;

		SceneManager.LoadScene("HubworldExample");
	}
}
