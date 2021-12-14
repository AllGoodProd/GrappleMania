using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private Transform[] waypoints;
	[SerializeField] private bool connectLastToFirst = true;
	[SerializeField] private float speed;
	private int nextWaypoint = 1;
	private Vector3[] waypointsIncludingStart;

	private void Awake()
	{
		waypointsIncludingStart = new Vector3[waypoints.Length + 1];
		waypointsIncludingStart[0] = transform.position;
		for (int i = 0; i < waypoints.Length; i++)
			waypointsIncludingStart[i + 1] = waypoints[i].position;
	}

	private void FixedUpdate()
	{
		rb.velocity = (waypointsIncludingStart[nextWaypoint] - transform.position).normalized * speed;

		if ((transform.position - waypointsIncludingStart[nextWaypoint]).sqrMagnitude < 1f)
		{
			if (nextWaypoint < waypointsIncludingStart.Length - 1)
			{
				nextWaypoint++;
			}
			else
			{
				if (connectLastToFirst)
				{
					nextWaypoint = 0;
				}
				else
				{
					nextWaypoint = 1;
					transform.position = waypointsIncludingStart[0];
				}
			}
		}
	}
}
