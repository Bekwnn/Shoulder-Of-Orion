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
		GameObject shot = ObjectPool.instance.GetObjectForType(projectile.name, true);
		if (shot)
		{
			shot.transform.position = transform.position;
			shot.transform.rotation = transform.rotation;
		}
	}
}
