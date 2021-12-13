using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	[SerializeField] private bool affectOnlyPlayer;
	[SerializeField] private Rigidbody myRigidbody;
	private List<Rigidbody> riding = new List<Rigidbody>();
	private PlayerController pc;
	
	private void OnTriggerEnter(Collider other)
	{
		if (affectOnlyPlayer && !other.CompareTag("Player"))
			return;

		if (other.CompareTag("Player"))
		{
			other.TryGetComponent(out pc);
			return;
		}

		if (!other.TryGetComponent(out Rigidbody rb))
			return;

		riding.Add(rb);
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			pc = null;
			return;
		}

		if (!other.TryGetComponent(out Rigidbody rb))
			return;

		if (riding.Contains(rb))
			riding.Remove(rb);
	}

	//	This script executes it's FixedUpdate before any other scripts because we've set it to do so in "Project Settings/Script Execution order"
	//	That means the velocity of the object will by default be this, and we can add to it if we want in their own scripts
	private void FixedUpdate()
	{
		if (pc)
			pc.startspeedThisFrame = myRigidbody.velocity;

		foreach (Rigidbody passengerBody in riding)
		{
			passengerBody.velocity = myRigidbody.velocity;
		}
	}

}
