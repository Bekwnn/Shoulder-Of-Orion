using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int playerSpeed = 30;

	private Transform orbitTarget;

	void Start() {
		orbitTarget = GameObject.Find("Planet").transform;
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround(orbitTarget.position, transform.right, Input.GetAxis("Vertical") *playerSpeed* Time.deltaTime);
		transform.RotateAround(orbitTarget.position, transform.forward, Input.GetAxis("Horizontal") *-playerSpeed* Time.deltaTime);
	}
}
