using UnityEngine;
using System.Collections;

public class ProjectileOrbit : MonoBehaviour {
	
	public float projectileSpeedAverage;
	public float projectileSpeedVariance;
	public float lifetime;
	public bool randomStartRotation;
	float projectileSpeed;

	// Use this for initialization
	void Start () {
		if (lifetime != 0)
			Destroy(gameObject, lifetime);

		projectileSpeed = Random.Range (
			projectileSpeedAverage - projectileSpeedVariance,
			projectileSpeedAverage + projectileSpeedVariance
		);

		//set random rotation along z rot axis
		if (randomStartRotation)
			transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(Vector3.zero, transform.right, Time.deltaTime*projectileSpeed);
	}
}
