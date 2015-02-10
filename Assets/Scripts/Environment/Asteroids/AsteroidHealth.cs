using UnityEngine;
using System.Collections;

public class AsteroidHealth : Health {
	public SpawnedObject manager;

	public int maxHealthAverage;
	public int maxHealthVariance;
	public EDamageType weakAgainst;
	public int startingHealth;

	void OnEnable()
	{
		if (startingHealth == 0)
		{
			startingHealth = (int)Random.Range(
				maxHealthAverage-maxHealthVariance, maxHealthAverage+maxHealthVariance);
			currentHealth = startingHealth;
		}
		
		ResetScale ();
	}

	public override void TakeDamage(int damage, EDamageType damageType)
	{
		int damageTaken = (int)((weakAgainst == damageType)?
		                        damage * 1.5f : damage);
		currentHealth -= damageTaken;
		OnHealthChange();
	}

	void AsteroidDestroy()
	{
		ResetManager();
		if (manager) manager.ChildDestroyed();
		else Debug.Log("NO MANAGER!");
		ObjectPool.instance.PoolObject(gameObject);
	}

	void OnHealthChange()
	{
		if (currentHealth <= 1)
		{
			ResetManager ();
			AsteroidDestroy();
		}
		if (currentHealth <= startingHealth/2 && startingHealth >= 160)
		{
			ResetManager ();
			startingHealth = startingHealth/2;

			SpawnChild();
			SpawnChild();
			SpawnChild();

			AsteroidDestroy();
		}
	}

	void SpawnChild()
	{
		GameObject child = ObjectPool.instance.GetObjectForType(gameObject.name, false);
		if (child)
		{
			child.transform.parent = transform.root;
			child.transform.position = transform.position;

			//signal to parent there's another asteroid
			if (manager) manager.ChildCreated();

			AsteroidHealth childHealth = child.GetComponent<AsteroidHealth>();
			if (childHealth)
			{
				childHealth.startingHealth = startingHealth;
				childHealth.ResetScale();
				childHealth.ResetManager();
			}
		}
	}

	public void ResetScale()
	{
		transform.localScale = Vector3.one*(startingHealth/100f);
	}

	public void ResetManager()
	{
		manager = transform.root.gameObject.GetComponent<SpawnedObject>();
	}
}
