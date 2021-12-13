using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Rigidbody myRigidBody;
	[SerializeField] private Transform cameraTransform, characterModel;
	[SerializeField] private float moveSpeed, jumpStrength;
	[HideInInspector] public Vector3 startspeedThisFrame = Vector3.zero; //	Used to move/push the player from other scripts

	private bool requestedJump, grounded;
	private Vector2 moveInput;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		if (!cameraTransform)
			cameraTransform = Camera.main.transform;
	}

	private void Update()
	{
		requestedJump = Input.GetKeyDown(KeyCode.Space);
		grounded = Physics.Raycast(transform.position + transform.up * 0.2f, -transform.up, 1.5f);
		Debug.DrawRay(transform.position, -transform.up * 1.5f);

		moveInput.x = Input.GetAxis("Horizontal");
		moveInput.y = Input.GetAxis("Vertical");
	}

	private void LateUpdate()
	{
		if(characterModel)
			characterModel.localEulerAngles = new Vector3(0f, cameraTransform.localEulerAngles.y, 0f);  //	Turns the player model to face front of the camera
	}

	void FixedUpdate()
	{
		Vector3 movementThisFrame = Vector3.zero;

		movementThisFrame += cameraTransform.right * moveInput.x;
		movementThisFrame += cameraTransform.forward * moveInput.y;

		if (movementThisFrame == Vector3.zero && !requestedJump)
			return;

		if(movementThisFrame.sqrMagnitude > 1f)
			movementThisFrame = movementThisFrame.normalized;   //	This is to ensure the character doesn't move faster diagonally

		movementThisFrame *= moveSpeed;

		movementThisFrame += startspeedThisFrame;

		if (grounded && requestedJump)
			movementThisFrame.y = jumpStrength;
		else
			movementThisFrame.y = myRigidBody.velocity.y;

		myRigidBody.velocity = movementThisFrame;
		requestedJump = false;
		startspeedThisFrame = Vector3.zero;
	}
}
