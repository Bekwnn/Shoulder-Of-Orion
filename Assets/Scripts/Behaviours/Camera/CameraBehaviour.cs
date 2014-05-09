using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public float trackSpeed;
	public float zoom;
	public Transform target;
	public Transform shipLocation;

	// FixedUpdate is called independant of frame rate **WARNING, JITTERBUG**
	void FixedUpdate () {
		transform.rotation.SetLookRotation(target.position, transform.up);
		transform.position = Vector3.Slerp(transform.position, shipLocation.position*zoom, trackSpeed);
		Debug.DrawRay(transform.position, -transform.position + shipLocation.position*zoom);
	}
}
