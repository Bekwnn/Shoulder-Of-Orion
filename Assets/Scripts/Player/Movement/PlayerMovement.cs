using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int playerSpeed;

	// Rotate around the origin
	void Update () {
		transform.RotateAround(Vector3.zero, transform.right, Input.GetAxis("Vertical") *playerSpeed* Time.deltaTime);
		transform.RotateAround(Vector3.zero, transform.up, Input.GetAxis("Horizontal") *-playerSpeed* Time.deltaTime);
	}
}
