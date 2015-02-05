using UnityEngine;
using System.Collections;

public class ProjectileOrbit : MonoBehaviour {
	
	public float projectileSpeedAverage;
	public float projectileSpeedVariance;
	public float lifetime;
	public bool randomStartRotation;
	float projectileSpeed;
	float lifeTimer;

	// Use this for initialization
	void OnEnable () {
		if (lifetime != 0)
			lifeTimer = lifetime;

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
		lifeTimer -= Time.deltaTime;
		if (lifeTimer <= 0 && lifetime != 0)
		{
			ObjectPool.instance.PoolObject(gameObject);
		}
	}
}
