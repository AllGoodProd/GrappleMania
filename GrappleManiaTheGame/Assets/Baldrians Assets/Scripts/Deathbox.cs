using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbox : MonoBehaviour
{
	[SerializeField] private LevelProgress progress;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Player"))
			progress.PlayerDied();
	}
}
