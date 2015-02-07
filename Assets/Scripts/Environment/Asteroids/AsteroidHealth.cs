using UnityEngine;
using System.Collections;

public class AsteroidHealth : Health {
	public GameObject managerObj;
	SpawnedObject manager;

	public int maxHealthAverage;
	public int maxHealthVariance;
	public EDamageType weakAgainst;
	public int startingHealth;

	void OnEnable()
	{
		if (managerObj)
			manager = managerObj.GetComponent<SpawnedObject>();

		startingHealth = (int)Random.Range(
			maxHealthAverage-maxHealthVariance, maxHealthAverage+maxHealthVariance);
		currentHealth = startingHealth;

		transform.localScale = Vector3.one*(startingHealth/100f);
	}

	public override void TakeDamage(int damage, EDamageType damageType)
	{
		int damageTaken = (int)((weakAgainst == damageType)?
		                        damage * 1.5f : damage);
		currentHealth -= damageTaken;
		OnHealthChange();
	}

	void OnDestroy()
	{
		//if (manager) manager.ChildDestroyed();
		ObjectPool.instance.PoolObject(transform.root.gameObject);
	}

	void OnHealthChange()
	{
		if (currentHealth <= 1)
		{
			OnDestroy();
		}
		if (currentHealth <= startingHealth/2 && startingHealth >= 160)
		{
			startingHealth = startingHealth/2;

			/*GameObject gObj = ObjectPool.instance.GetObjectForType(this.name, true);
			AsteroidHealth childHealth;
			if (gObj)
			{
				childHealth = gObj.GetComponent<AsteroidHealth>();
				if (manager)
				{
					childHealth.manager = manager;
					manager.ChildCreated();	//signal to parent there's another asteroid
					gObj.transform.parent = transform.parent;
				}
			}*/

			transform.localScale = Vector3.one*(startingHealth/100f);
			transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
		}
	}
}
