using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubSceneManager : MonoBehaviour
{
    public void PlayLevel1()
	{
		SceneManager.LoadScene("DummyLevel");
	}
}
