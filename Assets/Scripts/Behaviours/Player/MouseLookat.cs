using UnityEngine;
using System.Collections;

public class MouseLookat : MonoBehaviour {

	private Vector3 mousePos;
	private Quaternion lookDirection;
	public Camera mainCamera;

	// Update is called once per frame
	void Update () {
		mousePos = transform.parent.forward*(Input.mousePosition.y - Screen.height/2) + transform.parent.right*(Input.mousePosition.x - Screen.width/2);
		Debug.DrawRay(transform.position, mousePos);
		lookDirection = Quaternion.LookRotation(mousePos, transform.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 100f);
	}
}
