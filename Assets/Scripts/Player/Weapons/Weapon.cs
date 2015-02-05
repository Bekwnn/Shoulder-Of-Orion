using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {
	/* Abstract weapon class
	 */
	public float cooldown;
	public float damage;
	public GameObject projectile;

	public void Fire()
	{
		Instantiate(
			projectile,
			gameObject.transform.position,
			gameObject.transform.rotation
		);
	}
}
