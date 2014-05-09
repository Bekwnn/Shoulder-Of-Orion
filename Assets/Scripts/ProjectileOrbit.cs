using UnityEngine;
using System.Collections;

public class ProjectileOrbit : MonoBehaviour {

	private Transform orbitTarget;
	public float projectileSpeed;
	public float lifetime;

	// Start
	void Start () {
		orbitTarget = GameObject.Find("Planet").transform;
		Destroy(gameObject, lifetime);
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround(orbitTarget.position, -transform.up, Time.deltaTime*projectileSpeed);
	}
}
