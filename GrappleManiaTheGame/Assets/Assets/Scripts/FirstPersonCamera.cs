using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
	[SerializeField] private float sensitivity = 1f;
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
    {
		Quaternion rotation = transform.rotation;
		Quaternion h = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitivity, Vector3.up);
		Quaternion v = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * sensitivity, Vector3.right);

		transform.rotation = h * rotation * v;
    }
}
