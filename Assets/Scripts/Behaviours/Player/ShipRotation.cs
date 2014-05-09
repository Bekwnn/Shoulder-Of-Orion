using UnityEngine;
using System.Collections;

public class ShipRotation : MonoBehaviour {

	private float turnSpeed = 5f;
	public Transform shipLocation;
	private Vector3 moveDirection;
	private Quaternion lookDirection;

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
			moveDirection = shipLocation.right*3*Input.GetAxis("Horizontal") + shipLocation.forward*3*Input.GetAxis("Vertical");
			Debug.DrawRay(transform.position, moveDirection);
			lookDirection = Quaternion.LookRotation(moveDirection, transform.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, turnSpeed);
		}
	}
}
