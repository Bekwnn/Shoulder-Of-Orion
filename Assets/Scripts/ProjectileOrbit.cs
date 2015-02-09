using UnityEngine;
using System.Collections;

public class ProjectileOrbit : MonoBehaviour {
	
	public float projectileSpeedAverage;
	public float projectileSpeedVariance;
	public float lifetime;
	public bool randomStartRotation;
	public bool destroyOnCollision;
	public DealsDamage dealsDamage;
	float projectileSpeed;
	float lifeTimer;
	Vector3 previousPosition;

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

		previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(Vector3.zero, transform.right, Time.deltaTime*projectileSpeed);
		lifeTimer -= Time.deltaTime;
		if (lifeTimer <= 0 && lifetime != 0)
		{
			ObjectPool.instance.PoolObject(gameObject);
		}
		if (dealsDamage || destroyOnCollision)
		{
			RaycastHit hit;
			if (Physics.Linecast(previousPosition, transform.position, out hit))
			{
				OnTriggerEnter(hit.collider);
			}
			previousPosition = transform.position;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		/*if (dealsDamage)
		{
			TakesDamage takesDamage = other.gameObject.GetComponent<TakesDamage>();
			if (takesDamage)
			{
				takesDamage.healthScript.TakeDamage(
					dealsDamage.damage, dealsDamage.damageType
					);
			}
		}*/
		if (destroyOnCollision)
		{
			ObjectPool.instance.PoolObject(gameObject);
		}
	}
}
