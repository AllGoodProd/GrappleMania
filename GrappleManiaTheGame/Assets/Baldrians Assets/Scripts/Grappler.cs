using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
	[Header("Settings")]
	public float maxGrappleDistance = 100f;
	[SerializeField] private float hookPullForce = 1f;

	[Header("Object references")]
	[SerializeField] private Rigidbody playerRB;
	[SerializeField] private LineRenderer lr;
	[SerializeField] private Transform fpsCamera, muzzle; // We raycast from the camera so that we hit what we're aiming at. The muzzle is where we draw the line from
	[SerializeField] private ParticleSystem shootEffect;
	public LayerMask grapplableLayers;
	private bool grappleActive;
	private Rigidbody hookedObject;
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
			ToggleGrapple();

		if (grappleActive)
			if (Physics.Raycast(fpsCamera.position, hookedObject.transform.position - fpsCamera.transform.position, out RaycastHit hit, maxGrappleDistance))
				if (grapplableLayers != (grapplableLayers | (1 << hit.transform.gameObject.layer)))
					ToggleGrapple();
	}
	private void FixedUpdate()
	{
		if (grappleActive)
		{
			float playerForceAmount = 1f;

			//	If we've hooked onto an object that is loose, we apply half the force to it, and half to us
			if (!hookedObject.isKinematic)
			{
				playerForceAmount = 0.5f;
				hookedObject.AddForce((playerRB.transform.position - hookedObject.transform.position) * hookPullForce * 0.5f);
			}

			playerRB.AddForce((hookedObject.transform.position - playerRB.transform.position) * hookPullForce * playerForceAmount);

			//	If we pull out the grapple too far, release it automatically. An alternative would be to limit player movement so that they can't pull it out. But that's outside the scope of this demo
			if (Vector3.Distance(playerRB.transform.position, hookedObject.transform.position) > maxGrappleDistance * 1.1f)
				ToggleGrapple();
		}
	}

	private void LateUpdate()
	{
		if (grappleActive)
			lr.SetPositions(new Vector3[] { muzzle.position, hookedObject.transform.position });    //	Update the linerenderer positions. Do this in late update to prevent camera lag
	}

	void ToggleGrapple()
	{
		if (grappleActive)
		{
			lr.positionCount = 0;
			grappleActive = false;
		}
		else
		{
			TryGrapple();
		}
	}

	void TryGrapple()
	{
		if (Physics.Raycast(fpsCamera.position, fpsCamera.forward, out RaycastHit hit, maxGrappleDistance, grapplableLayers))
		{

			//	Grapple happens here
			shootEffect.Play();

			hookedObject = hit.collider.GetComponent<Rigidbody>();
			grappleActive = true;
			lr.positionCount = 2;
			lr.SetPositions(new Vector3[] { muzzle.position, hit.point });
		}
	}

}
