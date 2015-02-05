using UnityEngine;
using System.Collections;

public class ShipRotation : MonoBehaviour {

	public Transform parentTransform;
	public float rotateSpeed;
	private Vector3 moveDirection;
	private Quaternion lookDirection;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
			moveDirection = parentTransform.right*3*Input.GetAxis("Horizontal") + parentTransform.up*3*Input.GetAxis("Vertical");
			lookDirection = Quaternion.LookRotation(moveDirection, transform.position);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, rotateSpeed*Time.deltaTime);
		}
	}
}
